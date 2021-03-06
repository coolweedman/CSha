﻿using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DatabaseProj.Code.Comm;

namespace DatabaseProj.UI.DBAUi {

    public class DbDBAEdit : DbRecordEditBase {
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxAuthority;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxJobNuym;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public CDBAccountDb.SDBAccountStru sDBAStru;

        /// <summary>
        /// 数据库管理员编辑 构造函数
        /// </summary>
        /// <param name="strTitle"></param>
        public DbDBAEdit (string strTitle="DBA Edit") : base(strTitle)
        {
            InitializeComponent ();
            dbUiInit();
        }

        /// <summary>
        /// 数据库管理员编辑 UI初始化
        /// </summary>
        public override void dbUiInit ()
        {
            foreach ( string str in CDbBaseTable.strDbBaseDBATypeDesc ) {
                comboBoxType.Items.Add( str );
            }

            foreach ( string str in CDbBaseTable.strDbBaseAuthorityDesc ) {
                comboBoxAuthority.Items.Add( str );
            }

            textBoxId.Text = "0";
            textBoxId.Enabled = false;
            comboBoxType.SelectedIndex = (int)CDBAccountDb.EDBAccountType.DBATYPE_USER;
            comboBoxAuthority.SelectedIndex = (int)CDBAccountDb.EDBAccountAuthority.DBAAUTHORITY_READ;
        }

        /// <summary>
        /// 数据库管理员编辑 字符串转结构体
        /// </summary>
        /// <param name="listRecord"></param>
        public override void dbString2Stru (ref List<string> listRecord)
        {
            int i = 0;

            try {
                sDBAStru.iId = int.Parse( listRecord[i++] );
                sDBAStru.iType = int.Parse( listRecord[i++] );
                sDBAStru.strAccount = listRecord[i++];
                sDBAStru.strPassword = listRecord[i++];
                sDBAStru.iAuthority = int.Parse( listRecord[i++] );
                sDBAStru.strName = listRecord[i++];
                sDBAStru.strJobNum = listRecord[i++];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库管理员编辑 字符串转到UI
        /// </summary>
        /// <param name="listRecord"></param>
        public override void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            try { 
                textBoxId.Text = listRecord[i++];
                comboBoxType.SelectedIndex = CDbBaseTable.dicDbBaseDBATypeDesc[listRecord[i++]];
                textBoxAccount.Text = listRecord[i++];
                textBoxPassword.Text = listRecord[i++];
                comboBoxAuthority.SelectedIndex = CDbBaseTable.dicDbBaseAuthorityDesc[listRecord[i++]];
                textBoxName.Text = listRecord[i++];
                textBoxJobNuym.Text = listRecord[i++];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库管理员编辑 结构体转到UI
        /// </summary>
        public override void dbStru2Ui ()
        {
            try {
                textBoxId.Text = sDBAStru.iId.ToString();
                comboBoxType.SelectedIndex = sDBAStru.iType;
                textBoxAccount.Text = sDBAStru.strAccount;
                textBoxPassword.Text = sDBAStru.strPassword;
                comboBoxAuthority.SelectedIndex = sDBAStru.iAuthority;
                textBoxName.Text = sDBAStru.strAccount;
                textBoxJobNuym.Text = sDBAStru.strPassword;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbStru2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库管理员编辑 获取结构体
        /// </summary>
        /// <returns></returns>
        public override object dbStruGet ()
        {
            return sDBAStru;
        }

        /// <summary>
        /// 数据库管理员编辑 UI转到结构体
        /// </summary>
        public override void dbUi2Stru ()
        {
            try {
                sDBAStru.iId = int.Parse( textBoxId.Text );
                sDBAStru.iType = comboBoxType.SelectedIndex;
                sDBAStru.strAccount = textBoxAccount.Text;
                sDBAStru.strPassword = textBoxPassword.Text;
                sDBAStru.iAuthority = comboBoxAuthority.SelectedIndex;
                sDBAStru.strName = textBoxName.Text;
                sDBAStru.strJobNum = textBoxJobNuym.Text;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbUi2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库管理员编辑 UI输入检测
        /// </summary>
        /// <returns></returns>
        public override EDbEditUiStat dbUiStatChk ()
        {
            if ( -1 == comboBoxType.SelectedIndex　) {
                dbUiStatSet( "管理员类型未选择..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxAccount.Text ) {
                textBoxAccount.Select();
                dbUiStatSet( "管理员登录账号未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxPassword.Text ) {
                textBoxPassword.Select();
                dbUiStatSet( "管理员登录密码未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxName.Text ) {
                textBoxName.Select();
                dbUiStatSet( "管理员姓名未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }

            return EDbEditUiStat.DBEDITUISTAT_OK;
        }

        private new void InitializeComponent ()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxAuthority = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxJobNuym = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
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
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(339, 253);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 38);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOk.Location = new System.Drawing.Point(177, 253);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 38);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "权限";
            // 
            // comboBoxAuthority
            // 
            this.comboBoxAuthority.FormattingEnabled = true;
            this.comboBoxAuthority.Location = new System.Drawing.Point(17, 169);
            this.comboBoxAuthority.Name = "comboBoxAuthority";
            this.comboBoxAuthority.Size = new System.Drawing.Size(121, 26);
            this.comboBoxAuthority.TabIndex = 26;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(158, 67);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxType.TabIndex = 25;
            // 
            // textBoxJobNuym
            // 
            this.textBoxJobNuym.Location = new System.Drawing.Point(326, 167);
            this.textBoxJobNuym.Name = "textBoxJobNuym";
            this.textBoxJobNuym.Size = new System.Drawing.Size(100, 28);
            this.textBoxJobNuym.TabIndex = 24;
            this.textBoxJobNuym.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJobNuym_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(158, 170);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 28);
            this.textBoxName.TabIndex = 23;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(479, 66);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 28);
            this.textBoxPassword.TabIndex = 22;
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Location = new System.Drawing.Point(326, 66);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(100, 28);
            this.textBoxAccount.TabIndex = 21;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(17, 66);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "工号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "姓名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "ID";
            // 
            // DbDBAEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(590, 325);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAuthority);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxJobNuym);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DbDBAEdit";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxAccount, 0);
            this.Controls.SetChildIndex(this.textBoxPassword, 0);
            this.Controls.SetChildIndex(this.textBoxName, 0);
            this.Controls.SetChildIndex(this.textBoxJobNuym, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.comboBoxAuthority, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxJobNuym_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
