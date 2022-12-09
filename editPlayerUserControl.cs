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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dream11
{
    public partial class editPlayerUserControl : UserControl
    {
        static SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
        public static string userName = Login.userName;
        public static string pName = myteamUserControl.pName;
        public editPlayerUserControl()
        {
            InitializeComponent();
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select firstname+' '+lastname as [Full Name], position, rating, nationality, playerPrice, pace, physique, shoot from playerInfo where firstName+' '+lastName = '"+ pName +"'", con); //Write Query
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr["position"], dr["rating"], dr["nationality"], dr["playerPrice"], dr["pace"], dr["physique"], dr["shoot"]);
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

        private void editPlayerUserControl_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you really want to sell this player?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"update playerInfo set userID = NULL where firstName+' '+lastName = '" + pName + "'", con); //Write Query
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"update userInfo set userBudget = userBudget+(select playerPrice from playerInfo where firstName+' '+lastName = '" + pName + "') where userName = '" + userName + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"update userInfo set teamRating = (select avg(rating) from playerInfo where userid = (select userid from userInfo where userName = '" + userName + "')) where userName = '" + userName + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Player removed from your team.", "Success", MessageBoxButtons.OK);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            myteamUserControl uc = new myteamUserControl();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
