using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI {
    public partial class DBALogInMain : Form {
        public DBALogInMain ()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click (object sender, EventArgs e)
        {
            CDBAccountDb.SDBAccountStru sDbaStru = new CDBAccountDb.SDBAccountStru();
            CDBAccountDb hDbaAccountDb = new CDBAccountDb();

            sDbaStru.strAccount = textBoxAccount.Text;

            if ( hDbaAccountDb.dbAccountRead( ref sDbaStru ) ) {
                if ( sDbaStru.strPassword == textBoxPassword.Text) {
                    MessageBox.Show( "登录成功" );
                } else {
                    MessageBox.Show( "账号或密码错误" );
                }
            } else {
                MessageBox.Show( "账号不存在" );
            }

            this.Close();
        }
    }
}
