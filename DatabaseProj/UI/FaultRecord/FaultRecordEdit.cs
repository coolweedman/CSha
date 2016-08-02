using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.FaultRecord {

    public class FaultRecordEdit : DbRecordEditBase {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxParkingSpaceId;
        private System.Windows.Forms.TextBox textBoxFaultCode;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.ComboBox comboBoxFaultCont;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerConfirmTime;

        public CFaultRecordDb.SFaultRecordStru sFaultRecordStru;

        public FaultRecordEdit (string strTitle = "Parking Record Edit") : base( strTitle )
        {
            InitializeComponent();
            dbUiInit();
        }

        public override void dbUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseFaultRecordDesc.Length; i++ ) {
                comboBoxFaultCont.Items.Add( CDbBaseTable.strDbBaseFaultRecordDesc[i] );
            }

            textBoxId.Text = "0";
            textBoxId.Enabled = false;
            textBoxParkingSpaceId.Text = "1";
            textBoxFaultCode.Text = "0";
        }

        public override void dbString2Stru (ref List<string> listRecord)
        {
            int i = 0;

            try {
                sFaultRecordStru.iId = int.Parse( listRecord[i++] );
                sFaultRecordStru.iParkingSpaceId = int.Parse( listRecord[i++] );
                sFaultRecordStru.sStartTime = Convert.ToDateTime( listRecord[i++] );
                sFaultRecordStru.strFaultCont = listRecord[i++];
                sFaultRecordStru.sConfirmTime = Convert.ToDateTime( listRecord[i++] );
                sFaultRecordStru.iFaultId = int.Parse( listRecord[i++] );
                sFaultRecordStru.strComment = listRecord[i++];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            DateTime sDataTimeStart = new DateTime();
            DateTime sDataTimeConfirm = new DateTime();

            try {
                textBoxId.Text = listRecord[i++];
                textBoxParkingSpaceId.Text = listRecord[i++];
                sDataTimeStart = DateTime.Parse( listRecord[i++] );
                comboBoxFaultCont.SelectedIndex = CDbBaseTable.dicDbBaseFaultRecordDesc[listRecord[i++]];
                textBoxFaultCode.Text = listRecord[i++];
                sDataTimeConfirm = DateTime.Parse( listRecord[i++] );
                textBoxComment.Text = listRecord[i++];

                dateTimePickerStartTime.Value = sDataTimeStart;
                dateTimePickerConfirmTime.Value = sDataTimeConfirm;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override void dbStru2Ui ()
        {
            try {
                textBoxId.Text = sFaultRecordStru.iId.ToString();
                textBoxParkingSpaceId.Text = sFaultRecordStru.iParkingSpaceId.ToString();
                dateTimePickerStartTime.Value = sFaultRecordStru.sStartTime;
                comboBoxFaultCont.SelectedIndex = CDbBaseTable.dicDbBaseFaultRecordDesc[ sFaultRecordStru.strFaultCont ];
                textBoxFaultCode.Text = sFaultRecordStru.strFaultCont;
                dateTimePickerConfirmTime.Value = sFaultRecordStru.sConfirmTime;
                textBoxComment.Text = sFaultRecordStru.strComment;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbStru2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override object dbStruGet ()
        {
            return sFaultRecordStru;
        }

        public override void dbUi2Stru ()
        {
            try {
                sFaultRecordStru.iId = int.Parse( textBoxId.Text );
                sFaultRecordStru.iParkingSpaceId = int.Parse( textBoxParkingSpaceId.Text );
                sFaultRecordStru.sStartTime = dateTimePickerStartTime.Value;
                sFaultRecordStru.strFaultCont = CDbBaseTable.strDbBaseFaultRecordDesc[comboBoxFaultCont.SelectedIndex];
                sFaultRecordStru.iFaultId = int.Parse( textBoxFaultCode.Text );
                sFaultRecordStru.sConfirmTime = dateTimePickerConfirmTime.Value;
                sFaultRecordStru.strComment = textBoxComment.Text;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbUi2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override EDbEditUiStat dbUiStatChk ()
        {
            if ( "" == textBoxId.Text ) {
                textBoxId.Select();
                dbUiStatSet( "ID未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxParkingSpaceId.Text ) {
                textBoxParkingSpaceId.Select();
                dbUiStatSet( "停车位ID未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }

            return EDbEditUiStat.DBEDITUISTAT_OK;
        }


        private new void InitializeComponent ()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxParkingSpaceId = new System.Windows.Forms.TextBox();
            this.textBoxFaultCode = new System.Windows.Forms.TextBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.comboBoxFaultCont = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerConfirmTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "停车位ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "开始时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "故障内容";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "代码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "确认时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "备注";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(23, 53);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 10;
            // 
            // textBoxParkingSpaceId
            // 
            this.textBoxParkingSpaceId.Location = new System.Drawing.Point(177, 53);
            this.textBoxParkingSpaceId.Name = "textBoxParkingSpaceId";
            this.textBoxParkingSpaceId.Size = new System.Drawing.Size(100, 28);
            this.textBoxParkingSpaceId.TabIndex = 11;
            // 
            // textBoxFaultCode
            // 
            this.textBoxFaultCode.Location = new System.Drawing.Point(177, 147);
            this.textBoxFaultCode.Name = "textBoxFaultCode";
            this.textBoxFaultCode.Size = new System.Drawing.Size(100, 28);
            this.textBoxFaultCode.TabIndex = 12;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(23, 222);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(100, 28);
            this.textBoxComment.TabIndex = 13;
            // 
            // comboBoxFaultCont
            // 
            this.comboBoxFaultCont.FormattingEnabled = true;
            this.comboBoxFaultCont.Location = new System.Drawing.Point(23, 149);
            this.comboBoxFaultCont.Name = "comboBoxFaultCont";
            this.comboBoxFaultCont.Size = new System.Drawing.Size(121, 26);
            this.comboBoxFaultCont.TabIndex = 14;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(353, 52);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerStartTime.TabIndex = 15;
            // 
            // dateTimePickerConfirmTime
            // 
            this.dateTimePickerConfirmTime.Location = new System.Drawing.Point(353, 149);
            this.dateTimePickerConfirmTime.Name = "dateTimePickerConfirmTime";
            this.dateTimePickerConfirmTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerConfirmTime.TabIndex = 16;
            // 
            // FaultRecordEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(605, 370);
            this.Controls.Add(this.dateTimePickerConfirmTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.comboBoxFaultCont);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.textBoxFaultCode);
            this.Controls.Add(this.textBoxParkingSpaceId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FaultRecordEdit";
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxParkingSpaceId, 0);
            this.Controls.SetChildIndex(this.textBoxFaultCode, 0);
            this.Controls.SetChildIndex(this.textBoxComment, 0);
            this.Controls.SetChildIndex(this.comboBoxFaultCont, 0);
            this.Controls.SetChildIndex(this.dateTimePickerStartTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerConfirmTime, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
