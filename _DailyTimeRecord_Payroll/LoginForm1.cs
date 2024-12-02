using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _DailyTimeRecord_Payroll
{
    public partial class LoginForm1 : Form
    {
        private string connectionString = "Data Source = LOCALHOST\\SQLEXPRESS;Initial Catalog=DTR;Integrated Security=True";
        public LoginForm1()
        {
            InitializeComponent();
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
        }
        private void LoginForm1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.userName != string.Empty)
            {
                txtUsername.Text = Properties.Settings.Default.userName;
                txtPassword.Text = Properties.Settings.Default.passUser;
                checkRemember.Checked = true;
            }
            txtPassword.Enabled = true;
            txtUsername.Enabled = true;
            txtUsername.Focus();
            if (cbShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
                cbShowPass.Text = "Hide";
            }
            else
            {
                //Hides Textbox password
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
                cbShowPass.Text = "Show";
            }
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Username,Role FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    command.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    SqlDataAdapter adapter;
                    DataTable DSorlist = new DataTable();
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(DSorlist);
                    if (DSorlist.Rows.Count <= 0)
                    {
                        MessageBox.Show("Invalid Username!");
                        Properties.Settings.Default.userName = string.Empty;
                        Properties.Settings.Default.passUser = string.Empty;
                        Properties.Settings.Default.Save();
                        checkRemember.Checked = false;
                        txtPassword.Text = string.Empty;
                        txtUsername.Select();
                        return;
                    }
                    foreach (DataRow row in DSorlist.Rows)
                    {
                        globalnames.gblusername = row["Username"].ToString();
                        if (row["Role"].ToString() == "admin")
                        {
                            AdminDashboardTwo adminDashboardForm = new AdminDashboardTwo();
                            adminDashboardForm.Show();
                            this.Hide();
                        }
                        else if (row["Role"].ToString() == "employee")
                        {
                            EmployeeDashboardForm employeeDashboardForm = new EmployeeDashboardForm();
                            employeeDashboardForm.Show();
                            this.Hide();
                        }
                        
                    }
                    if (checkRemember.Checked)
                    {
                        Properties.Settings.Default.userName = txtUsername.Text.Trim();
                        Properties.Settings.Default.passUser = txtPassword.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.userName = string.Empty;
                        Properties.Settings.Default.passUser = string.Empty;
                        Properties.Settings.Default.Save();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
                cbShowPass.Text = "Hide";
            }
            else
            {
                //Hides Textbox password
                txtPassword.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
                cbShowPass.Text = "Show";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed
                txtPassword.Focus();
                try
                {
                    return;
                }
                catch (Exception) { }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed
                btnLogin.Focus();
                try
                {
                    return;
                }
                catch (Exception) { }
            }
        }
    }
}
