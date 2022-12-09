using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dream11
{
    public partial class myteamUserControl : UserControl
    {
        static SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
        public static string username = Login.userName;
        public static string pName;
        bool hid = true;
        public myteamUserControl()
        {
            InitializeComponent();
            //System.Console.WriteLine(LoadPlayerList(username, "ST"));
            List<string> stList = LoadPlayerList(username, "ST");
            List<string> cbList = LoadPlayerList(username, "CB");
            List<string> cmList = LoadPlayerList(username, "CM");

            label2.Text = LoadPlayer(username, "GK");
            label5.Text = LoadPlayer(username, "RW");
            label7.Text = LoadPlayer(username, "CAM");
            label10.Text = LoadPlayer(username, "LW");
            label1.Text = stList[0];
            label11.Text = stList[1];
            label4.Text = cbList[0];
            label3.Text = cbList[1];
            label9.Text = cbList[2];
            label8.Text = cmList[0];
            label6.Text = cmList[1];
            
            panelContainer.Hide();
            button1.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
            button12.Hide();
            button13.Hide();
        }

        private List<string> LoadPlayerList(string username, string pos)
        {
            string[] defaults = {"xNONEx", "xNONEx", "xNONEx"};
            List<string> playerList = new List<string>(defaults);
            int i = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand(@"select firstname+' '+lastname as [Full Name] from playerInfo, userInfo where playerinfo.userID = userinfo.userID and position = '"+ pos +"' and userinfo.userName = '"+ username +"'", con); //Write Query
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    playerList[i] = (dr.GetValue(0).ToString());
                    i++;
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
            return playerList;
        }

        private string LoadPlayer(string username, string pos)
        {
            string player="xNONEx";
            SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand(@"select firstname+' '+lastname as [Full Name] from playerInfo, userInfo where playerinfo.userID = userinfo.userID and position = '" + pos + "' and userinfo.userName = '" + username + "'", con); //Write Query
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    player = dr.GetValue(0).ToString();
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
            return player;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void editPP()
        {
            button1.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
            button12.Hide();
            button13.Hide();
            hid = true;
            editPlayerUserControl uc = new editPlayerUserControl();
            panelContainer.Show();
            addUserControl(uc);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelContainer.Hide();
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(hid == true)
            {
                button1.Show();
                button4.Show();
                button5.Show();
                button6.Show();
                button7.Show();
                button8.Show();
                button9.Show();
                button10.Show();
                button11.Show();
                button12.Show();
                button13.Show();
                hid = false;
            }
            else
            {
                button1.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                button7.Hide();
                button8.Hide();
                button9.Hide();
                button10.Hide();
                button11.Hide();
                button12.Hide();
                button13.Hide();
                hid = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pName = label11.Text;
            editPP();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pName = label1.Text;
            editPP();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            pName = label5.Text;
            editPP();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pName = label6.Text;
            editPP();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pName = label7.Text;
            editPP();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pName = label8.Text;
            editPP();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pName = label10.Text;
            editPP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pName = label9.Text;
            editPP();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pName = label3.Text;
            editPP();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pName = label4.Text;
            editPP();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pName = label2.Text;
            editPP();
        }

        private void myteamUserControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}
