using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace EventManagementSystem
{
    public partial class frmAddParticipantToEvent : Form
    {
        

        public frmAddParticipantToEvent()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void frmAddParticipantToEvent_Load(object sender, EventArgs e)
        {
            


            // retrieve participant details row by row and display them in the datagridview using a while loop and a datareader object and column by column using the Cells property of the datagridview
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM participant";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridViewParticipant.Rows.Add(reader["id"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["phone"].ToString(), reader["address"].ToString());
                }

                connection.Close();
            }


        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmBook frmBook = new frmBook();
            frmBook.Show();

        }

        private void btnAddToEvent_Click(object sender, EventArgs e)
        {
            List<int> selectedRowIds = new List<int>();

            foreach (DataGridViewRow row in dataGridViewParticipant.SelectedRows)
            {
                selectedRowIds.Add(Convert.ToInt32(row.Cells[0].Value));
            }


            if (selectedRowIds.Count > 0)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (int id in selectedRowIds)
                    {
                        string query = "INSERT INTO event_participant (event_id, participant_id) VALUES (@eventID, @participantID)";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        command.Parameters.AddWithValue("@eventID", frmBook.eventID);
                        command.Parameters.AddWithValue("@participantID", id);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Participants added to the event successfully!");
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select participants to add to the event.");
            }

        }
    }
}
