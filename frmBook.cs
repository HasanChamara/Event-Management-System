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

namespace EventManagementSystem
{
    
    public partial class frmBook : Form
    {
        public static int eventID;

        public frmBook()
        {
            InitializeComponent();
        }

        

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        // retrieve the event details from the database and display them in the datagridview

        public string ConnectionString
            {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            // retrieve event details row by row and display them in the datagridview using a while loop and a datareader object and column by column using the Cells property of the datagridview
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM event";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridViewEvent.Rows.Add(reader["id"].ToString(), reader["event_name"].ToString(), reader["location"].ToString(), reader["date"].ToString(), reader["description"].ToString(), reader["capacity"].ToString());
                }

                connection.Close();
            }

        }

        private void dataGridViewEvent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // when click the book image column, the selected event id assigned to the event id variable.
            if (e.ColumnIndex == 6)
            {
                eventID = Convert.ToInt32(dataGridViewEvent.Rows[e.RowIndex].Cells[0].Value);
                frmAddParticipantToEvent frmAddParticipantToEvent = new frmAddParticipantToEvent();
                frmAddParticipantToEvent.ShowDialog();
            }
        }
    }
}
