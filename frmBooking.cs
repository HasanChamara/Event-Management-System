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
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";
        private void frmBooking_Load(object sender, EventArgs e)
        {
            // retrieve event names to the combobox using a while loop and a datareader object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM event";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboEvents.Items.Add(reader["event_name"].ToString());
                }

                connection.Close();
            }
        }

        private void comboEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
           // get the selected event.
            comboEvents.SelectedItem.ToString();

            // get the event id of the selected event.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id FROM event WHERE event_name = '" + comboEvents.SelectedItem.ToString() + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    frmBook.eventID = Convert.ToInt32(reader["id"]);
                }

                connection.Close();
            }

            // get the event participants of the selected event
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM participant WHERE id IN (SELECT participant_id FROM event_participant WHERE event_id = " + frmBook.eventID + ")";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                //clear data grid view
                dataGridViewEventParticipant.Rows.Clear();

                while (reader.Read())
                {
                    dataGridViewEventParticipant.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["phone"].ToString(), reader["address"].ToString());
                }

                connection.Close();
            }
             
        }
    }
}
