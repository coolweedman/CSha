namespace DatabaseProj.UI {
    partial class RegularCardPaymentEdit {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxRcuId = new System.Windows.Forms.TextBox();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.dateTimePickerPayTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVaildTime = new System.Windows.Forms.DateTimePicker();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "固定卡ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "付款时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "有效时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "付款金额";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(44, 68);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 5;
            // 
            // textBoxRcuId
            // 
            this.textBoxRcuId.Location = new System.Drawing.Point(203, 68);
            this.textBoxRcuId.Name = "textBoxRcuId";
            this.textBoxRcuId.Size = new System.Drawing.Size(100, 28);
            this.textBoxRcuId.TabIndex = 6;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(356, 68);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 7;
            // 
            // dateTimePickerPayTime
            // 
            this.dateTimePickerPayTime.Location = new System.Drawing.Point(44, 176);
            this.dateTimePickerPayTime.Name = "dateTimePickerPayTime";
            this.dateTimePickerPayTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTime.TabIndex = 8;
            // 
            // dateTimePickerVaildTime
            // 
            this.dateTimePickerVaildTime.Location = new System.Drawing.Point(356, 175);
            this.dateTimePickerVaildTime.Name = "dateTimePickerVaildTime";
            this.dateTimePickerVaildTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerVaildTime.TabIndex = 9;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(176, 237);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 35);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(305, 237);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 35);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // RegularCardPaymentEdit
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(629, 313);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dateTimePickerVaildTime);
            this.Controls.Add(this.dateTimePickerPayTime);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxRcuId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegularCardPaymentEdit";
            this.Text = "RegularCardPaymentEdit";
            this.Load += new System.EventHandler(this.RegularCardPaymentEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxRcuId;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerVaildTime;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}