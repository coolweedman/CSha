using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DatabaseProj.UI.RegularCardUserUi {
    public class RegularCardUserEdit : DbRecordEditBase {
        private System.Windows.Forms.ComboBox comboBoxCarType;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.TextBox textBoxUserPhone;
        private System.Windows.Forms.TextBox textBoxUserIdent;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        protected CRegularCardUserDb.SRegularCardUserStru sRcuStru;

        public RegularCardUserEdit(string strTitle = "Regular Card User Edit Window") : base(strTitle)
        {
            InitializeComponent();
            dbUiInit();
        }

        public override void dbUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseParkingCardTypeDesc.Length; i++ ) {
                comboBoxCardType.Items.Add( CDbBaseTable.strDbBaseParkingCardTypeDesc[i] );
            }
            comboBoxCardType.SelectedIndex = 0;

            for ( int i=0; i< CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++  ) {
                comboBoxCarType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }
            comboBoxCarType.SelectedIndex = CDbBaseTable.strDbBaseParkingCarTypeDesc.Length - 2;

            textBoxId.Text = "0";
            textBoxId.Enabled = false;
        }

        public override void dbString2Stru (ref List<string> listRecord)
        {
            int i = 0;

            try {
                sRcuStru.iId = int.Parse( listRecord[i++] );
                sRcuStru.strUserName = listRecord[i++];
                sRcuStru.strUserIdent = listRecord[i++];
                sRcuStru.strUserPhone = listRecord[i++];
                sRcuStru.strCarPlate = listRecord[i++];
                sRcuStru.strCardNum = listRecord[i++];
                sRcuStru.iCardType = CDbBaseTable.dicDbBaseParkingCardTypeDesc[listRecord[i++]];
                sRcuStru.iCarType = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public override void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            textBoxId.Text = listRecord[i++];
            textBoxUserName.Text = listRecord[i++];
            textBoxUserIdent.Text = listRecord[i++];
            textBoxUserPhone.Text = listRecord[i++];
            textBoxCarPlate.Text = listRecord[i++];
            textBoxCardNum.Text = listRecord[i++];
            comboBoxCardType.SelectedIndex = CDbBaseTable.dicDbBaseParkingCardTypeDesc[listRecord[i++]];
            comboBoxCarType.SelectedIndex = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
        }

        public override void dbStru2Ui ()
        {
            textBoxId.Text = sRcuStru.iId.ToString();
            textBoxUserName.Text = sRcuStru.strUserName;
            textBoxUserIdent.Text = sRcuStru.strUserIdent;
            textBoxUserPhone.Text = sRcuStru.strUserPhone;
            textBoxCarPlate.Text = sRcuStru.strCarPlate;
            textBoxCardNum.Text = sRcuStru.strCardNum;
            comboBoxCardType.SelectedIndex = sRcuStru.iCardType;
            comboBoxCarType.SelectedIndex = sRcuStru.iCarType;
        }

        /// <summary>
        /// 数据库管理员编辑 获取结构体
        /// </summary>
        /// <returns></returns>
        public override object dbStruGet ()
        {
            return sRcuStru;
        }

        public override void dbUi2Stru ()
        {
            sRcuStru.iId = int.Parse( textBoxId.Text );
            sRcuStru.strUserName = textBoxUserName.Text;
            sRcuStru.strUserIdent = textBoxUserIdent.Text;
            sRcuStru.strUserPhone = textBoxUserPhone.Text;
            sRcuStru.strCarPlate = textBoxCarPlate.Text;
            sRcuStru.strCardNum = textBoxCardNum.Text;
            sRcuStru.iCardType = comboBoxCardType.SelectedIndex;
            sRcuStru.iCarType = comboBoxCarType.SelectedIndex;
        }

        private new void InitializeComponent ()
        {
            this.comboBoxCarType = new System.Windows.Forms.ComboBox();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.textBoxUserPhone = new System.Windows.Forms.TextBox();
            this.textBoxUserIdent = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point( 366, 253 );
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point( 214, 253 );
            // 
            // comboBoxCarType
            // 
            this.comboBoxCarType.FormattingEnabled = true;
            this.comboBoxCarType.Location = new System.Drawing.Point( 498, 186 );
            this.comboBoxCarType.Name = "comboBoxCarType";
            this.comboBoxCarType.Size = new System.Drawing.Size( 136, 26 );
            this.comboBoxCarType.TabIndex = 39;
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Location = new System.Drawing.Point( 333, 186 );
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size( 140, 26 );
            this.comboBoxCardType.TabIndex = 38;
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point( 174, 185 );
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size( 145, 28 );
            this.textBoxCardNum.TabIndex = 37;
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point( 27, 186 );
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size( 127, 28 );
            this.textBoxCarPlate.TabIndex = 36;
            // 
            // textBoxUserPhone
            // 
            this.textBoxUserPhone.Location = new System.Drawing.Point( 498, 77 );
            this.textBoxUserPhone.Name = "textBoxUserPhone";
            this.textBoxUserPhone.Size = new System.Drawing.Size( 136, 28 );
            this.textBoxUserPhone.TabIndex = 35;
            // 
            // textBoxUserIdent
            // 
            this.textBoxUserIdent.Location = new System.Drawing.Point( 333, 78 );
            this.textBoxUserIdent.Name = "textBoxUserIdent";
            this.textBoxUserIdent.Size = new System.Drawing.Size( 140, 28 );
            this.textBoxUserIdent.TabIndex = 34;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point( 174, 77 );
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size( 145, 28 );
            this.textBoxUserName.TabIndex = 33;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point( 27, 78 );
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size( 127, 28 );
            this.textBoxId.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point( 330, 143 );
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size( 62, 18 );
            this.label8.TabIndex = 31;
            this.label8.Text = "卡类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point( 495, 143 );
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size( 80, 18 );
            this.label7.TabIndex = 30;
            this.label7.Text = "车位类型";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point( 171, 143 );
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size( 44, 18 );
            this.label6.TabIndex = 29;
            this.label6.Text = "卡号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 24, 143 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 44, 18 );
            this.label5.TabIndex = 28;
            this.label5.Text = "车牌";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 495, 39 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 44, 18 );
            this.label4.TabIndex = 27;
            this.label4.Text = "电话";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 330, 39 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 62, 18 );
            this.label3.TabIndex = 26;
            this.label3.Text = "身份证";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 171, 39 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 44, 18 );
            this.label2.TabIndex = 25;
            this.label2.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 24, 39 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 26, 18 );
            this.label1.TabIndex = 24;
            this.label1.Text = "ID";
            // 
            // RegularCardUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 9F, 18F );
            this.ClientSize = new System.Drawing.Size( 659, 325 );
            this.Controls.Add( this.comboBoxCarType );
            this.Controls.Add( this.comboBoxCardType );
            this.Controls.Add( this.textBoxCardNum );
            this.Controls.Add( this.textBoxCarPlate );
            this.Controls.Add( this.textBoxUserPhone );
            this.Controls.Add( this.textBoxUserIdent );
            this.Controls.Add( this.textBoxUserName );
            this.Controls.Add( this.textBoxId );
            this.Controls.Add( this.label8 );
            this.Controls.Add( this.label7 );
            this.Controls.Add( this.label6 );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Name = "RegularCardUserEdit";
            this.Controls.SetChildIndex( this.buttonOk, 0 );
            this.Controls.SetChildIndex( this.buttonCancel, 0 );
            this.Controls.SetChildIndex( this.label1, 0 );
            this.Controls.SetChildIndex( this.label2, 0 );
            this.Controls.SetChildIndex( this.label3, 0 );
            this.Controls.SetChildIndex( this.label4, 0 );
            this.Controls.SetChildIndex( this.label5, 0 );
            this.Controls.SetChildIndex( this.label6, 0 );
            this.Controls.SetChildIndex( this.label7, 0 );
            this.Controls.SetChildIndex( this.label8, 0 );
            this.Controls.SetChildIndex( this.textBoxId, 0 );
            this.Controls.SetChildIndex( this.textBoxUserName, 0 );
            this.Controls.SetChildIndex( this.textBoxUserIdent, 0 );
            this.Controls.SetChildIndex( this.textBoxUserPhone, 0 );
            this.Controls.SetChildIndex( this.textBoxCarPlate, 0 );
            this.Controls.SetChildIndex( this.textBoxCardNum, 0 );
            this.Controls.SetChildIndex( this.comboBoxCardType, 0 );
            this.Controls.SetChildIndex( this.comboBoxCarType, 0 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }
    }
}
