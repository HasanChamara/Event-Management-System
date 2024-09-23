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
using MySql.Data.MySqlClient;

namespace EventManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (ValidateLogin(username, password))
            {
                // Navigate to the respective dashboard based on the user's role
                User user = GetUserDetails(username, password);

                if (user != null)
                {
                    if (user.Role == "admin")
                    {
                        //MessageBox.Show("Admin login successful!");
                        this.Hide();
                        frmAdminDashboard adminDashboard = new frmAdminDashboard();
                        adminDashboard.Show();
                    }
                    else if (user.Role == "participant")
                    {
                        MessageBox.Show("Participant login successful!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in both username and password.");
            }

        }

        private bool ValidateLogin(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        // Method to retrieve user details from the database
        private User GetUserDetails(string username, string password)
        {
            User user = null;

            // Using a MySQL connection
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // SQL query to check login
                    string sql = "SELECT username, role FROM Users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // If a matching user is found
                            {
                                user = new User
                                {
                                    Username = reader["username"].ToString(),
                                    Role = reader["role"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while logging in: " + ex.Message);
                }
            }

            return user;
        }
    }
}

public class User
{
    public string Username { get; set; }
    public string Role { get; set; }
}
