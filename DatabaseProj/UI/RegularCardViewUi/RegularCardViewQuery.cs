using DatabaseProj.Code.Comm;
using DatabaseProj.Code.Database;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.RegularCardViewUi {
    public class RegularCardViewQuery : DbRecordQueryBase {
        private System.Windows.Forms.CheckBox checkBoxCarType;
        private System.Windows.Forms.CheckBox checkBoxCardType;
        private System.Windows.Forms.CheckBox checkBoxCardNum;
        private System.Windows.Forms.CheckBox checkBoxCarPlate;
        private System.Windows.Forms.CheckBox checkBoxUserPhone;
        private System.Windows.Forms.CheckBox checkBoxUserIdent;
        private System.Windows.Forms.CheckBox checkBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxRcuId;
        private System.Windows.Forms.ComboBox comboBoxCarType;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.TextBox textBoxUserPhone;
        private System.Windows.Forms.TextBox textBoxUserIdent;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxValidTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeEnd;
        private System.Windows.Forms.CheckBox checkBoxPayTime;
        private System.Windows.Forms.CheckBox checkBoxPayMoney;
        private System.Windows.Forms.CheckBox checkBoxRcpId;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeStart;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxRcpId;
        private System.Windows.Forms.TextBox textBoxRcuId;
        protected CRegularCardView.SRegularCardViewQueryStru sQueryStru;

        /// <summary>
        /// 固定卡视图 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public RegularCardViewQuery (CDatebaseBase hDbTableBase, string strTitle = "RegularCard Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 固定卡视图 UI初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            for ( int i = 0; i < CDbBaseTable.strDbBaseParkingCardTypeDesc.Length; i++ ) {
                comboBoxCardType.Items.Add( CDbBaseTable.strDbBaseParkingCardTypeDesc[i] );
            }
            for ( int i = 0; i < CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxCarType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }

            DateTime sDateTime = new DateTime( 2020, 12, 31 );
            dateTimePickerValidTimeEnd.Value = sDateTime;
        }

        /// <summary>
        /// 固定卡视图 UI转结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.sUserQuery.bIdEn = checkBoxRcuId.Checked;
            sQueryStru.sUserQuery.bUserNameEn = checkBoxUserName.Checked;
            sQueryStru.sUserQuery.bUserIdent = checkBoxUserIdent.Checked;
            sQueryStru.sUserQuery.bUserPhone = checkBoxUserPhone.Checked;
            sQueryStru.sUserQuery.bCarPlate = checkBoxCarPlate.Checked;
            sQueryStru.sUserQuery.bCardNum = checkBoxCardNum.Checked;
            sQueryStru.sUserQuery.bCardType = checkBoxCardType.Checked;
            sQueryStru.sUserQuery.bCarType = checkBoxCarType.Checked;

            sQueryStru.sPaymentQuery.bIdEn = checkBoxRcpId.Checked;
            sQueryStru.sPaymentQuery.bPayMoneyEn = checkBoxPayMoney.Checked;
            sQueryStru.sPaymentQuery.bPayTimeEn = checkBoxPayTime.Checked;
            sQueryStru.sPaymentQuery.bValidTimeEn = checkBoxValidTime.Checked;

            if ( sQueryStru.sUserQuery.bIdEn ) {
                sQueryStru.sUserQuery.iId = int.Parse( textBoxRcuId.Text );
            }
            if ( sQueryStru.sUserQuery.bUserNameEn ) {
                sQueryStru.sUserQuery.strUserName = textBoxUserName.Text;
            }
            if ( sQueryStru.sUserQuery.bUserIdent ) {
                sQueryStru.sUserQuery.strUserIdent = textBoxUserIdent.Text;
            }
            if ( sQueryStru.sUserQuery.bUserPhone ) {
                sQueryStru.sUserQuery.strUserPhone = textBoxUserPhone.Text;
            }
            if ( sQueryStru.sUserQuery.bCarPlate ) {
                sQueryStru.sUserQuery.strCarPlate = textBoxCarPlate.Text;
            }
            if ( sQueryStru.sUserQuery.bCardNum ) {
                sQueryStru.sUserQuery.strCardNum = textBoxCardNum.Text;
            }
            if ( sQueryStru.sUserQuery.bCardType ) {
                sQueryStru.sUserQuery.iCardType = comboBoxCardType.SelectedIndex;
            }
            if ( sQueryStru.sUserQuery.bCarType ) {
                sQueryStru.sUserQuery.iCarType = comboBoxCarType.SelectedIndex;
            }

            if ( sQueryStru.sPaymentQuery.bIdEn ) {
                sQueryStru.sPaymentQuery.iId = int.Parse( textBoxRcpId.Text );
            }
            if ( sQueryStru.sPaymentQuery.bPayTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerPayTimeStart.Value;
                sQueryStru.sPaymentQuery.sPayTimeStart = sDateTime;
                sDateTime = dateTimePickerPayTimeEnd.Value;
                sQueryStru.sPaymentQuery.sPayTimeStop = sDateTime;
            }
            if ( sQueryStru.sPaymentQuery.bPayMoneyEn ) {
                sQueryStru.sPaymentQuery.dPayMoney = double.Parse( textBoxPayMoney.Text );
            }
            if ( sQueryStru.sPaymentQuery.bValidTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerValidTimeStart.Value;
                sQueryStru.sPaymentQuery.sValidTimeStart = sDateTime;
                sDateTime = dateTimePickerValidTimeEnd.Value;
                sQueryStru.sPaymentQuery.sValidTimeStop = sDateTime;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.checkBoxCarType = new System.Windows.Forms.CheckBox();
            this.checkBoxCardType = new System.Windows.Forms.CheckBox();
            this.checkBoxCardNum = new System.Windows.Forms.CheckBox();
            this.checkBoxCarPlate = new System.Windows.Forms.CheckBox();
            this.checkBoxUserPhone = new System.Windows.Forms.CheckBox();
            this.checkBoxUserIdent = new System.Windows.Forms.CheckBox();
            this.checkBoxUserName = new System.Windows.Forms.CheckBox();
            this.checkBoxRcuId = new System.Windows.Forms.CheckBox();
            this.comboBoxCarType = new System.Windows.Forms.ComboBox();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.textBoxUserPhone = new System.Windows.Forms.TextBox();
            this.textBoxUserIdent = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxRcuId = new System.Windows.Forms.TextBox();
            this.checkBoxValidTime = new System.Windows.Forms.CheckBox();
            this.dateTimePickerValidTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPayTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxPayTime = new System.Windows.Forms.CheckBox();
            this.checkBoxPayMoney = new System.Windows.Forms.CheckBox();
            this.checkBoxRcpId = new System.Windows.Forms.CheckBox();
            this.dateTimePickerValidTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPayTimeStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxRcpId = new System.Windows.Forms.TextBox();
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
            // checkBoxCarType
            // 
            this.checkBoxCarType.AutoSize = true;
            this.checkBoxCarType.Location = new System.Drawing.Point(200, 93);
            this.checkBoxCarType.Name = "checkBoxCarType";
            this.checkBoxCarType.Size = new System.Drawing.Size(106, 22);
            this.checkBoxCarType.TabIndex = 63;
            this.checkBoxCarType.Text = "车位类型";
            this.checkBoxCarType.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardType
            // 
            this.checkBoxCardType.AutoSize = true;
            this.checkBoxCardType.Location = new System.Drawing.Point(12, 93);
            this.checkBoxCardType.Name = "checkBoxCardType";
            this.checkBoxCardType.Size = new System.Drawing.Size(88, 22);
            this.checkBoxCardType.TabIndex = 62;
            this.checkBoxCardType.Text = "卡类型";
            this.checkBoxCardType.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardNum
            // 
            this.checkBoxCardNum.AutoSize = true;
            this.checkBoxCardNum.Location = new System.Drawing.Point(946, 12);
            this.checkBoxCardNum.Name = "checkBoxCardNum";
            this.checkBoxCardNum.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCardNum.TabIndex = 61;
            this.checkBoxCardNum.Text = "卡号";
            this.checkBoxCardNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarPlate
            // 
            this.checkBoxCarPlate.AutoSize = true;
            this.checkBoxCarPlate.Location = new System.Drawing.Point(762, 12);
            this.checkBoxCarPlate.Name = "checkBoxCarPlate";
            this.checkBoxCarPlate.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCarPlate.TabIndex = 60;
            this.checkBoxCarPlate.Text = "车牌";
            this.checkBoxCarPlate.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserPhone
            // 
            this.checkBoxUserPhone.AutoSize = true;
            this.checkBoxUserPhone.Location = new System.Drawing.Point(584, 12);
            this.checkBoxUserPhone.Name = "checkBoxUserPhone";
            this.checkBoxUserPhone.Size = new System.Drawing.Size(70, 22);
            this.checkBoxUserPhone.TabIndex = 59;
            this.checkBoxUserPhone.Text = "电话";
            this.checkBoxUserPhone.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserIdent
            // 
            this.checkBoxUserIdent.AutoSize = true;
            this.checkBoxUserIdent.Location = new System.Drawing.Point(392, 12);
            this.checkBoxUserIdent.Name = "checkBoxUserIdent";
            this.checkBoxUserIdent.Size = new System.Drawing.Size(88, 22);
            this.checkBoxUserIdent.TabIndex = 58;
            this.checkBoxUserIdent.Text = "身份证";
            this.checkBoxUserIdent.UseVisualStyleBackColor = true;
            // 
            // checkBoxUserName
            // 
            this.checkBoxUserName.AutoSize = true;
            this.checkBoxUserName.Location = new System.Drawing.Point(200, 12);
            this.checkBoxUserName.Name = "checkBoxUserName";
            this.checkBoxUserName.Size = new System.Drawing.Size(70, 22);
            this.checkBoxUserName.TabIndex = 57;
            this.checkBoxUserName.Text = "姓名";
            this.checkBoxUserName.UseVisualStyleBackColor = true;
            // 
            // checkBoxRcuId
            // 
            this.checkBoxRcuId.AutoSize = true;
            this.checkBoxRcuId.Location = new System.Drawing.Point(12, 12);
            this.checkBoxRcuId.Name = "checkBoxRcuId";
            this.checkBoxRcuId.Size = new System.Drawing.Size(106, 22);
            this.checkBoxRcuId.TabIndex = 56;
            this.checkBoxRcuId.Text = "停车卡ID";
            this.checkBoxRcuId.UseVisualStyleBackColor = true;
            // 
            // comboBoxCarType
            // 
            this.comboBoxCarType.FormattingEnabled = true;
            this.comboBoxCarType.Location = new System.Drawing.Point(200, 121);
            this.comboBoxCarType.Name = "comboBoxCarType";
            this.comboBoxCarType.Size = new System.Drawing.Size(136, 26);
            this.comboBoxCarType.TabIndex = 55;
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.Location = new System.Drawing.Point(12, 121);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(140, 26);
            this.comboBoxCardType.TabIndex = 54;
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(946, 44);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(145, 28);
            this.textBoxCardNum.TabIndex = 53;
            this.textBoxCardNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCardNum_KeyPress);
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(762, 44);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(127, 28);
            this.textBoxCarPlate.TabIndex = 52;
            // 
            // textBoxUserPhone
            // 
            this.textBoxUserPhone.Location = new System.Drawing.Point(584, 44);
            this.textBoxUserPhone.Name = "textBoxUserPhone";
            this.textBoxUserPhone.Size = new System.Drawing.Size(136, 28);
            this.textBoxUserPhone.TabIndex = 51;
            this.textBoxUserPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserPhone_KeyPress);
            // 
            // textBoxUserIdent
            // 
            this.textBoxUserIdent.Location = new System.Drawing.Point(392, 44);
            this.textBoxUserIdent.Name = "textBoxUserIdent";
            this.textBoxUserIdent.Size = new System.Drawing.Size(140, 28);
            this.textBoxUserIdent.TabIndex = 50;
            this.textBoxUserIdent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserIdent_KeyPress);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(200, 44);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(145, 28);
            this.textBoxUserName.TabIndex = 49;
            // 
            // textBoxRcuId
            // 
            this.textBoxRcuId.Location = new System.Drawing.Point(12, 44);
            this.textBoxRcuId.Name = "textBoxRcuId";
            this.textBoxRcuId.Size = new System.Drawing.Size(127, 28);
            this.textBoxRcuId.TabIndex = 48;
            this.textBoxRcuId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRcuId_KeyPress);
            // 
            // checkBoxValidTime
            // 
            this.checkBoxValidTime.AutoSize = true;
            this.checkBoxValidTime.Location = new System.Drawing.Point(762, 93);
            this.checkBoxValidTime.Name = "checkBoxValidTime";
            this.checkBoxValidTime.Size = new System.Drawing.Size(124, 22);
            this.checkBoxValidTime.TabIndex = 75;
            this.checkBoxValidTime.Text = "有效时间段";
            this.checkBoxValidTime.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerValidTimeEnd
            // 
            this.dateTimePickerValidTimeEnd.Location = new System.Drawing.Point(762, 190);
            this.dateTimePickerValidTimeEnd.Name = "dateTimePickerValidTimeEnd";
            this.dateTimePickerValidTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerValidTimeEnd.TabIndex = 74;
            // 
            // dateTimePickerPayTimeEnd
            // 
            this.dateTimePickerPayTimeEnd.Location = new System.Drawing.Point(392, 190);
            this.dateTimePickerPayTimeEnd.Name = "dateTimePickerPayTimeEnd";
            this.dateTimePickerPayTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeEnd.TabIndex = 73;
            // 
            // checkBoxPayTime
            // 
            this.checkBoxPayTime.AutoSize = true;
            this.checkBoxPayTime.Location = new System.Drawing.Point(392, 93);
            this.checkBoxPayTime.Name = "checkBoxPayTime";
            this.checkBoxPayTime.Size = new System.Drawing.Size(124, 22);
            this.checkBoxPayTime.TabIndex = 72;
            this.checkBoxPayTime.Text = "付款时间段";
            this.checkBoxPayTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayMoney
            // 
            this.checkBoxPayMoney.AutoSize = true;
            this.checkBoxPayMoney.Location = new System.Drawing.Point(200, 162);
            this.checkBoxPayMoney.Name = "checkBoxPayMoney";
            this.checkBoxPayMoney.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPayMoney.TabIndex = 71;
            this.checkBoxPayMoney.Text = "付款金额";
            this.checkBoxPayMoney.UseVisualStyleBackColor = true;
            // 
            // checkBoxRcpId
            // 
            this.checkBoxRcpId.AutoSize = true;
            this.checkBoxRcpId.Location = new System.Drawing.Point(12, 162);
            this.checkBoxRcpId.Name = "checkBoxRcpId";
            this.checkBoxRcpId.Size = new System.Drawing.Size(88, 22);
            this.checkBoxRcpId.TabIndex = 69;
            this.checkBoxRcpId.Text = "付款ID";
            this.checkBoxRcpId.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerValidTimeStart
            // 
            this.dateTimePickerValidTimeStart.Location = new System.Drawing.Point(762, 121);
            this.dateTimePickerValidTimeStart.Name = "dateTimePickerValidTimeStart";
            this.dateTimePickerValidTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerValidTimeStart.TabIndex = 68;
            // 
            // dateTimePickerPayTimeStart
            // 
            this.dateTimePickerPayTimeStart.Location = new System.Drawing.Point(392, 119);
            this.dateTimePickerPayTimeStart.Name = "dateTimePickerPayTimeStart";
            this.dateTimePickerPayTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeStart.TabIndex = 67;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(200, 190);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 66;
            this.textBoxPayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPayMoney_KeyPress);
            // 
            // textBoxRcpId
            // 
            this.textBoxRcpId.Location = new System.Drawing.Point(12, 190);
            this.textBoxRcpId.Name = "textBoxRcpId";
            this.textBoxRcpId.Size = new System.Drawing.Size(100, 28);
            this.textBoxRcpId.TabIndex = 64;
            this.textBoxRcpId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRcpId_KeyPress);
            // 
            // RegularCardViewQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1103, 667);
            this.Controls.Add(this.checkBoxValidTime);
            this.Controls.Add(this.dateTimePickerValidTimeEnd);
            this.Controls.Add(this.dateTimePickerPayTimeEnd);
            this.Controls.Add(this.checkBoxPayTime);
            this.Controls.Add(this.checkBoxPayMoney);
            this.Controls.Add(this.checkBoxRcpId);
            this.Controls.Add(this.dateTimePickerValidTimeStart);
            this.Controls.Add(this.dateTimePickerPayTimeStart);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxRcpId);
            this.Controls.Add(this.checkBoxCarType);
            this.Controls.Add(this.checkBoxCardType);
            this.Controls.Add(this.checkBoxCardNum);
            this.Controls.Add(this.checkBoxCarPlate);
            this.Controls.Add(this.checkBoxUserPhone);
            this.Controls.Add(this.checkBoxUserIdent);
            this.Controls.Add(this.checkBoxUserName);
            this.Controls.Add(this.checkBoxRcuId);
            this.Controls.Add(this.comboBoxCarType);
            this.Controls.Add(this.comboBoxCardType);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxUserPhone);
            this.Controls.Add(this.textBoxUserIdent);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxRcuId);
            this.Name = "RegularCardViewQuery";
            this.Controls.SetChildIndex(this.textBoxRcuId, 0);
            this.Controls.SetChildIndex(this.textBoxUserName, 0);
            this.Controls.SetChildIndex(this.textBoxUserIdent, 0);
            this.Controls.SetChildIndex(this.textBoxUserPhone, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.comboBoxCardType, 0);
            this.Controls.SetChildIndex(this.comboBoxCarType, 0);
            this.Controls.SetChildIndex(this.checkBoxRcuId, 0);
            this.Controls.SetChildIndex(this.checkBoxUserName, 0);
            this.Controls.SetChildIndex(this.checkBoxUserIdent, 0);
            this.Controls.SetChildIndex(this.checkBoxUserPhone, 0);
            this.Controls.SetChildIndex(this.checkBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.checkBoxCardNum, 0);
            this.Controls.SetChildIndex(this.checkBoxCardType, 0);
            this.Controls.SetChildIndex(this.checkBoxCarType, 0);
            this.Controls.SetChildIndex(this.textBoxRcpId, 0);
            this.Controls.SetChildIndex(this.textBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerValidTimeStart, 0);
            this.Controls.SetChildIndex(this.checkBoxRcpId, 0);
            this.Controls.SetChildIndex(this.checkBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.checkBoxPayTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeEnd, 0);
            this.Controls.SetChildIndex(this.dateTimePickerValidTimeEnd, 0);
            this.Controls.SetChildIndex(this.checkBoxValidTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxRcuId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxUserIdent_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
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

        private void textBoxRcpId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxPayMoney_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
