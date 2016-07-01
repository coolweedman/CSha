using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI.RegularCardPaymentUi {

    public class RegularCardPaymentQuery : DbRecordQueryBase {

        private System.Windows.Forms.DateTimePicker dateTimePickerVaildTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeStart;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxRcuId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxRcuId;
        private System.Windows.Forms.CheckBox checkBoxPayTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerVaildTimeEnd;
        private System.Windows.Forms.CheckBox checkBoxValidTime;
        private System.Windows.Forms.CheckBox checkBoxPayMoney;

        protected CRegularCardPaymentDb.SRegularCardPaymentQueryStru sQueryStru;

        /// <summary>
        /// 停车卡缴费查询 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public RegularCardPaymentQuery (CDatebaseBase hDbTableBase, string strTitle = "DBA Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 停车卡缴费查询 UI初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            DateTime sDateTime = new DateTime( 2020, 12, 31 );
            dateTimePickerVaildTimeEnd.Value = sDateTime;
        }

        /// <summary>
        /// 停车卡缴费查询 UI转结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bRcuIdEn = checkBoxRcuId.Checked;
            sQueryStru.bPayMoneyEn = checkBoxPayMoney.Checked;
            sQueryStru.bPayTimeEn = checkBoxPayTime.Checked;
            sQueryStru.bValidTimeEn = checkBoxValidTime.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bRcuIdEn ) {
                sQueryStru.iRcuId = int.Parse( textBoxRcuId.Text );
            }
            if ( sQueryStru .bPayMoneyEn ) {
                sQueryStru.dPayMoney = double.Parse( textBoxPayMoney.Text );
            }
            if ( sQueryStru.bPayTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerPayTimeStart.Value;
                sQueryStru.sPayTimeStart = sDateTime;
                sDateTime = dateTimePickerPayTimeEnd.Value;
                sQueryStru.sPayTimeStop = sDateTime;
            }
            if ( sQueryStru .bValidTimeEn ) {
                DateTime sDateTime;

                sDateTime = dateTimePickerVaildTimeStart.Value;
                sQueryStru.sValidTimeStart = sDateTime;
                sDateTime = dateTimePickerVaildTimeEnd.Value;
                sQueryStru.sValidTimeStop = sDateTime;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.dateTimePickerVaildTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPayTimeStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxRcuId = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxRcuId = new System.Windows.Forms.CheckBox();
            this.checkBoxPayMoney = new System.Windows.Forms.CheckBox();
            this.checkBoxPayTime = new System.Windows.Forms.CheckBox();
            this.dateTimePickerPayTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVaildTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxValidTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerVaildTimeStart
            // 
            this.dateTimePickerVaildTimeStart.Location = new System.Drawing.Point(250, 170);
            this.dateTimePickerVaildTimeStart.Name = "dateTimePickerVaildTimeStart";
            this.dateTimePickerVaildTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerVaildTimeStart.TabIndex = 29;
            // 
            // dateTimePickerPayTimeStart
            // 
            this.dateTimePickerPayTimeStart.Location = new System.Drawing.Point(250, 110);
            this.dateTimePickerPayTimeStart.Name = "dateTimePickerPayTimeStart";
            this.dateTimePickerPayTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeStart.TabIndex = 28;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(523, 57);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 27;
            // 
            // textBoxRcuId
            // 
            this.textBoxRcuId.Location = new System.Drawing.Point(250, 57);
            this.textBoxRcuId.Name = "textBoxRcuId";
            this.textBoxRcuId.Size = new System.Drawing.Size(100, 28);
            this.textBoxRcuId.TabIndex = 26;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(15, 57);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 25;
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(15, 20);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 30;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // checkBoxRcuId
            // 
            this.checkBoxRcuId.AutoSize = true;
            this.checkBoxRcuId.Location = new System.Drawing.Point(250, 20);
            this.checkBoxRcuId.Name = "checkBoxRcuId";
            this.checkBoxRcuId.Size = new System.Drawing.Size(106, 22);
            this.checkBoxRcuId.TabIndex = 31;
            this.checkBoxRcuId.Text = "固定卡ID";
            this.checkBoxRcuId.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayMoney
            // 
            this.checkBoxPayMoney.AutoSize = true;
            this.checkBoxPayMoney.Location = new System.Drawing.Point(523, 20);
            this.checkBoxPayMoney.Name = "checkBoxPayMoney";
            this.checkBoxPayMoney.Size = new System.Drawing.Size(106, 22);
            this.checkBoxPayMoney.TabIndex = 32;
            this.checkBoxPayMoney.Text = "付款金额";
            this.checkBoxPayMoney.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayTime
            // 
            this.checkBoxPayTime.AutoSize = true;
            this.checkBoxPayTime.Location = new System.Drawing.Point(15, 110);
            this.checkBoxPayTime.Name = "checkBoxPayTime";
            this.checkBoxPayTime.Size = new System.Drawing.Size(124, 22);
            this.checkBoxPayTime.TabIndex = 33;
            this.checkBoxPayTime.Text = "付款时间段";
            this.checkBoxPayTime.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerPayTimeEnd
            // 
            this.dateTimePickerPayTimeEnd.Location = new System.Drawing.Point(523, 110);
            this.dateTimePickerPayTimeEnd.Name = "dateTimePickerPayTimeEnd";
            this.dateTimePickerPayTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeEnd.TabIndex = 34;
            // 
            // dateTimePickerVaildTimeEnd
            // 
            this.dateTimePickerVaildTimeEnd.Location = new System.Drawing.Point(523, 170);
            this.dateTimePickerVaildTimeEnd.Name = "dateTimePickerVaildTimeEnd";
            this.dateTimePickerVaildTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerVaildTimeEnd.TabIndex = 35;
            // 
            // checkBoxValidTime
            // 
            this.checkBoxValidTime.AutoSize = true;
            this.checkBoxValidTime.Location = new System.Drawing.Point(15, 170);
            this.checkBoxValidTime.Name = "checkBoxValidTime";
            this.checkBoxValidTime.Size = new System.Drawing.Size(124, 22);
            this.checkBoxValidTime.TabIndex = 36;
            this.checkBoxValidTime.Text = "有效时间段";
            this.checkBoxValidTime.UseVisualStyleBackColor = true;
            // 
            // RegularCardPaymentQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(737, 667);
            this.Controls.Add(this.checkBoxValidTime);
            this.Controls.Add(this.dateTimePickerVaildTimeEnd);
            this.Controls.Add(this.dateTimePickerPayTimeEnd);
            this.Controls.Add(this.checkBoxPayTime);
            this.Controls.Add(this.checkBoxPayMoney);
            this.Controls.Add(this.checkBoxRcuId);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.dateTimePickerVaildTimeStart);
            this.Controls.Add(this.dateTimePickerPayTimeStart);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxRcuId);
            this.Controls.Add(this.textBoxId);
            this.Name = "RegularCardPaymentQuery";
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxRcuId, 0);
            this.Controls.SetChildIndex(this.textBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerVaildTimeStart, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxRcuId, 0);
            this.Controls.SetChildIndex(this.checkBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.checkBoxPayTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeEnd, 0);
            this.Controls.SetChildIndex(this.dateTimePickerVaildTimeEnd, 0);
            this.Controls.SetChildIndex(this.checkBoxValidTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
