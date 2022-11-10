using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dream11
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
            txtconfirmpassword.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName, pass, confirmPass;

            userName = txtusername.Text;
            pass = txtpassword.Text;
            confirmPass = txtconfirmpassword.Text;

            SqlConnection con = new SqlConnection(@"Data Source=ABYSS\DBS;Initial Catalog=test;Integrated Security=True");
            con.Open();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (pass == confirmPass)
                {
                    SqlCommand cmd = new SqlCommand("select * from test_login where username='" + userName + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username already exists. Please try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand(@"Insert into test_login(username, password) values('" + userName + "', '" + pass + "')", con);
                        try
                        { 
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Your account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show("Passwords don't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
                txtconfirmpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
                txtconfirmpassword.UseSystemPasswordChar = true;
            }
        }
    }
}
