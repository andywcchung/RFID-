#if NET_BUILD
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

using CSLibrary.Net;

using System.Net.NetworkInformation;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class NetFinderForm : Form
    {
        #region Member variable

        private string Info_Search = "Press \"Search\" button to search all Reader in the same subnet.";
        private string Info_Connect = "Press \"Connect\" or \"Assignment\" or other buttons.";
        private string Info_Select = "Select any Reader device on the list.";

        private bool m_start = false;

        private NetFinder netfinder = new NetFinder();
        private UpdateProgressForm progressform = null;

        public string ConnectIP;

        public string MAC;

        #endregion

        #region Form
        public NetFinderForm()
        {
            InitializeComponent();
        }

        private void NetFinderForm_Load(object sender, EventArgs e)
        {
            progressform = new UpdateProgressForm();
            progressform.Disposed += new EventHandler(progressform_Disposed);

            netfinder.OnSearchCompleted += new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
            netfinder.OnAssignCompleted += new EventHandler<ResultArgs>(netfinder_OnAssignCompleted);
            netfinder.OnUpdateCompleted += new EventHandler<UpdateResultArgs>(netfinder_OnUpdateCompleted);
            netfinder.OnUpdatePercent += new EventHandler<UpdatePercentArgs>(netfinder_OnUpdatePercent);

            lb_info.Text = Info_Search;

            this.Text += " : C# Native Library; Demo App Vers " + Program.GetDemoVersion().ToString() + "; CSLib Vers " + Program.ReaderXP.GetCSLibraryVersion().ToString();

            {
                int NetworkAdapter = -1;

                foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork && unicastIPAddressInformation.IPv4Mask != null)
                        {
                            if (NetworkAdapter < 2)
                            //if (address.Equals(unicastIPAddressInformation.Address))
                            {
                                NetworkAdapter++;

                                switch (NetworkAdapter)
                                {
                                    case 0:
                                        textBox_IP1.Text = unicastIPAddressInformation.Address.ToString();
                                        textBox_Mask1.Text = unicastIPAddressInformation.IPv4Mask.ToString();
                                        break;

                                    case 1:
                                        textBox_IP2.Text = unicastIPAddressInformation.Address.ToString();
                                        textBox_Mask2.Text = unicastIPAddressInformation.IPv4Mask.ToString();
                                        break;

                                    case 2:
                                        textBox_IP3.Text = unicastIPAddressInformation.Address.ToString();
                                        textBox_Mask3.Text = unicastIPAddressInformation.IPv4Mask.ToString();
                                        break;
                                }
                            }
                        }
                    }
                }

                NetworkAdapter++;

                for (int cnt = NetworkAdapter; cnt < 3; cnt++)
                {
                    switch (NetworkAdapter)
                    {
                        case 0:
                            textBox_IP1.Text = "";
                            break;

                        case 1:
                            textBox_IP2.Text = "";
                            break;

                        case 2:
                            textBox_IP3.Text = "";
                            break;
                    }
                }
            }

        }

        private void NetFinderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            netfinder.OnSearchCompleted -= new EventHandler<DeviceFinderArgs>(netfinder_OnSearchCompleted);
            netfinder.OnAssignCompleted -= new EventHandler<ResultArgs>(netfinder_OnAssignCompleted);
            netfinder.OnUpdateCompleted -= new EventHandler<UpdateResultArgs>(netfinder_OnUpdateCompleted);
            netfinder.OnUpdatePercent -= new EventHandler<UpdatePercentArgs>(netfinder_OnUpdatePercent);
            netfinder.Stop();
            netfinder.Dispose();
        }
        #endregion

        #region Button Event
        private void btn_start_Click(object sender, EventArgs e)
        {
            IPAddress addr = IPAddress.Broadcast;
            if (!m_start)
            {
                m_start = true;
                if (cbDirectSearch.Checked)
                {
                    bool ipcheck = IPAddress.TryParse(tbIpAddress.Text, out addr);

//                    if (string.IsNullOrEmpty(tbIpAddress.Text) && IPAddress.TryParse(tbIpAddress.Text, out addr))
                    if (string.IsNullOrEmpty(tbIpAddress.Text) == true || ipcheck == false)
                    {
                        MessageBox.Show("Invalid ip address");
                        return;
                    }
                    netfinder.SearchDevice(addr);
                }
                else
                {
                    netfinder.SearchDevice();
                }
                btn_start.BackColor = Color.Red;
                btn_start.Text = "Stop";
            }
            else
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            btn_connect.Enabled = false;
            btn_assign.Enabled = false;
            btn_image.Enabled = false;
            btn_bootloader.Enabled = false;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }

            if (netfinder.Operation != RecvOperation.IDLE)
            {
                MessageBox.Show("Please stop searching device first.");
                return;
            }
            if (lv_device.SelectedIndex >= 0 && lv_device.SelectedIndex < lv_device.Items.Count)
            {
                
                switch (lv_device.devicelist[lv_device.SelectedIndex].Mode)
                {

                    case Mode.Normal:                
                    //Get local ip address
                    string ip = LocalIPAddress();
       
                    //Directly connect to tcp
                    byte[] ipb = lv_device.devicelist[lv_device.SelectedIndex].IPAddress.Address;
                    byte[] mac = lv_device.devicelist[lv_device.SelectedIndex].MACAddress.Address;
                    byte[] netmask = lv_device.devicelist[lv_device.SelectedIndex].SubnetMask.Address;


                    if (lv_device.devicelist[lv_device.SelectedIndex].TrustedServerEnabled)
                    {
                        byte[] ipts = lv_device.devicelist[lv_device.SelectedIndex].TrustedServer.Address;
                        ConnectIP = String.Format("{0}.{1}.{2}.{3}", ipts[0], ipts[1], ipts[2], ipts[3]);
                        MessageBox.Show("WARNING : Trusted service enable, device only connect to {0}", ConnectIP);
                    }

                    String[] localIP = ip.Split('.');

                    bool sameSubnet = true;

                    // Check Local PC network
                    // Check Device network
                    // 
                    if (netmask[0] != 255 || netmask[1] != 255 || netmask[2] != 255 || netmask[3] != 255)
                    {
                        byte [] LocalNetwork = new byte [4];
                        byte [] RemoteNetwork = new byte [4];
                        UnicastIPAddressInformation NI;

                        NI = LocalNetworkInfo ();

                        if (NI == null)
                        {
                            MessageBox.Show ("Can not get Network card information");
                        }
                        else
                        {
                            for (int cnt = 0; cnt < 4; cnt++)
                            {
                                LocalNetwork[cnt] = (byte)(NI.Address.GetAddressBytes ()[cnt] & NI.IPv4Mask.GetAddressBytes () [cnt]);
                            }

                            for (int cnt = 0; cnt < 4; cnt++)
                            {
                                RemoteNetwork[cnt] = (byte)(ipb[cnt] & netmask[cnt]);
                            }

                            for (int cnt = 0; cnt < 4; cnt++)

                            if (LocalNetwork[cnt] != RemoteNetwork[cnt])
                            {
                                sameSubnet = false;
                                break;
                            }
                        }
                    }

#if nouse
                    if (!sameSubnet)
                    {
                        if (MessageBox.Show("Reminder! You are going to connect a device in other subnet. You may need gateway in between. Please press 'OK' to continue", "Reminder!", MessageBoxButtons.OK) == DialogResult.Yes)
                        {
                            //ConnectIP = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                            //MAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]);
                            //DialogResult = DialogResult.OK;
                            //this.Close();
                        }
                    }
#endif

                    {
                        ConnectIP = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                        MAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]);

                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;

                    case Mode.NormalUsb:
                    case Mode.NormalSerial:
                        ConnectIP = lv_device.devicelist[lv_device.SelectedIndex].DeviceName;
                        MAC = "";
                        DialogResult = DialogResult.OK;
                        this.Close();
                        break;

                }
            }
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public UnicastIPAddressInformation LocalNetworkInfo()
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && unicastIPAddressInformation.IPv4Mask != null)
                    {
                        //Console.WriteLine("\tIP Address is {0}", unicastIPAddressInformation.Address);
                        //onsole.WriteLine("\tSubnet Mask is {0}", UnicatIPInfo.IPv4Mask);

                        return unicastIPAddressInformation;
                    }
                }
            }

            return null;
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }

            if (netfinder.Operation != RecvOperation.IDLE)
            {
                MessageBox.Show("Please stop searching device first.");
                return;
            }

            using (AssignForm assign = new AssignForm())
            {
                //assign.CS203IP = lv_device.Items[lv_device.SelectedIndices[0]].SubItems[2].Text;
                byte[] ipb = lv_device.devicelist[lv_device.SelectedIndex].IPAddress.Address;
                byte[] tsIP = lv_device.devicelist[lv_device.SelectedIndex].TrustedServer.Address;
                assign.CS203IP = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                assign.DeviceName = lv_device.devicelist[lv_device.SelectedIndex].DeviceName;
                assign.DHCPRetry = lv_device.devicelist[lv_device.SelectedIndex].DHCPRetry;
                assign.DHCPEnable = lv_device.devicelist[lv_device.SelectedIndex].DHCPEnabled;
                assign.TrustedServer = String.Format("{0}.{1}.{2}.{3}", tsIP[0], tsIP[1], tsIP[2], tsIP[3]);
                assign.TrustedEnable = lv_device.devicelist[lv_device.SelectedIndex].TrustedServerEnabled;
                assign.Subnet = lv_device.devicelist[lv_device.SelectedIndex].SubnetMask;
                assign.Gateway = lv_device.devicelist[lv_device.SelectedIndex].Gateway;
                if (lv_device.devicelist[lv_device.SelectedIndex].GatewayCheckResetMode < 0)
                    assign.checkBox_GatewayCheckResetMode.Visible = false;
                else
                {
                    assign.checkBox_GatewayCheckResetMode.Visible = true;
                    if (lv_device.devicelist[lv_device.SelectedIndex].GatewayCheckResetMode == 1)
                        assign.checkBox_GatewayCheckResetMode.Checked = true;
                    else
                        assign.checkBox_GatewayCheckResetMode.Checked = false;
                }
                
                if (assign.ShowDialog() == DialogResult.OK)
                {
                    string[] ip = assign.CS203IP.Split(new char[] { '.' });
                    string[] ts_ip = assign.TrustedServer.Split(new char[] { '.' });
                    string[] subnet = assign.Subnet.Split(new char[] { '.' });
                    string[] gateway = assign.Gateway.Split(new char[] { '.' });
                    if (ip != null && ip.Length == 4)
                    {
                        netfinder.AssignDevice(
                            lv_device.devicelist[lv_device.SelectedIndex].MACAddress.Address, 
                            new byte[] { byte.Parse(ip[0]), byte.Parse(ip[1]), byte.Parse(ip[2]), byte.Parse(ip[3]) },
                            assign.DeviceName, 
                            assign.DHCPRetry,
                            assign.DHCPEnable,
                            new byte[] { byte.Parse(ts_ip[0]), byte.Parse(ts_ip[1]), byte.Parse(ts_ip[2]), byte.Parse(ts_ip[3]) },
                            assign.TrustedEnable,
                            new byte[] { byte.Parse(subnet[0]), byte.Parse(subnet[1]), byte.Parse(subnet[2]), byte.Parse(subnet[3]) },
                            new byte[] { byte.Parse(gateway[0]), byte.Parse(gateway[1]), byte.Parse(gateway[2]), byte.Parse(gateway[3]) },
                            ((lv_device.devicelist[lv_device.SelectedIndex].GatewayCheckResetMode < 0) ? -1 : assign.checkBox_GatewayCheckResetMode.Checked ? 1 : 0)
                           );
                    }
                }
            }
        }
        private void btn_image_Click(object sender, EventArgs e)
        {
            //tftp -i %d.%d.%d.%d PUT \"%s\" boot.img
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            try
            {
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    ofile.Title = "Please choose Image update file";
                    ofile.Filter = "IMG files (*.img)|*.img|All files (*.*)|*.*";//"IMG Files\0*.img;\0All Files\0*.*\0";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ipb = lv_device.devicelist[lv_device.SelectedIndex].IPAddress.Address;
                        string ip = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);

                        netfinder.AsyncUpdateImage(ip, ofile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_bootloader_Click(object sender, EventArgs e)
        {
            if (m_start)
            {
                m_start = false;
                netfinder.Stop();
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Search";
            }
            try
            {
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    ofile.Title = "Please choose Eboot update file";
                    ofile.Filter = "BIN files (*.bin)|*.bin|All files (*.*)|*.*";//"BIN Files\0*.bin;\0All Files\0*.*\0";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        byte[] ipb = lv_device.devicelist[lv_device.SelectedIndex].IPAddress.Address;
                        string ip = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                        int port = (int)lv_device.devicelist[lv_device.SelectedIndex].Port;
                        
                        netfinder.AsyncUpdateEboot(ip, ofile.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            UpdateInfo(Info_Search);
            btn_connect.Enabled = false;
            btn_assign.Enabled = false;
            btn_image.Enabled = false;
            btn_bootloader.Enabled = false;
            netfinder.ClearDeviceList();
            lv_device.RemoveAllEntries();
            netfinder.ResearchDevice();
        }
        #endregion

        #region Callback and delegete
        void netfinder_OnUpdatePercent(object sender, UpdatePercentArgs e)
        {
            if (progressform.Closed)
            {
                progressform = new UpdateProgressForm();
                progressform.Disposed += new EventHandler(progressform_Disposed);
            }
            progressform.Show();
            progressform.Percent = e.Percent;
        }

        void progressform_Disposed(object sender, EventArgs e)
        {
            btn_clear_Click(null, EventArgs.Empty);
            btn_start_Click(null, EventArgs.Empty);
        }

        void netfinder_OnUpdateCompleted(object sender, UpdateResultArgs e)
        {
            progressform.MessageTxt = String.Format("FW Update {0}", e.Result);
        }

        void netfinder_OnSearchCompleted(object sender, DeviceFinderArgs e)
        {
            UpdateInfo(Info_Select);
            UpdateUI(e.Found);
        }
        void netfinder_OnAssignCompleted(object sender, ResultArgs e)
        {
            ShowMsg(e.Result);
        }


        private delegate void UpdateEbootResultDeleg(UpdateResult result);
        private void UpdateEbootResult(UpdateResult result)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateEbootResultDeleg(UpdateEbootResult), new object[] { result });
                return;
            }
            //add to list
            Debug.WriteLine(String.Format("Update eboot {0}", result));
            MessageBox.Show(String.Format("Update eboot {0}", result));
        }

        private delegate void UpdateInfoDeleg(String info);

        private void UpdateInfo(String info)
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateInfoDeleg(UpdateInfo), new object[] { info });
                return;
            }
            //add to list
            lb_info.Text = info;

        }

        private delegate void UpdateUIDeleg(DeviceInfomation data);

        private void UpdateUI(DeviceInfomation data)
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new UpdateUIDeleg(UpdateUI), new object[] { data });
                return;
            }
            //add to list
            Debug.WriteLine(String.Format("UI List add {0}", data.DeviceName));
            lv_device.AddEntry(data);

        }

        private delegate void ShowMsgDeleg(AssignResult e);
        private void ShowMsg(AssignResult e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ShowMsgDeleg(ShowMsg), new object[] { e });
                return;
            }

            switch (e)
            {
                case AssignResult.ACCEPTED:
                    MessageBox.Show("Assign completed");
                    btn_clear_Click(null, null);
                    btn_start_Click(null, null);
                    break;
                case AssignResult.REJECTED:
                    MessageBox.Show("Assign rejected");
                    break;
                case AssignResult.UNKNOWN:
                    MessageBox.Show("Assign fail");
                    break;
                case AssignResult.TIMEOUT:
                    MessageBox.Show("Assign timeout");
                    break;
            }

        }

        private delegate void ConnectResultDeleg(AssignResult e);
        private void ConnectResult(AssignResult e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ConnectResultDeleg(ConnectResult), new object[] { e });
                return;
            }

            switch (e)
            {
                case AssignResult.ACCEPTED:
                    //MessageBox.Show("Connect success");
                    DialogResult = DialogResult.OK;
                    byte[] ipb = lv_device.devicelist[lv_device.SelectedIndex].IPAddress.Address;
                    byte[] mac = lv_device.devicelist[lv_device.SelectedIndex].MACAddress.Address;

                    ConnectIP = String.Format("{0}.{1}.{2}.{3}", ipb[0], ipb[1], ipb[2], ipb[3]);
                    MAC = string.Format("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]); 
                    this.Close();
                    break;
                case AssignResult.REJECTED:
                    MessageBox.Show("Connect rejected");
                    break;
                case AssignResult.UNKNOWN:
                    MessageBox.Show("Connect fail");
                    break;
                case AssignResult.TIMEOUT:
                    MessageBox.Show("Connect timeout");
                    break;
            }
        }

        #endregion

        #region Listview Event
        private void lv_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_device.SelectedIndex >= 0 && lv_device.SelectedIndex < lv_device.Items.Count)
            {
                switch (lv_device.devicelist[lv_device.SelectedIndex].Mode)
                {
                    case Mode.Bootloader:
                        btn_connect.Enabled = false;
                        btn_assign.Enabled = true;
                        btn_image.Enabled = true;
                        btn_bootloader.Enabled = false;
                        break;
                    case Mode.Normal:
                        btn_connect.Enabled = true;
                        btn_assign.Enabled = true;
                        btn_image.Enabled = false;
                        btn_bootloader.Enabled = true;
                        break;
                    case Mode.NormalUsb:
                    case Mode.NormalSerial:
                        btn_connect.Enabled = true;
                        btn_assign.Enabled = false;
                        btn_image.Enabled = false;
                        btn_bootloader.Enabled = false;
                        break;
                }
                UpdateInfo(Info_Connect);
            }
            else
            {
                btn_connect.Enabled = false;
                btn_assign.Enabled = false;
                btn_bootloader.Enabled = false;
                btn_image.Enabled = false;
            }
        }

        #endregion

    }
}
#endif
