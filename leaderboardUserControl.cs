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

namespace Dream11
{
    public partial class leaderboardUserControl : UserControl
    {
        public static string userName = Login.userName;
        public static string pass = Login.pass;
        public leaderboardUserControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void leaderboardUserControl_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select ROW_NUMBER() OVER(order by teamRating DESC) pos, teamRating, userName, teamName from userinfo order by teamRating DESC", con);
            try
            {
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["pos"], dr["teamRating"], dr["userName"], dr["teamName"]);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
