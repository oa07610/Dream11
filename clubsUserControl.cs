using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace Dream11
{
    public partial class clubsUserControl : UserControl
    {
        public static string userName = Login.userName;
        public string club;
        public string league;
        public string coach;
        public clubsUserControl()
        {
            InitializeComponent();
        }

        private void UpdateClub(string club)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Update userInfo set clubID = (select clubID from clubInfo where clubName = '" + club + "') where userName = '" + userName + "'", con); //Write Query For Club
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //System.Console.WriteLine(club);
                club = button1.Text;
                UpdateClub(club);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button9.Text;
                UpdateClub(club);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button8.Text;
                UpdateClub(club);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button4.Text;
                UpdateClub(club);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button5.Text;
                UpdateClub(club);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button6.Text;
                UpdateClub(club);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button10.Text;
                UpdateClub(club);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button7.Text;
                UpdateClub(club);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button3.Text;
                UpdateClub(club);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to select this club for your team?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                club = button2.Text;
                UpdateClub(club);
            }
        }
    }
}
