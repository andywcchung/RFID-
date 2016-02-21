using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS203_CALLBACK_API_DEMO
{
    public partial class FormColdChainMonitorConfig : Form
    {
        public FormColdChainMonitorConfig()
        {
            InitializeComponent();
        }

        private void textBox6_LostFocus(object sender, EventArgs e)
        {

        }

        private void textBox5_LostFocus(object sender, EventArgs e)
        {

        }

        private void label6_ParentChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_LostFocus(object sender, EventArgs e)
        {

        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_ParentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label9_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label8_ParentChanged_1(object sender, EventArgs e)
        {

        }

        string ActualSIString(int unit, int value)
        {
            string SIString;

            SIString = value.ToString();

            switch (unit)
            {
                case 0:
                    SIString += " second";
                    break;

                case 1:
                    SIString += " minute";
                    break;

                case 2:
                    SIString += " hour";
                    break;

                case 3:
                    SIString = (value * 5).ToString() + " minute";
                    break;
            }

            return SIString;
        }

        void UpdateSI()
        {
            try
            {
                labelASI.Text = ActualSIString(comboBox2.SelectedIndex, int.Parse(textBox6.Text));
            }
            catch (Exception ex)
            {
                labelASI.Text = "Not Acceptance";
            }
        }

        void UpdateSSD()
        {
            try
            {
                labelASSD.Text = int.Parse(textBox5.Text).ToString();

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        labelASSD.Text += " second";
                        break;

                    case 1:
                        labelASSD.Text += " minute";
                        break;

                    case 2:
                        labelASSD.Text += " hour";
                        break;

                    case 3:
                        labelASSD.Text = ActualSIString(comboBox2.SelectedIndex, int.Parse(textBox6.Text) * int.Parse(textBox5.Text));
                        break;
                }
            }
            catch (Exception ex)
            {
                labelASSD.Text = "Not Acceptance";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSSD();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            UpdateSSD();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            UpdateSI();
            UpdateSSD();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSI();
            UpdateSSD();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            int value;

            try
            {
                value = int.Parse(textBox5.Text);
                if (value < 64)
                    textBox5.Text = int.Parse(textBox5.Text).ToString();
                else
                    textBox5.Text = "1";
            }
            catch (Exception ex)
            {
                textBox5.Text = "1";
            }

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            int value;

            try
            {
                value = int.Parse(textBox6.Text);
                if (value < 64)
                    textBox6.Text = int.Parse(textBox6.Text).ToString();
                else
                    textBox6.Text = "1";
            }
            catch (Exception ex)
            {
                textBox6.Text = "1";
            }
        }
    }
}