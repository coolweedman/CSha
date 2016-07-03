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
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDefaultTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBATableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardUserToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardPaymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingSpaceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dbViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularCardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.dbViewToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(383, 32);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
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
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBATableToolStripMenuItem,
            this.regularCardUserToolStripMenuItem1,
            this.regularCardPaymentToolStripMenuItem1,
            this.parkingSpaceToolStripMenuItem1,
            this.parkingRecordToolStripMenuItem1});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(69, 28);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // dBATableToolStripMenuItem
            // 
            this.dBATableToolStripMenuItem.Name = "dBATableToolStripMenuItem";
            this.dBATableToolStripMenuItem.Size = new System.Drawing.Size(277, 30);
            this.dBATableToolStripMenuItem.Text = "DBATable";
            this.dBATableToolStripMenuItem.Click += new System.EventHandler(this.dBATableToolStripMenuItem_Click);
            // 
            // regularCardUserToolStripMenuItem1
            // 
            this.regularCardUserToolStripMenuItem1.Name = "regularCardUserToolStripMenuItem1";
            this.regularCardUserToolStripMenuItem1.Size = new System.Drawing.Size(277, 30);
            this.regularCardUserToolStripMenuItem1.Text = "RegularCardUser";
            this.regularCardUserToolStripMenuItem1.Click += new System.EventHandler(this.regularCardUserToolStripMenuItem1_Click);
            // 
            // regularCardPaymentToolStripMenuItem1
            // 
            this.regularCardPaymentToolStripMenuItem1.Name = "regularCardPaymentToolStripMenuItem1";
            this.regularCardPaymentToolStripMenuItem1.Size = new System.Drawing.Size(277, 30);
            this.regularCardPaymentToolStripMenuItem1.Text = "RegularCardPayment";
            this.regularCardPaymentToolStripMenuItem1.Click += new System.EventHandler(this.regularCardPaymentToolStripMenuItem1_Click);
            // 
            // parkingSpaceToolStripMenuItem1
            // 
            this.parkingSpaceToolStripMenuItem1.Name = "parkingSpaceToolStripMenuItem1";
            this.parkingSpaceToolStripMenuItem1.Size = new System.Drawing.Size(277, 30);
            this.parkingSpaceToolStripMenuItem1.Text = "ParkingSpace";
            this.parkingSpaceToolStripMenuItem1.Click += new System.EventHandler(this.parkingSpaceToolStripMenuItem1_Click);
            // 
            // parkingRecordToolStripMenuItem1
            // 
            this.parkingRecordToolStripMenuItem1.Name = "parkingRecordToolStripMenuItem1";
            this.parkingRecordToolStripMenuItem1.Size = new System.Drawing.Size(277, 30);
            this.parkingRecordToolStripMenuItem1.Text = "ParkingRecord";
            this.parkingRecordToolStripMenuItem1.Click += new System.EventHandler(this.parkingRecordToolStripMenuItem1_Click);
            // 
            // dbViewToolStripMenuItem
            // 
            this.dbViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularCardToolStripMenuItem1});
            this.dbViewToolStripMenuItem.Name = "dbViewToolStripMenuItem";
            this.dbViewToolStripMenuItem.Size = new System.Drawing.Size(89, 28);
            this.dbViewToolStripMenuItem.Text = "DbView";
            // 
            // regularCardToolStripMenuItem1
            // 
            this.regularCardToolStripMenuItem1.Name = "regularCardToolStripMenuItem1";
            this.regularCardToolStripMenuItem1.Size = new System.Drawing.Size(211, 30);
            this.regularCardToolStripMenuItem1.Text = "RegularCard";
            this.regularCardToolStripMenuItem1.Click += new System.EventHandler(this.regularCardToolStripMenuItem1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(119, 236);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(87, 38);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(383, 325);
            this.Controls.Add(this.buttonClose);
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
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDefaultTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBATableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularCardUserToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem regularCardPaymentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parkingSpaceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parkingRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dbViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularCardToolStripMenuItem1;
        private System.Windows.Forms.Button buttonClose;
    }
}