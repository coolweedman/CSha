namespace DatabaseProj.UI {
    partial class ParkingSpaceQueryUi {
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.checkBoxLockStat = new System.Windows.Forms.CheckBox();
            this.comboBoxLockStat = new System.Windows.Forms.ComboBox();
            this.checkBoxSpaceType = new System.Windows.Forms.CheckBox();
            this.comboBoxSpaceType = new System.Windows.Forms.ComboBox();
            this.checkBoxSpaceAera = new System.Windows.Forms.CheckBox();
            this.comboBoxSpaceAera = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 123);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(833, 292);
            this.dataGridView.TabIndex = 0;
            // 
            // checkBoxLockStat
            // 
            this.checkBoxLockStat.AutoSize = true;
            this.checkBoxLockStat.Location = new System.Drawing.Point(29, 13);
            this.checkBoxLockStat.Name = "checkBoxLockStat";
            this.checkBoxLockStat.Size = new System.Drawing.Size(106, 22);
            this.checkBoxLockStat.TabIndex = 1;
            this.checkBoxLockStat.Text = "车位状态";
            this.checkBoxLockStat.UseVisualStyleBackColor = true;
            // 
            // comboBoxLockStat
            // 
            this.comboBoxLockStat.FormattingEnabled = true;
            this.comboBoxLockStat.Location = new System.Drawing.Point(29, 67);
            this.comboBoxLockStat.Name = "comboBoxLockStat";
            this.comboBoxLockStat.Size = new System.Drawing.Size(121, 26);
            this.comboBoxLockStat.TabIndex = 2;
            // 
            // checkBoxSpaceType
            // 
            this.checkBoxSpaceType.AutoSize = true;
            this.checkBoxSpaceType.Location = new System.Drawing.Point(265, 12);
            this.checkBoxSpaceType.Name = "checkBoxSpaceType";
            this.checkBoxSpaceType.Size = new System.Drawing.Size(106, 22);
            this.checkBoxSpaceType.TabIndex = 3;
            this.checkBoxSpaceType.Text = "车位类型";
            this.checkBoxSpaceType.UseVisualStyleBackColor = true;
            // 
            // comboBoxSpaceType
            // 
            this.comboBoxSpaceType.FormattingEnabled = true;
            this.comboBoxSpaceType.Location = new System.Drawing.Point(265, 65);
            this.comboBoxSpaceType.Name = "comboBoxSpaceType";
            this.comboBoxSpaceType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceType.TabIndex = 4;
            // 
            // checkBoxSpaceAera
            // 
            this.checkBoxSpaceAera.AutoSize = true;
            this.checkBoxSpaceAera.Location = new System.Drawing.Point(518, 12);
            this.checkBoxSpaceAera.Name = "checkBoxSpaceAera";
            this.checkBoxSpaceAera.Size = new System.Drawing.Size(106, 22);
            this.checkBoxSpaceAera.TabIndex = 5;
            this.checkBoxSpaceAera.Text = "车位分区";
            this.checkBoxSpaceAera.UseVisualStyleBackColor = true;
            // 
            // comboBoxSpaceAera
            // 
            this.comboBoxSpaceAera.FormattingEnabled = true;
            this.comboBoxSpaceAera.Location = new System.Drawing.Point(518, 66);
            this.comboBoxSpaceAera.Name = "comboBoxSpaceAera";
            this.comboBoxSpaceAera.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceAera.TabIndex = 6;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.Location = new System.Drawing.Point(242, 443);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(96, 35);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(428, 443);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 35);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ParkingSpaceQueryUi
            // 
            this.AcceptButton = this.buttonCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOk;
            this.ClientSize = new System.Drawing.Size(857, 490);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxSpaceAera);
            this.Controls.Add(this.checkBoxSpaceAera);
            this.Controls.Add(this.comboBoxSpaceType);
            this.Controls.Add(this.checkBoxSpaceType);
            this.Controls.Add(this.comboBoxLockStat);
            this.Controls.Add(this.checkBoxLockStat);
            this.Controls.Add(this.dataGridView);
            this.Name = "ParkingSpaceQueryUi";
            this.Text = "ParkingSpaceQueryUi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox checkBoxLockStat;
        private System.Windows.Forms.ComboBox comboBoxLockStat;
        private System.Windows.Forms.CheckBox checkBoxSpaceType;
        private System.Windows.Forms.ComboBox comboBoxSpaceType;
        private System.Windows.Forms.CheckBox checkBoxSpaceAera;
        private System.Windows.Forms.ComboBox comboBoxSpaceAera;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}