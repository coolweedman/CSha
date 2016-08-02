using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.RegularCardPaymentUi {

    public class RegularCardPaymentQuery : DbRecordQueryBase {

        private System.Windows.Forms.DateTimePicker dateTimePickerValidTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeStart;
        private System.Windows.Forms.TextBox textBoxPayMoney;
        private System.Windows.Forms.TextBox textBoxRcuId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxRcuId;
        private System.Windows.Forms.CheckBox checkBoxPayTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerValidTimeEnd;
        private System.Windows.Forms.CheckBox checkBoxValidTime;
        private System.Windows.Forms.CheckBox checkBoxPayMoney;
        protected CRegularCardPaymentDb.SRegularCardPaymentQueryStru sQueryStru;

        /// <summary>
        /// 停车卡缴费查询 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public RegularCardPaymentQuery (CDatebaseBase hDbTableBase, string strTitle = "Regular Card Query Window") : base( hDbTableBase, strTitle )
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
            dateTimePickerValidTimeEnd.Value = sDateTime;
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

                sDateTime = dateTimePickerValidTimeStart.Value;
                sQueryStru.sValidTimeStart = sDateTime;
                sDateTime = dateTimePickerValidTimeEnd.Value;
                sQueryStru.sValidTimeStop = sDateTime;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.dateTimePickerValidTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPayTimeStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxPayMoney = new System.Windows.Forms.TextBox();
            this.textBoxRcuId = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxRcuId = new System.Windows.Forms.CheckBox();
            this.checkBoxPayMoney = new System.Windows.Forms.CheckBox();
            this.checkBoxPayTime = new System.Windows.Forms.CheckBox();
            this.dateTimePickerPayTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerValidTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBoxValidTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerValidTimeStart
            // 
            this.dateTimePickerValidTimeStart.Location = new System.Drawing.Point(400, 170);
            this.dateTimePickerValidTimeStart.Name = "dateTimePickerValidTimeStart";
            this.dateTimePickerValidTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerValidTimeStart.TabIndex = 29;
            // 
            // dateTimePickerPayTimeStart
            // 
            this.dateTimePickerPayTimeStart.Location = new System.Drawing.Point(400, 110);
            this.dateTimePickerPayTimeStart.Name = "dateTimePickerPayTimeStart";
            this.dateTimePickerPayTimeStart.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeStart.TabIndex = 28;
            // 
            // textBoxPayMoney
            // 
            this.textBoxPayMoney.Location = new System.Drawing.Point(805, 57);
            this.textBoxPayMoney.Name = "textBoxPayMoney";
            this.textBoxPayMoney.Size = new System.Drawing.Size(100, 28);
            this.textBoxPayMoney.TabIndex = 27;
            this.textBoxPayMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPayMoney_KeyPress);
            // 
            // textBoxRcuId
            // 
            this.textBoxRcuId.Location = new System.Drawing.Point(400, 57);
            this.textBoxRcuId.Name = "textBoxRcuId";
            this.textBoxRcuId.Size = new System.Drawing.Size(100, 28);
            this.textBoxRcuId.TabIndex = 26;
            this.textBoxRcuId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRcuId_KeyPress);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(15, 57);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 25;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
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
            this.checkBoxRcuId.Location = new System.Drawing.Point(400, 20);
            this.checkBoxRcuId.Name = "checkBoxRcuId";
            this.checkBoxRcuId.Size = new System.Drawing.Size(106, 22);
            this.checkBoxRcuId.TabIndex = 31;
            this.checkBoxRcuId.Text = "固定卡ID";
            this.checkBoxRcuId.UseVisualStyleBackColor = true;
            // 
            // checkBoxPayMoney
            // 
            this.checkBoxPayMoney.AutoSize = true;
            this.checkBoxPayMoney.Location = new System.Drawing.Point(805, 20);
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
            this.dateTimePickerPayTimeEnd.Location = new System.Drawing.Point(805, 110);
            this.dateTimePickerPayTimeEnd.Name = "dateTimePickerPayTimeEnd";
            this.dateTimePickerPayTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerPayTimeEnd.TabIndex = 34;
            // 
            // dateTimePickerValidTimeEnd
            // 
            this.dateTimePickerValidTimeEnd.Location = new System.Drawing.Point(805, 170);
            this.dateTimePickerValidTimeEnd.Name = "dateTimePickerValidTimeEnd";
            this.dateTimePickerValidTimeEnd.Size = new System.Drawing.Size(200, 28);
            this.dateTimePickerValidTimeEnd.TabIndex = 35;
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
            this.ClientSize = new System.Drawing.Size(1106, 667);
            this.Controls.Add(this.checkBoxValidTime);
            this.Controls.Add(this.dateTimePickerValidTimeEnd);
            this.Controls.Add(this.dateTimePickerPayTimeEnd);
            this.Controls.Add(this.checkBoxPayTime);
            this.Controls.Add(this.checkBoxPayMoney);
            this.Controls.Add(this.checkBoxRcuId);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.dateTimePickerValidTimeStart);
            this.Controls.Add(this.dateTimePickerPayTimeStart);
            this.Controls.Add(this.textBoxPayMoney);
            this.Controls.Add(this.textBoxRcuId);
            this.Controls.Add(this.textBoxId);
            this.Name = "RegularCardPaymentQuery";
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxRcuId, 0);
            this.Controls.SetChildIndex(this.textBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeStart, 0);
            this.Controls.SetChildIndex(this.dateTimePickerValidTimeStart, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxRcuId, 0);
            this.Controls.SetChildIndex(this.checkBoxPayMoney, 0);
            this.Controls.SetChildIndex(this.checkBoxPayTime, 0);
            this.Controls.SetChildIndex(this.dateTimePickerPayTimeEnd, 0);
            this.Controls.SetChildIndex(this.dateTimePickerValidTimeEnd, 0);
            this.Controls.SetChildIndex(this.checkBoxValidTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxRcuId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxPayMoney_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
