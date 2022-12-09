using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dream11
{
    public partial class settingsUserControl : UserControl
    {
        public settingsUserControl()
        {
            InitializeComponent();
            if (checkBox1.Checked)
            {
                checkBox1.Text = "STOP";
            }
            else
            {
                checkBox1.Text = "PLAY";
                Form1.sp.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "STOP";
                Form1.sp.Play();
            }
            else
            {
                checkBox1.Text = "PLAY";
                Form1.sp.Stop();
            }
        }

        private void settingsUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
