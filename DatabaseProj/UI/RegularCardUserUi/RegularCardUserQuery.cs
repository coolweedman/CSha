using DatabaseProj.Code.Comm;
using DatabaseProj.Code.Database;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.RegularCardUserUi {
    class RegularCardUserQuery : DbRecordQueryBase {

        private System.Windows.Forms.ComboBox comboBoxCarType;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.TextBox textBoxUserPhone;
        private System.Windows.Forms.TextBox textBoxUserIdent;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxUserIdent;
        private System.Windows.Forms.CheckBox checkBoxUserPhone;
        private System.Windows.Forms.CheckBox checkBoxCarPlate;
        private System.Windows.Forms.CheckBox checkBoxCardNum;
        private System.Windows.Forms.CheckBox checkBoxCardType;
        private System.Windows.Forms.CheckBox checkBoxCarType;
        private System.Windows.Forms.TextBox textBoxId;
        protected CRegularCardUserDb.SRegularCardUserQueryStru sQueryStru;

        /// <summary>
        /// 停车卡数据库查询 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public RegularCardUserQuery (CDatebaseBase hDbTableBase, string strTitle = "Regular Card User Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 停车卡数据库查询 UI初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseParkingCardTypeDesc.Length; i++ ) {
                comboBoxCardType.Items.Add( CDbBaseTable.strDbBaseParkingCardTypeDesc[i] );
            }
            for ( int i=0; i<CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxCarType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }
        }

        /// <summary>
        /// 停车卡数据库查询 UI转结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bUserNameEn = checkBoxUserName.Checked;
            sQueryStru.bUserIdent = checkBoxUserIdent.Checked;
            sQueryStru.bUserPhone = checkBoxUserPhone.Checked;
            sQueryStru.bCarPlate = checkBoxCarPlate.Checked;
            sQueryStru.bCardNum = checkBoxCardNum.Checked;
            sQueryStru.bCardType = checkBoxCardType.Checked;
            sQueryStru.bCarType = checkBoxCarType.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bUserNameEn ) {
                sQueryStru.strUserName = textBoxUserName.Text;
            }
            if ( sQueryStru.bUserIdent ) {
                sQueryStru.strUserIdent = textBoxUserIdent.Text;
            }
            if ( sQueryStru.bUserPhone ) {
                sQueryStru.strUserPhone = textBoxUserPhone.Text;
            }
            if ( sQueryStru.bCarPlate ) {
                sQueryStru.strCarPlate = textBoxCarPlate.Text;
            }
            if ( sQueryStru.bCardNum ) {
                sQueryStru.strCardNum = textBoxCardNum.Text;
            }
            if ( sQueryStru.bCardType ) {
                sQueryStru.iCardType = comboBoxCardType.SelectedIndex;
            }
            if ( sQueryStru.bCarType ) {
                sQueryStru.iCarType = comboBoxCarType.SelectedIndex;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.comboBoxCarType = new System.Windows.Forms.ComboBox();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.textBoxUserPhone = new System.Windows.Forms.TextBox();
            this.textBoxUserIdent = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxUserName = new System.Windows.Forms.CheckBox();
            this.checkBoxUserIdent = new System.Windows.Forms.CheckBox();
            this.checkBoxUserPhone = new System.Windows.Forms.CheckBox();
            this.checkBoxCarPlate = new System.Windows.Forms.CheckBox();
            this.checkBoxCardNum = new System.Windows.Forms.CheckBox();
            this.checkBoxCardType = new System.Windows.Forms.CheckBox();
            this.checkBoxCarType = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(206, 595);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(93, 35);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(776, 595);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            // 
            // comboBoxCarType
            // 
            this.comboBoxCarType.FormattingEnabled = true;
            this.comboBoxCarType.Location = new System.Drawing.Point(924, 173);
            this.comboBoxCarType.Name = "comboBoxCarType";
            this.comboBoxCarType.Size = new System.Drawing.Size(136, 26);
            this.comboBoxCarType.TabIndex = 39;
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Location = new System.Drawing.Point(654, 170);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(140, 26);
            this.comboBoxCardType.TabIndex = 38;
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(324, 168);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(145, 28);
            this.textBoxCardNum.TabIndex = 37;
            this.textBoxCardNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCardNum_KeyPress);
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(45, 171);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(127, 28);
            this.textBoxCarPlate.TabIndex = 36;
            // 
            // textBoxUserPhone
            // 
            this.textBoxUserPhone.Location = new System.Drawing.Point(924, 64);
            this.textBoxUserPhone.Name = "textBoxUserPhone";
            this.textBoxUserPhone.Size = new System.Drawing.Size(136, 28);
            this.textBoxUserPhone.TabIndex = 35;
            this.textBoxUserPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserPhone_KeyPress);
            // 
            // textBoxUserIdent
            // 
            this.textBoxUserIdent.Location = new System.Drawing.Point(654, 62);
            this.textBoxUserIdent.Name = "textBoxUserIdent";
            this.textBoxUserIdent.Size = new System.Drawing.Size(140, 28);
            this.textBoxUserIdent.TabIndex = 34;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(324, 60);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(145, 28);
            this.textBoxUserName.TabIndex = 33;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(45, 63);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(127, 28);
            this.textBoxId.TabIndex = 32;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(45, 24);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 40;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserName
            // 
            this.checkBoxUserName.AutoSize = true;
            this.checkBoxUserName.Location = new System.Drawing.Point(324, 22);
            this.checkBoxUserName.Name = "checkBoxUserName";
            this.checkBoxUserName.Size = new System.Drawing.Size(70, 22);
            this.checkBoxUserName.TabIndex = 41;
            this.checkBoxUserName.Text = "姓名";
            this.checkBoxUserName.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserIdent
            // 
            this.checkBoxUserIdent.AutoSize = true;
            this.checkBoxUserIdent.Location = new System.Drawing.Point(654, 23);
            this.checkBoxUserIdent.Name = "checkBoxUserIdent";
            this.checkBoxUserIdent.Size = new System.Drawing.Size(88, 22);
            this.checkBoxUserIdent.TabIndex = 42;
            this.checkBoxUserIdent.Text = "身份证";
            this.checkBoxUserIdent.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserPhone
            // 
            this.checkBoxUserPhone.AutoSize = true;
            this.checkBoxUserPhone.Location = new System.Drawing.Point(924, 26);
            this.checkBoxUserPhone.Name = "checkBoxUserPhone";
            this.checkBoxUserPhone.Size = new System.Drawing.Size(70, 22);
            this.checkBoxUserPhone.TabIndex = 43;
            this.checkBoxUserPhone.Text = "电话";
            this.checkBoxUserPhone.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarPlate
            // 
            this.checkBoxCarPlate.AutoSize = true;
            this.checkBoxCarPlate.Location = new System.Drawing.Point(45, 124);
            this.checkBoxCarPlate.Name = "checkBoxCarPlate";
            this.checkBoxCarPlate.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCarPlate.TabIndex = 44;
            this.checkBoxCarPlate.Text = "车牌";
            this.checkBoxCarPlate.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardNum
            // 
            this.checkBoxCardNum.AutoSize = true;
            this.checkBoxCardNum.Location = new System.Drawing.Point(324, 122);
            this.checkBoxCardNum.Name = "checkBoxCardNum";
            this.checkBoxCardNum.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCardNum.TabIndex = 45;
            this.checkBoxCardNum.Text = "卡号";
            this.checkBoxCardNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardType
            // 
            this.checkBoxCardType.AutoSize = true;
            this.checkBoxCardType.Location = new System.Drawing.Point(654, 123);
            this.checkBoxCardType.Name = "checkBoxCardType";
            this.checkBoxCardType.Size = new System.Drawing.Size(88, 22);
            this.checkBoxCardType.TabIndex = 46;
            this.checkBoxCardType.Text = "卡类型";
            this.checkBoxCardType.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarType
            // 
            this.checkBoxCarType.AutoSize = true;
            this.checkBoxCarType.Location = new System.Drawing.Point(924, 126);
            this.checkBoxCarType.Name = "checkBoxCarType";
            this.checkBoxCarType.Size = new System.Drawing.Size(106, 22);
            this.checkBoxCarType.TabIndex = 47;
            this.checkBoxCarType.Text = "车位类型";
            this.checkBoxCarType.UseVisualStyleBackColor = true;
            // 
            // RegularCardUserQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1115, 667);
            this.Controls.Add(this.checkBoxCarType);
            this.Controls.Add(this.checkBoxCardType);
            this.Controls.Add(this.checkBoxCardNum);
            this.Controls.Add(this.checkBoxCarPlate);
            this.Controls.Add(this.checkBoxUserPhone);
            this.Controls.Add(this.checkBoxUserIdent);
            this.Controls.Add(this.checkBoxUserName);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.comboBoxCarType);
            this.Controls.Add(this.comboBoxCardType);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxUserPhone);
            this.Controls.Add(this.textBoxUserIdent);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxId);
            this.Name = "RegularCardUserQuery";
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxUserName, 0);
            this.Controls.SetChildIndex(this.textBoxUserIdent, 0);
            this.Controls.SetChildIndex(this.textBoxUserPhone, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.comboBoxCardType, 0);
            this.Controls.SetChildIndex(this.comboBoxCarType, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxUserName, 0);
            this.Controls.SetChildIndex(this.checkBoxUserIdent, 0);
            this.Controls.SetChildIndex(this.checkBoxUserPhone, 0);
            this.Controls.SetChildIndex(this.checkBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.checkBoxCardNum, 0);
            this.Controls.SetChildIndex(this.checkBoxCardType, 0);
            this.Controls.SetChildIndex(this.checkBoxCarType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxUserPhone_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxCardNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
