using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI.RegularCardPaymentUi {

    public class RegularCardPaymentEdit : DbRecordEditBase {

        private System.Windows.Forms.DateTimePicker dateTimePickerVaildTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTime;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxRcuId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        protected CRegularCardPaymentDb.SRegularCardPaymentStru sRcpStru;

        public RegularCardPaymentEdit (string strTitle = "Regular Card Payment Edit") : base( strTitle )
        {
            InitializeComponent();
            dbUiInit();
        }

        public override void dbUiInit ()
        {
            textBoxId.Text = "0";
            textBoxId.Enabled = false;
        }

        public override void dbString2Stru (ref List<string> listRecord)
        {
            int i = 0;

            try {
                sRcpStru.iId = int.Parse( listRecord[i++] );
                sRcpStru.iRcuId = int.Parse( listRecord[i++] );
                sRcpStru.sPayTime = Convert.ToDateTime( listRecord[i++] );
                sRcpStru.dPayMoney = double.Parse( listRecord[i++] );
                sRcpStru.sVaildTime = Convert.ToDateTime( listRecord[i++] );
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            DateTime sDataTimePay = new DateTime();
            DateTime sDataTimeValid = new DateTime();

            textBoxId.Text = listRecord[i++];
            textBoxRcuId.Text = listRecord[i++];
            sDataTimePay = DateTime.Parse( listRecord[i++] );
            textBoxPayMoney.Text = listRecord[i++];
            sDataTimeValid = DateTime.Parse( listRecord[i++] );

            dateTimePickerPayTime.Value = sDataTimePay;
            dateTimePickerVaildTime.Value = sDataTimeValid;
        }

        public override void dbStru2Ui ()
        {
            textBoxId.Text = sRcpStru.iId.ToString();
            textBoxRcuId.Text = sRcpStru.iRcuId.ToString();
            textBoxPayMoney.Text = sRcpStru.dPayMoney.ToString();
            dateTimePickerPayTime.Value = sRcpStru.sPayTime;
            dateTimePickerVaildTime.Value = sRcpStru.sVaildTime;
        }

        public override object dbStruGet ()
        {
            return sRcpStru;
        }

        public override void dbUi2Stru ()
        {
            sRcpStru.iId = int.Parse( textBoxId.Text );
            sRcpStru.iRcuId = int.Parse( textBoxRcuId.Text );
            sRcpStru.sPayTime = dateTimePickerPayTime.Value;
            sRcpStru.dPayMoney = double.Parse( textBoxPayMoney.Text );
            sRcpStru.sVaildTime = dateTimePickerVaildTime.Value;
        }

        private new void InitializeComponent ()
        {
            this.dateTimePickerVaildTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPayTime = new System.Windows.Forms.DateTimePicker();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxRcuId = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point( 336, 238 );
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point( 143, 238 );
            // 
            // dateTimePickerVaildTime
            // 
            this.dateTimePickerVaildTime.Location = new System.Drawing.Point( 336, 170 );
            this.dateTimePickerVaildTime.Name = "dateTimePickerVaildTime";
            this.dateTimePickerVaildTime.Size = new System.Drawing.Size( 200, 28 );
            this.dateTimePickerVaildTime.TabIndex = 19;
            // 
            // dateTimePickerPayTime
            // 
            this.dateTimePickerPayTime.Location = new System.Drawing.Point( 24, 171 );
            this.dateTimePickerPayTime.Name = "dateTimePickerPayTime";
            this.dateTimePickerPayTime.Size = new System.Drawing.Size( 200, 28 );
            this.dateTimePickerPayTime.TabIndex = 18;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point( 336, 63 );
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size( 100, 28 );
            this.textBoxPayMoney.TabIndex = 17;
            // 
            // textBoxRcuId
            // 
            this.textBoxRcuId.Location = new System.Drawing.Point( 183, 63 );
            this.textBoxRcuId.Name = "textBoxRcuId";
            this.textBoxRcuId.Size = new System.Drawing.Size( 100, 28 );
            this.textBoxRcuId.TabIndex = 16;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point( 24, 63 );
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size( 100, 28 );
            this.textBoxId.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 333, 23 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 80, 18 );
            this.label5.TabIndex = 14;
            this.label5.Text = "付款金额";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 333, 131 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 80, 18 );
            this.label4.TabIndex = 13;
            this.label4.Text = "有效时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 21, 131 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 80, 18 );
            this.label3.TabIndex = 12;
            this.label3.Text = "付款时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 180, 24 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 80, 18 );
            this.label2.TabIndex = 11;
            this.label2.Text = "固定卡ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 21, 24 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 26, 18 );
            this.label1.TabIndex = 10;
            this.label1.Text = "ID";
            // 
            // RegularCardPaymentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 9F, 18F );
            this.ClientSize = new System.Drawing.Size( 569, 307 );
            this.Controls.Add( this.dateTimePickerVaildTime );
            this.Controls.Add( this.dateTimePickerPayTime );
            this.Controls.Add( this.textBoxPayMoney );
            this.Controls.Add( this.textBoxRcuId );
            this.Controls.Add( this.textBoxId );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Name = "RegularCardPaymentEdit";
            this.Controls.SetChildIndex( this.buttonOk, 0 );
            this.Controls.SetChildIndex( this.buttonCancel, 0 );
            this.Controls.SetChildIndex( this.label1, 0 );
            this.Controls.SetChildIndex( this.label2, 0 );
            this.Controls.SetChildIndex( this.label3, 0 );
            this.Controls.SetChildIndex( this.label4, 0 );
            this.Controls.SetChildIndex( this.label5, 0 );
            this.Controls.SetChildIndex( this.textBoxId, 0 );
            this.Controls.SetChildIndex( this.textBoxRcuId, 0 );
            this.Controls.SetChildIndex( this.textBoxPayMoney, 0 );
            this.Controls.SetChildIndex( this.dateTimePickerPayTime, 0 );
            this.Controls.SetChildIndex( this.dateTimePickerVaildTime, 0 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }
    }
}
