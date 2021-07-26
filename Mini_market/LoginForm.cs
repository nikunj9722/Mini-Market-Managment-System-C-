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
namespace Mini_market
{
    public partial class LoginForm : Form
    {
        DBConnect dBCon = new DBConnect();
        public static string SellerName;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Goldenrod;
        }

        private void label_clear_MouseEnter(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Red;
        }

        private void label_clear_MouseLeave(object sender, EventArgs e)
        {
            label_clear.ForeColor = Color.Goldenrod;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_clear_Click(object sender, EventArgs e)
        {
            TextBox_username.Clear();
            TextBox_password.Clear();

        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_username.Text == "" || TextBox_password.Text == "")
            {
                MessageBox.Show("Please Enter UserName And Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                if (comboBox_role.SelectedIndex > -1)
                {
                    if (comboBox_role.SelectedItem.ToString() == "ADMIN")
                    {
                        if (TextBox_username.Text == "Nikunj" && TextBox_password.Text == "Nikunj123")
                        {
                            ProductForm product = new ProductForm();
                            product.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("If you are Admin, Please Enter the correct ID and Password", "Missing Id", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        string selectQuery = "SELECT * FROM Seller WHERE SellerName='" + TextBox_username.Text + "' AND SellerPass='" + TextBox_password.Text + "'";

                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, dBCon.GetCon());
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            SellerName = TextBox_username.Text;
                            SellingForm selling = new SellingForm();
                            selling.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
                else
                {

                    MessageBox.Show("Please Select Role", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
