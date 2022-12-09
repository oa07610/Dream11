using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dream11
{
    public partial class profileUserControl : UserControl
    {
        static SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
        public static string userName = Login.userName;

        public profileUserControl()
        {
            InitializeComponent();
        }

        private void profileUserControl_Load(object sender, EventArgs e)
        {
            textBox2.Text = userName;
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"select clubInfo.clubName from clubInfo, userInfo where userInfo.clubID = clubInfo.clubID and userinfo.userName = '"+ userName +"'", con); //Write Query For Club
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label7.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select leagueinfo.leaguename from leagueInfo, clubInfo, userInfo where userInfo.clubID = clubInfo.clubID and clubInfo.leagueID = leagueInfo.leagueID  and userinfo.userName = '" + userName + "'", con); //Write Query For League
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label6.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select coachInfo.coachName from coachInfo, userInfo, clubInfo where userInfo.clubID = clubInfo.clubID and clubInfo.coachID = coachInfo.coachID and userinfo.userName = '" + userName + "'", con); //Write Query For Coach
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label10.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select teamRating from userInfo where userName = '" + userName + "'", con); //Write Query For OVR
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox3.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select count(*) from playerInfo, userinfo where userInfo.userID = playerInfo.userID and userName = '" + userName + "'", con); //Write Query For OVR
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label8.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select teamName from userInfo where userName = '" + userName + "'", con); //Write Query For OVR
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr.GetValue(0).ToString();
                }

                cmd = new SqlCommand(@"select userBudget from userInfo where userName = '" + userName + "'", con); //Write Query For League
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label1.Text = dr.GetValue(0).ToString();
                }

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
