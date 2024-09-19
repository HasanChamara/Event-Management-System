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
    public partial class frmAddEvent : Form
    {
        public frmAddEvent()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void btnRegister_Click(object sender, EventArgs e)
        {

            string eventName = txtEventName.Text;
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string location = txtLocation.Text;
            string description = txtDescription.Text;
            string capacity = txtCapacity.Text;

            if (eventName != "" && date != "" && location != "" && description != "" && capacity != "")
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO event (event_name, date, location, description, capacity) VALUES (@eventName, @date, @location, @description, @capacity)";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@eventName", eventName);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@location", location);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@capacity", capacity);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Event added successfully!");
                    connection.Close();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
                ClearFields();
            }


        }

        private void ClearFields()
        {
            txtEventName.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtLocation.Text = "";
            txtDescription.Text = "";
            txtCapacity.Text = "";
        }
    }
}
