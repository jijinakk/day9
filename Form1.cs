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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SigninFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VOHCB4I\SQLEXPRESS;Initial Catalog=Signin;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void ugguh_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = textBox1.Text;
            user_password = textBox2.Text;
            try
            {
                String queryy = "select * from Signin where username='" + textBox1.Text + "' AND password= '" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(queryy, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    user_password = textBox2.Text;
                    Home form2 = new Home();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid details", "error", MessageBoxButtons.OK);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();


                }
            }
            catch
            {
                MessageBox.Show("error");

            }
            finally
            {
                conn.Close();

            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
