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
    public partial class Form1 : Form
    {
        public static string userName = Login.userName;
        public static string pass = Login.pass;

        public Form1()
        {
            InitializeComponent();
            profileUserControl uc = new profileUserControl();
            addUserControl(uc);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myteamUserControl uc = new myteamUserControl();
            addUserControl(uc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            marketUserControl uc = new marketUserControl();
            addUserControl(uc);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            profileUserControl uc = new profileUserControl();
            addUserControl(uc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database Systems project developed by Owees17, Chandani, hammadxsajid. DBS L5. Miss Saba OP.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            leaderboardUserControl uc = new leaderboardUserControl();
            addUserControl(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clubsUserControl uc = new clubsUserControl();
            addUserControl(uc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
