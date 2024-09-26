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
    public partial class frmParticipantDashboard : Form
    {
        public frmParticipantDashboard()
        {
            InitializeComponent();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            frmAddEvent addEvent = new frmAddEvent();
            addEvent.TopLevel = false;
            pnlMain.Controls.Add(addEvent);
            addEvent.Show();
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            frmViewEvents viewEvents = new frmViewEvents();
            pnlMain.Controls.Clear();
            viewEvents.TopLevel = false;
            pnlMain.Controls.Add(viewEvents);
            viewEvents.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            
        }
    }
}
