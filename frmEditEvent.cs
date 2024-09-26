using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EventManagementSystem
{
    public partial class frmEditEvent : Form
    {

        
        public frmEditEvent()
        {
            InitializeComponent();
        }
        

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void frmEditEvent_Load(object sender, EventArgs e)
        {
            // get the event details from the database and display them in the textboxes
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM event WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                int id = Form1.evenId;
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = command.ExecuteReader();
                MessageBox.Show(id.ToString());

                if (reader.Read())
                {
                    txtEventName.Text = reader["event_name"].ToString();
                    txtLocation.Text = reader["location"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(reader["date"]);
                    txtDescription.Text = reader["description"].ToString();
                    txtCapacity.Text = reader["capacity"].ToString();
                }

                connection.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // update the event details in the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE event SET event_name = @event_name, location = @location, date = @date, description = @description, capacity = @capacity WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@event_name", txtEventName.Text);
                command.Parameters.AddWithValue("@location", txtLocation.Text);
                command.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@description", txtDescription.Text);
                command.Parameters.AddWithValue("@capacity", txtCapacity.Text);
                command.Parameters.AddWithValue("@id", Form1.evenId);
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Event updated successfully");
                this.Close();
            }
        }

    }
}
