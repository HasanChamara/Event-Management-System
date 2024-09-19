namespace EventManagementSystem
{
    partial class frmAdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnAddParticipant = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnBook = new System.Windows.Forms.Button();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.PowderBlue;
            this.pnlSide.Controls.Add(this.btnBook);
            this.pnlSide.Controls.Add(this.btnAddParticipant);
            this.pnlSide.Controls.Add(this.btnAddEvent);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(220, 643);
            this.pnlSide.TabIndex = 0;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.Location = new System.Drawing.Point(0, 70);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(220, 40);
            this.btnAddEvent.TabIndex = 0;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnAddParticipant
            // 
            this.btnAddParticipant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParticipant.Location = new System.Drawing.Point(0, 116);
            this.btnAddParticipant.Name = "btnAddParticipant";
            this.btnAddParticipant.Size = new System.Drawing.Size(220, 40);
            this.btnAddParticipant.TabIndex = 1;
            this.btnAddParticipant.Text = "Add Participant";
            this.btnAddParticipant.UseVisualStyleBackColor = true;
            this.btnAddParticipant.Click += new System.EventHandler(this.btnAddParticipant_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(220, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(823, 643);
            this.pnlMain.TabIndex = 1;
            // 
            // btnBook
            // 
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Location = new System.Drawing.Point(0, 163);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(220, 40);
            this.btnBook.TabIndex = 2;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 643);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminDashboard";
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnAddParticipant;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnBook;
    }
}