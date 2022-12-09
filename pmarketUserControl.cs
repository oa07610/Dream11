using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dream11
{
    public partial class pmarketUserControl : UserControl
    {
        static SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=Dream11;Integrated Security=True;MultipleActiveResultSets=true");
        public static string userName = Login.userName;
        public pmarketUserControl()
        {
            InitializeComponent();
            dataGridView1.ForeColor = Color.Black;
            con.Open();
            SqlCommand cmd = new SqlCommand(@"select userBudget from userInfo where userName = '" + userName + "'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                }
                dr.Close();
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

        private void pmarketUserControl_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"select firstname+' '+lastName as [Name], Position, Rating, playerPrice as [Price], Nationality, Pace, Physique, Shoot from playerinfo where userid is NULL order by playerprice", con);
            try
            {
                DataTable dtb1 = new DataTable();
                da.Fill(dtb1);
                dataGridView1.DataSource = dtb1;
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
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.Name = "buttoncolumn";
            buttonCol.HeaderText = "Action";
            buttonCol.Text = "Buy";
            buttonCol.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(buttonCol);
        }

        private void ShowPlayers()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Console.WriteLine(e.ColumnIndex);
            if (e.ColumnIndex == 0)
            {
                var result = MessageBox.Show("Do you wish to buy this player?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var data = dataGridView1.Rows[e.RowIndex];
                    string pname = data.Cells[1].Value.ToString();
                    int pp = Int32.Parse(data.Cells[4].Value.ToString());
                    
                    int bud = Int32.Parse(textBox2.Text);
                    //System.Console.WriteLine(pp);
                    //System.Console.WriteLine(bud);
                    System.Console.WriteLine(pname);
                    if (bud > pp)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(@"Update playerInfo set userID = (select userID from userInfo where userName = '" + userName + "') where firstName+' '+lastName = '" + pname + "'", con);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"update userInfo set userBudget = userBudget - '" + pp + "' where username = '" + userName + "'";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = @"update userInfo set teamRating = (select avg(rating) from playerInfo where userid = (select userid from userInfo where userName = '" + userName + "')) where userName = '" + userName + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Player added to your team.", "Success", MessageBoxButtons.OK);
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
                    else
                    {
                        MessageBox.Show("You don't have enough budget.", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            if (textBox1.Text != "")
            {
                bs.Filter = "Name LIKE '" + textBox1.Text + "%'";
                if (comboBox3.SelectedItem != null)
                {
                    bs.Filter = "Name LIKE '" + textBox1.Text + "%' and position LIKE '" + comboBox3.SelectedItem + "'";

                    if (textBox4.Text != "")
                    {
                        bs.Filter = "Name LIKE '" + textBox1.Text + "%' and position LIKE '" + comboBox3.SelectedItem + "' and Price < '" + textBox4.Text + "'";
                        if (textBox3.Text != "")
                        {
                            bs.Filter = "Name LIKE '" + textBox1.Text + "%' and position LIKE '" + comboBox3.SelectedItem + "' and Price < '" + textBox4.Text + "' and rating > '" + textBox3.Text + "'";
                        }
                    }
                    if (textBox3.Text != "")
                    {
                        bs.Filter = "Name LIKE '" + textBox1.Text + "%' and position LIKE '" + comboBox3.SelectedItem + "' and rating > '" + textBox3.Text + "'";
                    }
                }
            }

            if (comboBox3.SelectedItem != null)
            {
                bs.Filter = "position LIKE '" + comboBox3.SelectedItem + "'";
                if (textBox3.Text != "")
                {
                    bs.Filter = "position LIKE '" + comboBox3.SelectedItem + "' and rating > '" + textBox3.Text + "'";
                }
                if (textBox4.Text != "")
                {
                    bs.Filter = "position LIKE '" + comboBox3.SelectedItem + "' and Price < '" + textBox4.Text + "'";
                }
            }

            if (textBox3.Text != "")
            {
                bs.Filter = "rating > '" + textBox3.Text + "'";
                if (textBox1.Text != "")
                {
                    bs.Filter = "rating > '" + textBox3.Text + "' and Name LIKE '" + textBox1.Text + "%'";
                    if (textBox4.Text != "")
                    {
                        bs.Filter = "rating > '" + textBox3.Text + "'' and Name LIKE '" + textBox1.Text + "%' and Price < '" + textBox4.Text + "'";
                    }
                }
            }

            if (textBox4.Text != "")
            {
                bs.Filter = "Price < '" + textBox4.Text + "'";
                if (textBox1.Text != "")
                {
                    bs.Filter = "rating > '" + textBox3.Text + "' and Name LIKE '" + textBox1.Text + "%'";
                }
                if (textBox3.Text != "")
                {
                    bs.Filter = "Price < '" + textBox4.Text + "' and rating > '" + textBox3.Text + "'";
                    if (comboBox3.SelectedItem != null)
                    {
                        bs.Filter = "Price < '" + textBox4.Text + "' and rating > '" + textBox3.Text + "' and position LIKE '" + comboBox3.SelectedItem + "'";
                    }
                }
            }

            dataGridView1.DataSource = bs.DataSource;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
