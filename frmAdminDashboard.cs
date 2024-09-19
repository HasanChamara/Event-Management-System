using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            frmAddEvent frmAddEvent = new frmAddEvent();
            frmAddEvent.TopLevel = false;
            frmAddEvent.AutoScroll = true;
            pnlMain.Controls.Add(frmAddEvent);
            frmAddEvent.Show();
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            frmAddParticipant frmAddParticipant = new frmAddParticipant();
            frmAddParticipant.TopLevel = false;
            frmAddParticipant.AutoScroll = true;
            pnlMain.Controls.Add(frmAddParticipant);
            frmAddParticipant.Show();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            frmBook frmBook = new frmBook();
            frmBook.TopLevel = false;
            frmBook.AutoScroll = true;
            pnlMain.Controls.Add(frmBook);
            frmBook.Show();
        }
    }
}
