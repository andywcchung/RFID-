using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class MenuBar : UserControl
    {
        #region private member
        public event EventHandler ButtonClick;

        public int SelectedIndex = -1;

        System.Windows.Forms.Button[] m_button_array = new System.Windows.Forms.Button[6];

        private int m_max_display_items = 6;

        private int m_current_first_index = 0;

        private List<Button> m_btnList = new List<Button>();

        private readonly Size m_button_size = new Size(90, 25);
        #endregion

        #region public function
        public MenuBar()
        {
            InitializeComponent();

            InitialButton();
        }

        public void Add(Button btn)
        {
            m_btnList.Add(btn);
        }

        public void Remove(Button btn)
        {
            m_btnList.Remove(btn);
        }

        public void UpdateItems()
        {
            pnl_btn.SuspendLayout();
            pnl_btn.Controls.Clear();
            for (int index = 0; (index + m_current_first_index < m_btnList.Count) && (index < m_max_display_items); index++)
            {
                m_button_array[index].Text = m_btnList[index + m_current_first_index].text;
                m_button_array[index].BackColor = m_btnList[index + m_current_first_index].backColor;
                m_button_array[index].ForeColor = m_btnList[index + m_current_first_index].fontColor;
                this.pnl_btn.Controls.Add(m_button_array[index]);
            }
            pnl_btn.ResumeLayout(true);
        }
        #endregion

        #region Button Handle
        private void btn_up_Click(object sender, EventArgs e)
        {
           if (m_current_first_index == 0)
            {
                return;
            }
            m_current_first_index--;
            UpdateItems(); 
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (m_current_first_index + m_max_display_items >= m_btnList.Count)
            {
                return;
            }
            m_current_first_index++;
            UpdateItems();
        }

        private void InitialButton()
        {
            m_button_array[0] = new System.Windows.Forms.Button();
            m_button_array[0].Click += new EventHandler(Button0_Click);
            m_button_array[0].Location = new Point(3, 6);
            m_button_array[0].Size = m_button_size;
            m_button_array[0].Font = new Font("Arial", 10, FontStyle.Bold);

            m_button_array[1] = new System.Windows.Forms.Button();
            m_button_array[1].Click += new EventHandler(Button1_Click);
            m_button_array[1].Location = new Point(3, 37);
            m_button_array[1].Size = m_button_size;
            m_button_array[1].Font = new Font("Arial", 10, FontStyle.Bold);

            m_button_array[2] = new System.Windows.Forms.Button();
            m_button_array[2].Click += new EventHandler(Button2_Click);
            m_button_array[2].Location = new Point(3, 68);
            m_button_array[2].Size = m_button_size;
            m_button_array[2].Font = new Font("Arial", 10, FontStyle.Bold);

            m_button_array[3] = new System.Windows.Forms.Button();
            m_button_array[3].Click += new EventHandler(Button3_Click);
            m_button_array[3].Location = new Point(3, 99);
            m_button_array[3].Size = m_button_size;
            m_button_array[3].Font = new Font("Arial", 10, FontStyle.Bold);

            m_button_array[4] = new System.Windows.Forms.Button();
            m_button_array[4].Click += new EventHandler(Button4_Click);
            m_button_array[4].Location = new Point(3, 130);
            m_button_array[4].Size = m_button_size;
            m_button_array[4].Font = new Font("Arial", 10, FontStyle.Bold);

            m_button_array[5] = new System.Windows.Forms.Button();
            m_button_array[5].Click += new EventHandler(Button5_Click);
            m_button_array[5].Location = new Point(3, 161);
            m_button_array[5].Size = m_button_size;
            m_button_array[5].Font = new Font("Arial", 10, FontStyle.Bold);

        }

        void Button0_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        void Button1_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index + 1;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        void Button2_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index + 2;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        void Button3_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index + 3;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        void Button4_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index + 4;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        void Button5_Click(object sender, EventArgs e)
        {
            SelectedIndex = m_current_first_index + 5;
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        #endregion
    }

    public class Button
    {
        public string text = "";
        public Color backColor = Color.White;
        public Color fontColor = Color.Black;

        public Button(string text, Color backColor, Color fontColor)
        {
            this.text = text;
            this.backColor = backColor;
            this.fontColor = fontColor;
        }
    }
}
