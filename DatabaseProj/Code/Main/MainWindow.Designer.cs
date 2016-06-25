namespace DatabaseProj.Code.Main {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDefaultTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(278, 32);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularCardUserToolStripMenuItem,
            this.regularCardPaymentToolStripMenuItem,
            this.parkingSpaceToolStripMenuItem,
            this.dBAccountToolStripMenuItem,
            this.parkingRecordToolStripMenuItem,
            this.regularCardToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(63, 28);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // regularCardUserToolStripMenuItem
            // 
            this.regularCardUserToolStripMenuItem.Name = "regularCardUserToolStripMenuItem";
            this.regularCardUserToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.regularCardUserToolStripMenuItem.Text = "RegularCardUser";
            this.regularCardUserToolStripMenuItem.Click += new System.EventHandler(this.regularCardUserToolStripMenuItem_Click_1);
            // 
            // regularCardPaymentToolStripMenuItem
            // 
            this.regularCardPaymentToolStripMenuItem.Name = "regularCardPaymentToolStripMenuItem";
            this.regularCardPaymentToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.regularCardPaymentToolStripMenuItem.Text = "RegularCardPayment";
            this.regularCardPaymentToolStripMenuItem.Click += new System.EventHandler(this.regularCardPaymentToolStripMenuItem_Click);
            // 
            // parkingSpaceToolStripMenuItem
            // 
            this.parkingSpaceToolStripMenuItem.Name = "parkingSpaceToolStripMenuItem";
            this.parkingSpaceToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.parkingSpaceToolStripMenuItem.Text = "ParkingSpace";
            this.parkingSpaceToolStripMenuItem.Click += new System.EventHandler(this.parkingSpaceToolStripMenuItem_Click);
            // 
            // dBAccountToolStripMenuItem
            // 
            this.dBAccountToolStripMenuItem.Name = "dBAccountToolStripMenuItem";
            this.dBAccountToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.dBAccountToolStripMenuItem.Text = "DBAccount";
            this.dBAccountToolStripMenuItem.Click += new System.EventHandler(this.dBAccountToolStripMenuItem_Click);
            // 
            // parkingRecordToolStripMenuItem
            // 
            this.parkingRecordToolStripMenuItem.Name = "parkingRecordToolStripMenuItem";
            this.parkingRecordToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.parkingRecordToolStripMenuItem.Text = "ParkingRecord";
            this.parkingRecordToolStripMenuItem.Click += new System.EventHandler(this.parkingRecordToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDefaultTableToolStripMenuItem,
            this.logInToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(103, 28);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // createDefaultTableToolStripMenuItem
            // 
            this.createDefaultTableToolStripMenuItem.Name = "createDefaultTableToolStripMenuItem";
            this.createDefaultTableToolStripMenuItem.Size = new System.Drawing.Size(259, 30);
            this.createDefaultTableToolStripMenuItem.Text = "CreateDefaultTable";
            this.createDefaultTableToolStripMenuItem.Click += new System.EventHandler(this.createDefaultTableToolStripMenuItem_Click);
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(259, 30);
            this.logInToolStripMenuItem.Text = "LogIn";
            this.logInToolStripMenuItem.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // regularCardToolStripMenuItem
            // 
            this.regularCardToolStripMenuItem.Name = "regularCardToolStripMenuItem";
            this.regularCardToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.regularCardToolStripMenuItem.Text = "RegularCard";
            this.regularCardToolStripMenuItem.Click += new System.EventHandler(this.regularCardToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularCardUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularCardPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parkingSpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parkingRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDefaultTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularCardToolStripMenuItem;
    }
}