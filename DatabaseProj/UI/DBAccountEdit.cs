using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using System.Diagnostics;


namespace DatabaseProj.UI {
    public partial class DBAccountEdit : Form, DbEditWinIf {

        public CDBAccountDb.SDBAccountStru sDBAStru;
        public DialogResult eDialogResult = DialogResult.OK;

        public DBAccountEdit ()
        {
            InitializeComponent();
            dbUiInit();
        }

        public DialogResult dbFinishStatGet ()
        {
            return eDialogResult;
        }

        public void dbString2Stru (ref List<string> listRecord)
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

        public void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            textBoxId.Text = listRecord[i++];
            comboBoxType.SelectedIndex = CDbBaseTable.dicDbBaseDBATypeDesc[listRecord[i++]];
            textBoxAccount.Text = listRecord[i++];
            textBoxPassword.Text = listRecord[i++];
            comboBoxAuthority.SelectedIndex = CDbBaseTable.dicDbBaseAuthorityDesc[listRecord[i++]];
            textBoxName.Text = listRecord[i++];
            textBoxJobNuym.Text = listRecord[i++];
        }

        public void dbStru2Ui ()
        {
            textBoxId.Text = sDBAStru.iId.ToString();
            comboBoxType.SelectedIndex = sDBAStru.iType;
            textBoxAccount.Text = sDBAStru.strAccount;
            textBoxPassword.Text = sDBAStru.strPassword;
            comboBoxAuthority.SelectedIndex = sDBAStru.iAuthority;
            textBoxName.Text = sDBAStru.strAccount;
            textBoxJobNuym.Text = sDBAStru.strPassword;
        }

        public object dbStruGet ()
        {
            return sDBAStru;
        }

        public void dbUi2Stru ()
        {
            sDBAStru.iId = int.Parse( textBoxId.Text );
            sDBAStru.iType = comboBoxType.SelectedIndex;
            sDBAStru.strAccount = textBoxAccount.Text;
            sDBAStru.strPassword = textBoxPassword.Text;
            sDBAStru.iAuthority = comboBoxAuthority.SelectedIndex;
            sDBAStru.strName = textBoxName.Text;
            sDBAStru.strJobNum = textBoxJobNuym.Text;
        }

        public void dbUiAddModeSet ()
        {
            textBoxId.Enabled = false;
        }

        public void dbUiInit ()
        {
            foreach ( string str in CDbBaseTable.strDbBaseDBATypeDesc) {
                comboBoxType.Items.Add( str );
            }
            foreach( string str in CDbBaseTable.strDbBaseAuthorityDesc ) {
                comboBoxAuthority.Items.Add( str );
            }

            textBoxId.Text = "0";
        }

        public void dbUiShowDialog ()
        {
            this.ShowDialog();
        }

        public void dbUiUpdateModeSet ()
        {
            textBoxId.Enabled = false;
        }

        private void buttonOk_Click (object sender, EventArgs e)
        {
            dbUi2Stru();
            eDialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonCancel_Click (object sender, EventArgs e)
        {
            eDialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
