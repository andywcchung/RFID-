using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class StartMenu : UserControl
    {
        private bool bToggleStartButton = false;

        private bool isHideMenu = false;

        private bool isSelectable = false;
        public delegate void ButtonClickArgs(ButtonClickType type);
        public event ButtonClickArgs OnButtonClick;

        public bool IsSelectable
        {
            get { return isSelectable; }
            set { isSelectable = value; }
        }

        public bool IsHideMenu
        {
            get { return isHideMenu; }
        }

        public Sorting SortingMethod
        {
            get { return (Sorting)cb_sorting.SelectedIndex; }
        }

        public StartMenu()
        {
            InitializeComponent();

            cb_sorting.SelectedIndex = 0;
        }

        private void lk_hideMenu_Click(object sender, EventArgs e)
        {
            if (isHideMenu)
            {
                lk_hideMenu.Text = "Hide Menu";
                this.Location = new Point(0, 180);
                this.Height = 60;
                isHideMenu = false;

            }
            else
            {
                lk_hideMenu.Text = "Show Menu";
                this.Location = new Point(0, 210);
                this.Height = 30;
                isHideMenu = true;
            }
            if (OnButtonClick != null)
            {
                OnButtonClick(isHideMenu ? ButtonClickType.Hide : ButtonClickType.Unhide);
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(OnButtonClick !=null)
            {
                OnButtonClick(bToggleStartButton ? ButtonClickType.Stop : ButtonClickType.Start);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(ButtonClickType.Clear);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(ButtonClickType.Save);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(ButtonClickType.Exit);
            }
        }
        private delegate void ToggleStartButtonDel();
        public void ToggleStartButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ToggleStartButtonDel(ToggleStartButton), new object[] { });
                return;
            }
            if (bToggleStartButton)
            {
                btn_start.BackColor = Color.FromArgb(0, 192, 0);
                btn_start.Text = "Start";
                bToggleStartButton = false;
                btn_clear.Enabled = btn_exit.Enabled = btn_save.Enabled = cb_sorting.Enabled = true;
            }
            else
            {
                btn_start.BackColor = Color.Red;
                btn_start.Text = "Stop";
                bToggleStartButton = true;
                btn_clear.Enabled = btn_exit.Enabled = btn_save.Enabled = cb_sorting.Enabled = false;
            }
        }

        private delegate void UpdateTagCountDel(int info);
        public void UpdateTagCount(int info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateTagCountDel(UpdateTagCount), new object[] { info });
                return;
            }
            lb_tagFound.Text = info.ToString();
        }
        private delegate void UpdateTagRateDel(int info);
        public void UpdateTagRate(int info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateTagRateDel(UpdateTagRate), new object[] { info });
                return;
            }
            lb_rate.Text = info.ToString();
            linkLabel1.Text = "Tag/s";
        }

        private delegate void UpdateTimeElapsedDel(int sec);
        public void UpdateTimeElapsed(double sec)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateTagRateDel(UpdateTagRate), new object[] { sec });
                return;
            }
            lb_rate.Text = sec.ToString("F0");
            linkLabel1.Text = "sec";
        }

        private delegate void UpdateStartBtnDel(bool select);
        public void UpdateStartBtn(bool select)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStartBtnDel(UpdateStartBtn), new object[] { select });
                return;
            }
            btn_start.Text = select ? "Select" : "Start";
        }

        private void cb_sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(ButtonClickType.Sorting);
            }
        }
    }

    public enum Sorting
    {
        EPC_Ascending,
        EPC_Decending,
        RSSI_Ascending,
        RSSI_Decending,
    }

    public enum ButtonClickType
    {
        Start,
        Stop,
        Save,
        Clear,
        Exit,
        Hide,
        Unhide,
        Sorting,
        Unknown
    };

}
