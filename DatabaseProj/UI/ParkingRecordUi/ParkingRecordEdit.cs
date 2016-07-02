using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DatabaseProj.UI.ParkingRecordUi {

    public class ParkingRecordEdit : DbRecordEditBase {
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxBillNum;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.TextBox textBoxDBAName;
        private System.Windows.Forms.TextBox textBoxPicPath;
        private System.Windows.Forms.TextBox textBoxMoneyIn;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.ComboBox comboBoxGarageNum;
        private System.Windows.Forms.ComboBox comboBoxSpaceNum;
        private System.Windows.Forms.ComboBox comboBoxPayMode;
        private System.Windows.Forms.ComboBox comboBoxDBAType;
        private System.Windows.Forms.DateTimePicker dateTimePickerBillDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarInTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerCarOutTime;
        private System.Windows.Forms.Label label1;

        public ParkingRecordEdit (string strTitle = "Parking Record Edit") : base( strTitle )
        {
            InitializeComponent();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxBillNum = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.textBoxDBAName = new System.Windows.Forms.TextBox();
            this.textBoxPicPath = new System.Windows.Forms.TextBox();
            this.textBoxMoneyIn = new System.Windows.Forms.TextBox();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.comboBoxGarageNum = new System.Windows.Forms.ComboBox();
            this.comboBoxSpaceNum = new System.Windows.Forms.ComboBox();
            this.comboBoxPayMode = new System.Windows.Forms.ComboBox();
            this.comboBoxDBAType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerBillDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarInTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCarOutTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(453, 505);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(298, 505);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "车库号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "车位号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "卡号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "票据编号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "出票日期";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(460, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "入库时间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(683, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "出库时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "车牌号";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "车辆图片";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(460, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 12;
            this.label11.Text = "付款金额";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(683, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "应收金额";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 18);
            this.label13.TabIndex = 14;
            this.label13.Text = "付款方式";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 18);
            this.label14.TabIndex = 15;
            this.label14.Text = "操作员";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(460, 377);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 16;
            this.label15.Text = "用户类型";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(683, 376);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 18);
            this.label16.TabIndex = 17;
            this.label16.Text = "备注";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(47, 81);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 18;
            // 
            // textBoxBillNum
            // 
            this.textBoxBillNum.Location = new System.Drawing.Point(47, 196);
            this.textBoxBillNum.Name = "textBoxBillNum";
            this.textBoxBillNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxBillNum.TabIndex = 20;
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(47, 307);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(100, 28);
            this.textBoxCarPlate.TabIndex = 21;
            // 
            // textBoxDBAName
            // 
            this.textBoxDBAName.Location = new System.Drawing.Point(227, 421);
            this.textBoxDBAName.Name = "textBoxDBAName";
            this.textBoxDBAName.Size = new System.Drawing.Size(100, 28);
            this.textBoxDBAName.TabIndex = 22;
            // 
            // textBoxPicPath
            // 
            this.textBoxPicPath.Location = new System.Drawing.Point(227, 306);
            this.textBoxPicPath.Name = "textBoxPicPath";
            this.textBoxPicPath.Size = new System.Drawing.Size(100, 28);
            this.textBoxPicPath.TabIndex = 23;
            // 
            // textBoxMoneyIn
            // 
            this.textBoxMoneyIn.Location = new System.Drawing.Point(463, 307);
            this.textBoxMoneyIn.Name = "textBoxMoneyIn";
            this.textBoxMoneyIn.Size = new System.Drawing.Size(100, 28);
            this.textBoxMoneyIn.TabIndex = 24;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(686, 306);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 25;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Location = new System.Drawing.Point(686, 421);
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(100, 28);
            this.textBoxRemarks.TabIndex = 26;
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(686, 80);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxCardNum.TabIndex = 27;
            // 
            // comboBoxGarageNum
            // 
            this.comboBoxGarageNum.FormattingEnabled = true;
            this.comboBoxGarageNum.Location = new System.Drawing.Point(227, 81);
            this.comboBoxGarageNum.Name = "comboBoxGarageNum";
            this.comboBoxGarageNum.Size = new System.Drawing.Size(121, 26);
            this.comboBoxGarageNum.TabIndex = 28;
            // 
            // comboBoxSpaceNum
            // 
            this.comboBoxSpaceNum.FormattingEnabled = true;
            this.comboBoxSpaceNum.Location = new System.Drawing.Point(463, 83);
            this.comboBoxSpaceNum.Name = "comboBoxSpaceNum";
            this.comboBoxSpaceNum.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceNum.TabIndex = 29;
            // 
            // comboBoxPayMode
            // 
            this.comboBoxPayMode.FormattingEnabled = true;
            this.comboBoxPayMode.Location = new System.Drawing.Point(47, 422);
            this.comboBoxPayMode.Name = "comboBoxPayMode";
            this.comboBoxPayMode.Size = new System.Drawing.Size(121, 26);
            this.comboBoxPayMode.TabIndex = 30;
            // 
            // comboBoxDBAType
            // 
            this.comboBoxDBAType.FormattingEnabled = true;
            this.comboBoxDBAType.Location = new System.Drawing.Point(463, 423);
            this.comboBoxDBAType.Name = "comboBoxDBAType";
            this.comboBoxDBAType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxDBAType.TabIndex = 31;
            // 
            // dateTimePickerBillDate
            // 
            this.dateTimePickerBillDate.Location = new System.Drawing.Point(227, 195);
            this.dateTimePickerBillDate.Name = "dateTimePickerBillDate";
            this.dateTimePickerBillDate.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerBillDate.TabIndex = 32;
            // 
            // dateTimePickerCarInTime
            // 
            this.dateTimePickerCarInTime.Location = new System.Drawing.Point(463, 195);
            this.dateTimePickerCarInTime.Name = "dateTimePickerCarInTime";
            this.dateTimePickerCarInTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarInTime.TabIndex = 33;
            // 
            // dateTimePickerCarOutTime
            // 
            this.dateTimePickerCarOutTime.Location = new System.Drawing.Point(686, 196);
            this.dateTimePickerCarOutTime.Name = "dateTimePickerCarOutTime";
            this.dateTimePickerCarOutTime.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerCarOutTime.TabIndex = 34;
            // 
            // ParkingRecordEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(911, 568);
            this.Controls.Add(this.dateTimePickerCarOutTime);
            this.Controls.Add(this.dateTimePickerCarInTime);
            this.Controls.Add(this.dateTimePickerBillDate);
            this.Controls.Add(this.comboBoxDBAType);
            this.Controls.Add(this.comboBoxPayMode);
            this.Controls.Add(this.comboBoxSpaceNum);
            this.Controls.Add(this.comboBoxGarageNum);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxMoneyIn);
            this.Controls.Add(this.textBoxPicPath);
            this.Controls.Add(this.textBoxDBAName);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxBillNum);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ParkingRecordEdit";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.textBoxBillNum, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.textBoxDBAName, 0);
            this.Controls.SetChildIndex(this.textBoxPicPath, 0);
            this.Controls.SetChildIndex(this.textBoxMoneyIn, 0);
            this.Controls.SetChildIndex(this.textBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.textBoxRemarks, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.comboBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.comboBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.comboBoxPayMode, 0);
            this.Controls.SetChildIndex(this.comboBoxDBAType, 0);
            this.Controls.SetChildIndex(this.dateTimePickerBillDate, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarInTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCarOutTime, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
