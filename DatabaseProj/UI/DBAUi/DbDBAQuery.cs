using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.DBAUi {
    public class DbDBAQuery : DbRecordQueryBase {

        protected CDBAccountDb.SDBAccountQueryStru sQueryStru = new CDBAccountDb.SDBAccountQueryStru();

        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.CheckBox checkBoxAccountEn;
        private System.Windows.Forms.CheckBox checkBoxTypeEn;
        private System.Windows.Forms.CheckBox checkBoxAuthorityEn;
        private System.Windows.Forms.CheckBox checkBoxNameEn;
        private System.Windows.Forms.CheckBox checkBoxjobNumEn;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxJobNum;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxAuthority;
        private System.Windows.Forms.TextBox textBoxId;

        /// <summary>
        /// 数据库管理员查询 构造函数
        /// </summary>
        /// <param name="hDbTableBase">数据库管理员数据表基类</param>
        public DbDBAQuery (CDatebaseBase hDbTableBase, string strTitle = "DBA Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 数据库管理员查询 构造函数
        /// </summary>
        public DbDBAQuery () : base()
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        private void InitializeComponent ()
        {
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.checkBoxAccountEn = new System.Windows.Forms.CheckBox();
            this.checkBoxTypeEn = new System.Windows.Forms.CheckBox();
            this.checkBoxAuthorityEn = new System.Windows.Forms.CheckBox();
            this.checkBoxNameEn = new System.Windows.Forms.CheckBox();
            this.checkBoxjobNumEn = new System.Windows.Forms.CheckBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxJobNum = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxAuthority = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(206, 586);
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
            this.buttonCancel.Location = new System.Drawing.Point(797, 586);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(26, 29);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 3;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccountEn
            // 
            this.checkBoxAccountEn.AutoSize = true;
            this.checkBoxAccountEn.Location = new System.Drawing.Point(398, 30);
            this.checkBoxAccountEn.Name = "checkBoxAccountEn";
            this.checkBoxAccountEn.Size = new System.Drawing.Size(70, 22);
            this.checkBoxAccountEn.TabIndex = 4;
            this.checkBoxAccountEn.Text = "账号";
            this.checkBoxAccountEn.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypeEn
            // 
            this.checkBoxTypeEn.AutoSize = true;
            this.checkBoxTypeEn.Location = new System.Drawing.Point(827, 31);
            this.checkBoxTypeEn.Name = "checkBoxTypeEn";
            this.checkBoxTypeEn.Size = new System.Drawing.Size(70, 22);
            this.checkBoxTypeEn.TabIndex = 5;
            this.checkBoxTypeEn.Text = "类型";
            this.checkBoxTypeEn.UseVisualStyleBackColor = true;
            // 
            // checkBoxAuthorityEn
            // 
            this.checkBoxAuthorityEn.AutoSize = true;
            this.checkBoxAuthorityEn.Location = new System.Drawing.Point(26, 134);
            this.checkBoxAuthorityEn.Name = "checkBoxAuthorityEn";
            this.checkBoxAuthorityEn.Size = new System.Drawing.Size(70, 22);
            this.checkBoxAuthorityEn.TabIndex = 6;
            this.checkBoxAuthorityEn.Text = "权限";
            this.checkBoxAuthorityEn.UseVisualStyleBackColor = true;
            // 
            // checkBoxNameEn
            // 
            this.checkBoxNameEn.AutoSize = true;
            this.checkBoxNameEn.Location = new System.Drawing.Point(398, 126);
            this.checkBoxNameEn.Name = "checkBoxNameEn";
            this.checkBoxNameEn.Size = new System.Drawing.Size(70, 22);
            this.checkBoxNameEn.TabIndex = 7;
            this.checkBoxNameEn.Text = "姓名";
            this.checkBoxNameEn.UseVisualStyleBackColor = true;
            // 
            // checkBoxjobNumEn
            // 
            this.checkBoxjobNumEn.AutoSize = true;
            this.checkBoxjobNumEn.Location = new System.Drawing.Point(827, 127);
            this.checkBoxjobNumEn.Name = "checkBoxjobNumEn";
            this.checkBoxjobNumEn.Size = new System.Drawing.Size(70, 22);
            this.checkBoxjobNumEn.TabIndex = 8;
            this.checkBoxjobNumEn.Text = "工号";
            this.checkBoxjobNumEn.UseVisualStyleBackColor = true;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(26, 70);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 9;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Location = new System.Drawing.Point(398, 70);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(100, 28);
            this.textBoxAccount.TabIndex = 10;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(398, 164);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 28);
            this.textBoxName.TabIndex = 11;
            // 
            // textBoxJobNum
            // 
            this.textBoxJobNum.Location = new System.Drawing.Point(827, 164);
            this.textBoxJobNum.Name = "textBoxJobNum";
            this.textBoxJobNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxJobNum.TabIndex = 12;
            this.textBoxJobNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJobNum_KeyPress);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(827, 71);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxType.TabIndex = 13;
            // 
            // comboBoxAuthority
            // 
            this.comboBoxAuthority.FormattingEnabled = true;
            this.comboBoxAuthority.Location = new System.Drawing.Point(26, 164);
            this.comboBoxAuthority.Name = "comboBoxAuthority";
            this.comboBoxAuthority.Size = new System.Drawing.Size(121, 26);
            this.comboBoxAuthority.TabIndex = 14;
            // 
            // DbDBAQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1124, 658);
            this.Controls.Add(this.comboBoxAuthority);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxJobNum);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.checkBoxjobNumEn);
            this.Controls.Add(this.checkBoxNameEn);
            this.Controls.Add(this.checkBoxAuthorityEn);
            this.Controls.Add(this.checkBoxTypeEn);
            this.Controls.Add(this.checkBoxAccountEn);
            this.Controls.Add(this.checkBoxId);
            this.Name = "DbDBAQuery";
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxAccountEn, 0);
            this.Controls.SetChildIndex(this.checkBoxTypeEn, 0);
            this.Controls.SetChildIndex(this.checkBoxAuthorityEn, 0);
            this.Controls.SetChildIndex(this.checkBoxNameEn, 0);
            this.Controls.SetChildIndex(this.checkBoxjobNumEn, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxAccount, 0);
            this.Controls.SetChildIndex(this.textBoxName, 0);
            this.Controls.SetChildIndex(this.textBoxJobNum, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.comboBoxAuthority, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 数据库管理员查询 界面初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            for ( int i=0; i<CDbBaseTable.strDbBaseDBATypeDesc.Length; i++ ) {
                comboBoxType.Items.Add( CDbBaseTable.strDbBaseDBATypeDesc[i] );
            }
            for ( int i=0; i<CDbBaseTable.strDbBaseAuthorityDesc.Length; i++ ) {
                comboBoxAuthority.Items.Add( CDbBaseTable.strDbBaseAuthorityDesc[i] );
            }
        }

        /// <summary>
        /// 数据库管理员查询 UI转换到结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bAccountEn = checkBoxAccountEn.Checked;
            sQueryStru.bTypeEn = checkBoxTypeEn.Checked;
            sQueryStru.bAuthorityEn = checkBoxAuthorityEn.Checked;
            sQueryStru.bNameEn = checkBoxNameEn.Checked;
            sQueryStru.bJobNumEn = checkBoxjobNumEn.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bAccountEn ) {
                sQueryStru.strAccount = textBoxAccount.Text;
            }
            if ( sQueryStru .bTypeEn ) {
                sQueryStru.iType = comboBoxType.SelectedIndex;
            }
            if ( sQueryStru.bAuthorityEn ) {
                sQueryStru.iAuthority = comboBoxAuthority.SelectedIndex;
            }
            if ( sQueryStru.bNameEn ) {
                sQueryStru.strName = textBoxName.Text;
            }
            if ( sQueryStru .bJobNumEn ) {
                sQueryStru.strJobNum = textBoxJobNum.Text;
            }

            return sQueryStru;
        }

        private void textBoxId_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxJobNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
