using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EventManagementSystem
{
    public partial class frmViewEvents : Form
    {
        public frmViewEvents()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void frmViewEvents_Load(object sender, EventArgs e)
        {
            // retrieve event details and display them in the datagridview

            if (this.InvokeRequired) {
                this.Invoke(new MethodInvoker(delegate {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT id, event_name, location, DATE_FORMAT(date, '%Y-%m-%d') as event_date, description, capacity FROM event";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            dataGridViewEvents.Rows.Add(
                                reader["id"].ToString(),
                                reader["event_name"].ToString(),
                                reader["location"].ToString(),
                                reader["event_date"].ToString(),
                                reader["description"].ToString(),
                                reader["capacity"].ToString()
                            );
                        }

                        connection.Close();
                    }
                }));
            } else {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, event_name, location, DATE_FORMAT(date, '%Y-%m-%d') as event_date, description, capacity FROM event";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridViewEvents.Rows.Add(
                            reader["id"].ToString(),
                            reader["event_name"].ToString(),
                            reader["location"].ToString(),
                            reader["event_date"].ToString(),
                            reader["description"].ToString(),
                            reader["capacity"].ToString()
                        );
                    }

                    connection.Close();
                }
            }
        }
    }
}
