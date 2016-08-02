using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.FaultRecord {

    public class FaultRecordQuery : DbRecordQueryBase {
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxParkingSpace;
        private System.Windows.Forms.CheckBox checkBoxStartTime;
        private System.Windows.Forms.CheckBox checkBoxFaultCont;
        private System.Windows.Forms.CheckBox checkBoxFaultId;
        private System.Windows.Forms.CheckBox checkBoxConfirmTime;
        private System.Windows.Forms.TextBox textBoxParkingSpace;
        private System.Windows.Forms.TextBox textBoxFaultId;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerConfirmTime;
        private System.Windows.Forms.ComboBox comboBoxFaultCont;
        private System.Windows.Forms.TextBox textBoxId;

        protected CFaultRecordDb.SFaultRecordQueryStru sQueryStru;

        public FaultRecordQuery (CDatebaseBase hDbTableBase, string strTitle = "Fault Record Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        protected override void dbRecordQueryUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseFaultRecordDesc.Length; i++ ) {
                comboBoxFaultCont.Items.Add( CDbBaseTable.strDbBaseFaultRecordDesc[i] );
            }
        }

        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bParkingSpaceIdEn = checkBoxParkingSpace.Checked;
            sQueryStru.bStartTimeEn = checkBoxStartTime.Checked;
            sQueryStru.bFaultContEn = checkBoxFaultCont.Checked;
            sQueryStru.bConfirmTime = checkBoxConfirmTime.Checked;
            sQueryStru.bFaultIdEn = checkBoxFaultId.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bParkingSpaceIdEn ) {
                sQueryStru.iParkingSpaceId = int.Parse( textBoxParkingSpace.Text );
            }
            if ( sQueryStru.bStartTimeEn ) {
                sQueryStru.sStartTime = dateTimePickerStartTime.Value;
            }
            if ( sQueryStru.bFaultContEn ) {
                sQueryStru.strFaultCont = CDbBaseTable.strDbBaseFaultRecordDesc[comboBoxFaultCont.SelectedIndex];
            }
            if ( sQueryStru.bConfirmTime ) {
                sQueryStru.sConfirmTime = dateTimePickerConfirmTime.Value;
            }
            if ( sQueryStru.bFaultIdEn ) {
                sQueryStru.iFaultId = int.Parse( textBoxFaultId.Text );
            }

            return sQueryStru;
        }


        private void InitializeComponent ()
        {
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxParkingSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxStartTime = new System.Windows.Forms.CheckBox();
            this.checkBoxFaultCont = new System.Windows.Forms.CheckBox();
            this.checkBoxFaultId = new System.Windows.Forms.CheckBox();
            this.checkBoxConfirmTime = new System.Windows.Forms.CheckBox();
            this.textBoxParkingSpace = new System.Windows.Forms.TextBox();
            this.textBoxFaultId = new System.Windows.Forms.TextBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerConfirmTime = new System.Windows.Forms.DateTimePicker();
            this.comboBoxFaultCont = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(12, 22);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 32;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 59);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 31;
            // 
            // checkBoxParkingSpace
            // 
            this.checkBoxParkingSpace.AutoSize = true;
            this.checkBoxParkingSpace.Location = new System.Drawing.Point(271, 22);
            this.checkBoxParkingSpace.Name = "checkBoxParkingSpace";
            this.checkBoxParkingSpace.Size = new System.Drawing.Size(106, 22);
            this.checkBoxParkingSpace.TabIndex = 33;
            this.checkBoxParkingSpace.Text = "停车位ID";
            this.checkBoxParkingSpace.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartTime
            // 
            this.checkBoxStartTime.AutoSize = true;
            this.checkBoxStartTime.Location = new System.Drawing.Point(550, 23);
            this.checkBoxStartTime.Name = "checkBoxStartTime";
            this.checkBoxStartTime.Size = new System.Drawing.Size(106, 22);
            this.checkBoxStartTime.TabIndex = 34;
            this.checkBoxStartTime.Text = "发生时间";
            this.checkBoxStartTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxFaultCont
            // 
            this.checkBoxFaultCont.AutoSize = true;
            this.checkBoxFaultCont.Location = new System.Drawing.Point(13, 115);
            this.checkBoxFaultCont.Name = "checkBoxFaultCont";
            this.checkBoxFaultCont.Size = new System.Drawing.Size(106, 22);
            this.checkBoxFaultCont.TabIndex = 35;
            this.checkBoxFaultCont.Text = "故障内容";
            this.checkBoxFaultCont.UseVisualStyleBackColor = true;
            // 
            // checkBoxFaultId
            // 
            this.checkBoxFaultId.AutoSize = true;
            this.checkBoxFaultId.Location = new System.Drawing.Point(550, 115);
            this.checkBoxFaultId.Name = "checkBoxFaultId";
            this.checkBoxFaultId.Size = new System.Drawing.Size(106, 22);
            this.checkBoxFaultId.TabIndex = 36;
            this.checkBoxFaultId.Text = "故障代码";
            this.checkBoxFaultId.UseVisualStyleBackColor = true;
            // 
            // checkBoxConfirmTime
            // 
            this.checkBoxConfirmTime.AutoSize = true;
            this.checkBoxConfirmTime.Location = new System.Drawing.Point(271, 115);
            this.checkBoxConfirmTime.Name = "checkBoxConfirmTime";
            this.checkBoxConfirmTime.Size = new System.Drawing.Size(106, 22);
            this.checkBoxConfirmTime.TabIndex = 37;
            this.checkBoxConfirmTime.Text = "确认时间";
            this.checkBoxConfirmTime.UseVisualStyleBackColor = true;
            // 
            // textBoxParkingSpace
            // 
            this.textBoxParkingSpace.Location = new System.Drawing.Point(271, 59);
            this.textBoxParkingSpace.Name = "textBoxParkingSpace";
            this.textBoxParkingSpace.Size = new System.Drawing.Size(100, 28);
            this.textBoxParkingSpace.TabIndex = 38;
            // 
            // textBoxFaultId
            // 
            this.textBoxFaultId.Location = new System.Drawing.Point(550, 161);
            this.textBoxFaultId.Name = "textBoxFaultId";
            this.textBoxFaultId.Size = new System.Drawing.Size(100, 28);
            this.textBoxFaultId.TabIndex = 39;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(550, 59);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerStartTime.TabIndex = 40;
            // 
            // dateTimePickerConfirmTime
            // 
            this.dateTimePickerConfirmTime.Location = new System.Drawing.Point(271, 163);
            this.dateTimePickerConfirmTime.Name = "dateTimePickerConfirmTime";
            this.dateTimePickerConfirmTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerConfirmTime.TabIndex = 41;
            // 
            // comboBoxFaultCont
            // 
            this.comboBoxFaultCont.FormattingEnabled = true;
            this.comboBoxFaultCont.Location = new System.Drawing.Point(13, 163);
            this.comboBoxFaultCont.Name = "comboBoxFaultCont";
            this.comboBoxFaultCont.Size = new System.Drawing.Size(121, 26);
            this.comboBoxFaultCont.TabIndex = 42;
            // 
            // FaultRecordQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1103, 667);
            this.Controls.Add(this.comboBoxFaultCont);
            this.Controls.Add(this.dateTimePickerConfirmTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.textBoxFaultId);
            this.Controls.Add(this.textBoxParkingSpace);
            this.Controls.Add(this.checkBoxConfirmTime);
            this.Controls.Add(this.checkBoxFaultId);
            this.Controls.Add(this.checkBoxFaultCont);
            this.Controls.Add(this.checkBoxStartTime);
            this.Controls.Add(this.checkBoxParkingSpace);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.textBoxId);
            this.Name = "FaultRecordQuery";
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxParkingSpace, 0);
            this.Controls.SetChildIndex(this.checkBoxStartTime, 0);
            this.Controls.SetChildIndex(this.checkBoxFaultCont, 0);
            this.Controls.SetChildIndex(this.checkBoxFaultId, 0);
            this.Controls.SetChildIndex(this.checkBoxConfirmTime, 0);
            this.Controls.SetChildIndex(this.textBoxParkingSpace, 0);
            this.Controls.SetChildIndex(this.textBoxFaultId, 0);
            this.Controls.SetChildIndex(this.dateTimePickerStartTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerConfirmTime, 0);
            this.Controls.SetChildIndex(this.comboBoxFaultCont, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
