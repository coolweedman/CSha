using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.ParkingRecordUi {

    public class ParkingRecordQuery : DbRecordQueryBase {
        private System.Windows.Forms.TextBox textBoxSpaceNum;
        private System.Windows.Forms.TextBox textBoxGarageNum;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxBillNum;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxMoneyIn;
        private System.Windows.Forms.TextBox textBoxPicPath;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.ComboBox comboBoxDBAType;
        private System.Windows.Forms.ComboBox comboBoxPayMode;
        private System.Windows.Forms.TextBox textBoxDBAName;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarOutTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarInTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerBillDateStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerBillDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarInTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarOutTimeEnd;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxGarageNum;
        private System.Windows.Forms.CheckBox checkBoxSpaceNum;
        private System.Windows.Forms.CheckBox checkBoxCardNum;
        private System.Windows.Forms.CheckBox checkBoxPitPath;
        private System.Windows.Forms.CheckBox checkBoxMoneyIn;
        private System.Windows.Forms.CheckBox checkBoxPayMoney;
        private System.Windows.Forms.CheckBox checkBoxCarPlate;
        private System.Windows.Forms.CheckBox checkBoxPayMode;
        private System.Windows.Forms.CheckBox checkBoxDBAName;
        private System.Windows.Forms.CheckBox checkBoxDBAType;
        private System.Windows.Forms.CheckBox checkBoxCarInTime;
        private System.Windows.Forms.CheckBox checkBoxBillDate;
        private System.Windows.Forms.CheckBox checkBoxCarOutTime;
        private System.Windows.Forms.CheckBox checkBoxBillNum;
        protected CParkingRecordDb.SParkingRecordQueryStru sQueryStru;

        /// <summary>
        /// 停车记录查询界面 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public ParkingRecordQuery (CDatebaseBase hDbTableBase, string strTitle = "DBA Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 停车记录查询界面 UI初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseDBATypeDesc.Length; i++  ) {
                comboBoxDBAType.Items.Add( CDbBaseTable.strDbBaseDBATypeDesc[i] );
            }
            for ( int i=0; i<CDbBaseTable.strDbBasePayModeDesc.Length; i++ ) {
                comboBoxPayMode.Items.Add( CDbBaseTable.strDbBasePayModeDesc[i] );
            }
        }

        /// <summary>
        /// 停车记录查询界面 UI转结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bGarageNumEn = checkBoxGarageNum.Checked;
            sQueryStru.bSpaceNumEn = checkBoxSpaceNum.Checked;
            sQueryStru.bCardNumEn = checkBoxCardNum.Checked;
            sQueryStru.bCarPlateEn = checkBoxCarPlate.Checked;
            sQueryStru.bPicPathEn = checkBoxPitPath.Checked;
            sQueryStru.bMoneyInEn = checkBoxMoneyIn.Checked;
            sQueryStru.bMoneyPayEn = checkBoxPayMoney.Checked;
            sQueryStru.bBillNumEn = checkBoxBillNum.Checked;
            sQueryStru.bPayModeEn = checkBoxPayMode.Checked;
            sQueryStru.bDBANameEn = checkBoxDBAName.Checked;
            sQueryStru.bDBATypeEn = checkBoxDBAType.Checked;
            sQueryStru.bCarInTimeEn = checkBoxCarInTime.Checked;
            sQueryStru.bCarOutTimeEn = checkBoxCarOutTime.Checked;
            sQueryStru.bBillDateEn = checkBoxBillDate.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bGarageNumEn ) {
                sQueryStru.iGarageNum = int.Parse( textBoxGarageNum.Text );
            }
            if ( sQueryStru.bSpaceNumEn ) {
                sQueryStru.iSpaceNum = int.Parse( textBoxSpaceNum.Text );
            }
            if ( sQueryStru.bCardNumEn ) {
                sQueryStru.strCardNum = textBoxCardNum.Text;
            }
            if ( sQueryStru.bBillNumEn ) {
                sQueryStru.strBillNum = textBoxBillNum.Text;
            }
            if ( sQueryStru.bBillDateEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerBillDateStart.Value;
                sQueryStru.sBillDateStart = sDateTime;
                sDateTime = dateTimePickerBillDateEnd.Value;
                sQueryStru.sBillDateEnd = sDateTime;
            }
            if ( sQueryStru.bCarInTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerCarInTimeStart.Value;
                sQueryStru.sCarInTimeStart = sDateTime;
                sDateTime = dateTimePickerCarInTimeEnd.Value;
                sQueryStru.sCarInTimeEnd = sDateTime;
            }
            if ( sQueryStru.bCarOutTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerCarOutTimeStart.Value;
                sQueryStru.sCarOutTimeStart = sDateTime;
                sDateTime = dateTimePickerCarOutTimeEnd.Value;
                sQueryStru.sCarOutTimeEnd = sDateTime;
            }
            if ( sQueryStru.bCarPlateEn ) {
                sQueryStru.strCarPlate = textBoxCarPlate.Text;
            }
            if ( sQueryStru.bPicPathEn ) {
                sQueryStru.strPicPath = textBoxPicPath.Text;
            }
            if ( sQueryStru.bMoneyInEn ) {
                sQueryStru.dMoneyIn = double.Parse( textBoxMoneyIn.Text );
            }
            if ( sQueryStru.bMoneyPayEn ) {
                sQueryStru.dMoneyPay = double.Parse( textBoxPayMoney.Text );
            }
            if ( sQueryStru.bPayModeEn ) {
                sQueryStru.iPayMode = comboBoxPayMode.SelectedIndex;
            }
            if ( sQueryStru.bDBANameEn ) {
                sQueryStru.strDBAName = textBoxDBAName.Text;
            }
            if ( sQueryStru.bDBATypeEn ) {
                sQueryStru.iDBAType = comboBoxDBAType.SelectedIndex;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.textBoxSpaceNum = new System.Windows.Forms.TextBox();
            this.textBoxGarageNum = new System.Windows.Forms.TextBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxBillNum = new System.Windows.Forms.TextBox();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxMoneyIn = new System.Windows.Forms.TextBox();
            this.textBoxPicPath = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.comboBoxDBAType = new System.Windows.Forms.ComboBox();
            this.comboBoxPayMode = new System.Windows.Forms.ComboBox();
            this.textBoxDBAName = new System.Windows.Forms.TextBox();
            this.dateTimePickerCarOutTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarInTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBillDateStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBillDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarInTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarOutTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxGarageNum = new System.Windows.Forms.CheckBox();
            this.checkBoxSpaceNum = new System.Windows.Forms.CheckBox();
            this.checkBoxCardNum = new System.Windows.Forms.CheckBox();
            this.checkBoxBillNum = new System.Windows.Forms.CheckBox();
            this.checkBoxPitPath = new System.Windows.Forms.CheckBox();
            this.checkBoxMoneyIn = new System.Windows.Forms.CheckBox();
            this.checkBoxPayMoney = new System.Windows.Forms.CheckBox();
            this.checkBoxCarPlate = new System.Windows.Forms.CheckBox();
            this.checkBoxPayMode = new System.Windows.Forms.CheckBox();
            this.checkBoxDBAName = new System.Windows.Forms.CheckBox();
            this.checkBoxDBAType = new System.Windows.Forms.CheckBox();
            this.checkBoxCarInTime = new System.Windows.Forms.CheckBox();
            this.checkBoxBillDate = new System.Windows.Forms.CheckBox();
            this.checkBoxCarOutTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSpaceNum
            // 
            this.textBoxSpaceNum.Location = new System.Drawing.Point(299, 43);
            this.textBoxSpaceNum.Name = "textBoxSpaceNum";
            this.textBoxSpaceNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxSpaceNum.TabIndex = 44;
            this.textBoxSpaceNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSpaceNum_KeyPress);
            // 
            // textBoxGarageNum
            // 
            this.textBoxGarageNum.Location = new System.Drawing.Point(155, 43);
            this.textBoxGarageNum.Name = "textBoxGarageNum";
            this.textBoxGarageNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxGarageNum.TabIndex = 43;
            this.textBoxGarageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGarageNum_KeyPress);
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(425, 43);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxCardNum.TabIndex = 42;
            this.textBoxCardNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCardNum_KeyPress);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 43);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 41;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            // 
            // textBoxBillNum
            // 
            this.textBoxBillNum.Location = new System.Drawing.Point(12, 191);
            this.textBoxBillNum.Name = "textBoxBillNum";
            this.textBoxBillNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxBillNum.TabIndex = 46;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(425, 118);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 54;
            this.textBoxPayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPayMoney_KeyPress);
            // 
            // textBoxMoneyIn
            // 
            this.textBoxMoneyIn.Location = new System.Drawing.Point(299, 118);
            this.textBoxMoneyIn.Name = "textBoxMoneyIn";
            this.textBoxMoneyIn.Size = new System.Drawing.Size(100, 28);
            this.textBoxMoneyIn.TabIndex = 53;
            this.textBoxMoneyIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMoneyIn_KeyPress);
            // 
            // textBoxPicPath
            // 
            this.textBoxPicPath.Location = new System.Drawing.Point(155, 118);
            this.textBoxPicPath.Name = "textBoxPicPath";
            this.textBoxPicPath.Size = new System.Drawing.Size(100, 28);
            this.textBoxPicPath.TabIndex = 52;
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(12, 118);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(100, 28);
            this.textBoxCarPlate.TabIndex = 51;
            // 
            // comboBoxDBAType
            // 
            this.comboBoxDBAType.FormattingEnabled = true;
            this.comboBoxDBAType.Location = new System.Drawing.Point(425, 191);
            this.comboBoxDBAType.Name = "comboBoxDBAType";
            this.comboBoxDBAType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxDBAType.TabIndex = 60;
            // 
            // comboBoxPayMode
            // 
            this.comboBoxPayMode.FormattingEnabled = true;
            this.comboBoxPayMode.Location = new System.Drawing.Point(149, 191);
            this.comboBoxPayMode.Name = "comboBoxPayMode";
            this.comboBoxPayMode.Size = new System.Drawing.Size(121, 26);
            this.comboBoxPayMode.TabIndex = 59;
            // 
            // textBoxDBAName
            // 
            this.textBoxDBAName.Location = new System.Drawing.Point(299, 191);
            this.textBoxDBAName.Name = "textBoxDBAName";
            this.textBoxDBAName.Size = new System.Drawing.Size(100, 28);
            this.textBoxDBAName.TabIndex = 58;
            // 
            // dateTimePickerCarOutTimeStart
            // 
            this.dateTimePickerCarOutTimeStart.Location = new System.Drawing.Point(600, 118);
            this.dateTimePickerCarOutTimeStart.Name = "dateTimePickerCarOutTimeStart";
            this.dateTimePickerCarOutTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarOutTimeStart.TabIndex = 66;
            // 
            // dateTimePickerCarInTimeStart
            // 
            this.dateTimePickerCarInTimeStart.Location = new System.Drawing.Point(600, 43);
            this.dateTimePickerCarInTimeStart.Name = "dateTimePickerCarInTimeStart";
            this.dateTimePickerCarInTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarInTimeStart.TabIndex = 65;
            // 
            // dateTimePickerBillDateStart
            // 
            this.dateTimePickerBillDateStart.Location = new System.Drawing.Point(600, 187);
            this.dateTimePickerBillDateStart.Name = "dateTimePickerBillDateStart";
            this.dateTimePickerBillDateStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerBillDateStart.TabIndex = 64;
            // 
            // dateTimePickerBillDateEnd
            // 
            this.dateTimePickerBillDateEnd.Location = new System.Drawing.Point(860, 187);
            this.dateTimePickerBillDateEnd.Name = "dateTimePickerBillDateEnd";
            this.dateTimePickerBillDateEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerBillDateEnd.TabIndex = 67;
            // 
            // dateTimePickerCarInTimeEnd
            // 
            this.dateTimePickerCarInTimeEnd.Location = new System.Drawing.Point(860, 43);
            this.dateTimePickerCarInTimeEnd.Name = "dateTimePickerCarInTimeEnd";
            this.dateTimePickerCarInTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarInTimeEnd.TabIndex = 68;
            // 
            // dateTimePickerCarOutTimeEnd
            // 
            this.dateTimePickerCarOutTimeEnd.Location = new System.Drawing.Point(860, 118);
            this.dateTimePickerCarOutTimeEnd.Name = "dateTimePickerCarOutTimeEnd";
            this.dateTimePickerCarOutTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarOutTimeEnd.TabIndex = 69;
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(12, 11);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 70;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // checkBoxGarageNum
            // 
            this.checkBoxGarageNum.AutoSize = true;
            this.checkBoxGarageNum.Location = new System.Drawing.Point(155, 10);
            this.checkBoxGarageNum.Name = "checkBoxGarageNum";
            this.checkBoxGarageNum.Size = new System.Drawing.Size(88, 22);
            this.checkBoxGarageNum.TabIndex = 71;
            this.checkBoxGarageNum.Text = "车库号";
            this.checkBoxGarageNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpaceNum
            // 
            this.checkBoxSpaceNum.AutoSize = true;
            this.checkBoxSpaceNum.Location = new System.Drawing.Point(299, 10);
            this.checkBoxSpaceNum.Name = "checkBoxSpaceNum";
            this.checkBoxSpaceNum.Size = new System.Drawing.Size(88, 22);
            this.checkBoxSpaceNum.TabIndex = 72;
            this.checkBoxSpaceNum.Text = "车位号";
            this.checkBoxSpaceNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardNum
            // 
            this.checkBoxCardNum.AutoSize = true;
            this.checkBoxCardNum.Location = new System.Drawing.Point(425, 10);
            this.checkBoxCardNum.Name = "checkBoxCardNum";
            this.checkBoxCardNum.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCardNum.TabIndex = 73;
            this.checkBoxCardNum.Text = "卡号";
            this.checkBoxCardNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxBillNum
            // 
            this.checkBoxBillNum.AutoSize = true;
            this.checkBoxBillNum.Location = new System.Drawing.Point(12, 159);
            this.checkBoxBillNum.Name = "checkBoxBillNum";
            this.checkBoxBillNum.Size = new System.Drawing.Size(106, 22);
            this.checkBoxBillNum.TabIndex = 74;
            this.checkBoxBillNum.Text = "票据编号";
            this.checkBoxBillNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxPitPath
            // 
            this.checkBoxPitPath.AutoSize = true;
            this.checkBoxPitPath.Location = new System.Drawing.Point(155, 85);
            this.checkBoxPitPath.Name = "checkBoxPitPath";
            this.checkBoxPitPath.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPitPath.TabIndex = 75;
            this.checkBoxPitPath.Text = "车辆图片";
            this.checkBoxPitPath.UseVisualStyleBackColor = true;
            // 
            // checkBoxMoneyIn
            // 
            this.checkBoxMoneyIn.AutoSize = true;
            this.checkBoxMoneyIn.Location = new System.Drawing.Point(299, 85);
            this.checkBoxMoneyIn.Name = "checkBoxMoneyIn";
            this.checkBoxMoneyIn.Size = new System.Drawing.Size(106, 22);
            this.checkBoxMoneyIn.TabIndex = 76;
            this.checkBoxMoneyIn.Text = "付款金额";
            this.checkBoxMoneyIn.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayMoney
            // 
            this.checkBoxPayMoney.AutoSize = true;
            this.checkBoxPayMoney.Location = new System.Drawing.Point(425, 85);
            this.checkBoxPayMoney.Name = "checkBoxPayMoney";
            this.checkBoxPayMoney.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPayMoney.TabIndex = 77;
            this.checkBoxPayMoney.Text = "应收金额";
            this.checkBoxPayMoney.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarPlate
            // 
            this.checkBoxCarPlate.AutoSize = true;
            this.checkBoxCarPlate.Location = new System.Drawing.Point(12, 85);
            this.checkBoxCarPlate.Name = "checkBoxCarPlate";
            this.checkBoxCarPlate.Size = new System.Drawing.Size(88, 22);
            this.checkBoxCarPlate.TabIndex = 78;
            this.checkBoxCarPlate.Text = "车牌号";
            this.checkBoxCarPlate.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayMode
            // 
            this.checkBoxPayMode.AutoSize = true;
            this.checkBoxPayMode.Location = new System.Drawing.Point(155, 159);
            this.checkBoxPayMode.Name = "checkBoxPayMode";
            this.checkBoxPayMode.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPayMode.TabIndex = 79;
            this.checkBoxPayMode.Text = "付款方式";
            this.checkBoxPayMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxDBAName
            // 
            this.checkBoxDBAName.AutoSize = true;
            this.checkBoxDBAName.Location = new System.Drawing.Point(299, 159);
            this.checkBoxDBAName.Name = "checkBoxDBAName";
            this.checkBoxDBAName.Size = new System.Drawing.Size(124, 22);
            this.checkBoxDBAName.TabIndex = 80;
            this.checkBoxDBAName.Text = "操作员姓名";
            this.checkBoxDBAName.UseVisualStyleBackColor = true;
            // 
            // checkBoxDBAType
            // 
            this.checkBoxDBAType.AutoSize = true;
            this.checkBoxDBAType.Location = new System.Drawing.Point(429, 159);
            this.checkBoxDBAType.Name = "checkBoxDBAType";
            this.checkBoxDBAType.Size = new System.Drawing.Size(124, 22);
            this.checkBoxDBAType.TabIndex = 81;
            this.checkBoxDBAType.Text = "操作员类型";
            this.checkBoxDBAType.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarInTime
            // 
            this.checkBoxCarInTime.AutoSize = true;
            this.checkBoxCarInTime.Location = new System.Drawing.Point(600, 11);
            this.checkBoxCarInTime.Name = "checkBoxCarInTime";
            this.checkBoxCarInTime.Size = new System.Drawing.Size(106, 22);
            this.checkBoxCarInTime.TabIndex = 82;
            this.checkBoxCarInTime.Text = "入库时间";
            this.checkBoxCarInTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxBillDate
            // 
            this.checkBoxBillDate.AutoSize = true;
            this.checkBoxBillDate.Location = new System.Drawing.Point(600, 159);
            this.checkBoxBillDate.Name = "checkBoxBillDate";
            this.checkBoxBillDate.Size = new System.Drawing.Size(106, 22);
            this.checkBoxBillDate.TabIndex = 83;
            this.checkBoxBillDate.Text = "票据日期";
            this.checkBoxBillDate.UseVisualStyleBackColor = true;
            // 
            // checkBoxCarOutTime
            // 
            this.checkBoxCarOutTime.AutoSize = true;
            this.checkBoxCarOutTime.Location = new System.Drawing.Point(600, 86);
            this.checkBoxCarOutTime.Name = "checkBoxCarOutTime";
            this.checkBoxCarOutTime.Size = new System.Drawing.Size(106, 22);
            this.checkBoxCarOutTime.TabIndex = 84;
            this.checkBoxCarOutTime.Text = "出库时间";
            this.checkBoxCarOutTime.UseVisualStyleBackColor = true;
            // 
            // ParkingRecordQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1112, 679);
            this.Controls.Add(this.checkBoxCarOutTime);
            this.Controls.Add(this.checkBoxBillDate);
            this.Controls.Add(this.checkBoxCarInTime);
            this.Controls.Add(this.checkBoxDBAType);
            this.Controls.Add(this.checkBoxDBAName);
            this.Controls.Add(this.checkBoxPayMode);
            this.Controls.Add(this.checkBoxCarPlate);
            this.Controls.Add(this.checkBoxPayMoney);
            this.Controls.Add(this.checkBoxMoneyIn);
            this.Controls.Add(this.checkBoxPitPath);
            this.Controls.Add(this.checkBoxBillNum);
            this.Controls.Add(this.checkBoxCardNum);
            this.Controls.Add(this.checkBoxSpaceNum);
            this.Controls.Add(this.checkBoxGarageNum);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.dateTimePickerCarOutTimeEnd);
            this.Controls.Add(this.dateTimePickerCarInTimeEnd);
            this.Controls.Add(this.dateTimePickerBillDateEnd);
            this.Controls.Add(this.dateTimePickerCarOutTimeStart);
            this.Controls.Add(this.dateTimePickerCarInTimeStart);
            this.Controls.Add(this.dateTimePickerBillDateStart);
            this.Controls.Add(this.comboBoxDBAType);
            this.Controls.Add(this.comboBoxPayMode);
            this.Controls.Add(this.textBoxDBAName);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxMoneyIn);
            this.Controls.Add(this.textBoxPicPath);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxBillNum);
            this.Controls.Add(this.textBoxSpaceNum);
            this.Controls.Add(this.textBoxGarageNum);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxId);
            this.Name = "ParkingRecordQuery";
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.textBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.textBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.textBoxBillNum, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.textBoxPicPath, 0);
            this.Controls.SetChildIndex(this.textBoxMoneyIn, 0);
            this.Controls.SetChildIndex(this.textBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.textBoxDBAName, 0);
            this.Controls.SetChildIndex(this.comboBoxPayMode, 0);
            this.Controls.SetChildIndex(this.comboBoxDBAType, 0);
            this.Controls.SetChildIndex(this.dateTimePickerBillDateStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarInTimeStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarOutTimeStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerBillDateEnd, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarInTimeEnd, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarOutTimeEnd, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.checkBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.checkBoxCardNum, 0);
            this.Controls.SetChildIndex(this.checkBoxBillNum, 0);
            this.Controls.SetChildIndex(this.checkBoxPitPath, 0);
            this.Controls.SetChildIndex(this.checkBoxMoneyIn, 0);
            this.Controls.SetChildIndex(this.checkBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.checkBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.checkBoxPayMode, 0);
            this.Controls.SetChildIndex(this.checkBoxDBAName, 0);
            this.Controls.SetChildIndex(this.checkBoxDBAType, 0);
            this.Controls.SetChildIndex(this.checkBoxCarInTime, 0);
            this.Controls.SetChildIndex(this.checkBoxBillDate, 0);
            this.Controls.SetChildIndex(this.checkBoxCarOutTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxGarageNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxSpaceNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxCardNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxMoneyIn_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxPayMoney_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

    }
}
