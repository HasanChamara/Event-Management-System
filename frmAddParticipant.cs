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
    public partial class frmAddParticipant : Form
    {
        public frmAddParticipant()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;user=root;database=eventmanagement;port=3306;password=Chamara.19566";

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            //get the values from the textboxes

            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            //check if all the fields are filleds
            if (name != "" && email != "" && phone != "" && address != "")
            {
                //insert the data into the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO participant (name, email, phone, address) VALUES (@name, @email, @phone, @address)";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Participant added successfully!");
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
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }
    }
}
