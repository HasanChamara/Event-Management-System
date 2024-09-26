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
    public partial class Form1 : Form
    {

        public static int evenId;
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void Form1_Load(object sender, EventArgs e)
        {
            // retrieve event details and display them in the datagridview
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

            // retrieve participant details and display them in the datagridview
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM participant";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    dataGridViewParticipants.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["phone"].ToString(), reader["address"].ToString());
                }

                connection.Close();
            }

        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == 6)
            {
                // edit event
                evenId = Convert.ToInt32(dataGridViewEvents.Rows[e.RowIndex].Cells[0].Value);
                frmEditEvent editEvent = new frmEditEvent();
                editEvent.ShowDialog();
                
                
            }
            else if (e.ColumnIndex == 7)
            {
                // delete event
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this event?", "Delete Event", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "DELETE FROM event WHERE id = @id";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", dataGridViewEvents.Rows[e.RowIndex].Cells[0].Value.ToString());
                        command.ExecuteNonQuery();

                        connection.Close();
                    }

                    dataGridViewEvents.Rows.RemoveAt(e.RowIndex);
                }
                
            }
        }
    }


}
