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
    public partial class RegularCardUserEdit : Form, DbEditWinIf {

        public CRegularCardUserDb.SRegularCardUserStru sRcuStru;
        public DialogResult eDialogResult = DialogResult.OK;

        public RegularCardUserEdit ()
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
                sRcuStru.iId = int.Parse( listRecord[i++] );
                sRcuStru.strUserName = listRecord[i++];
                sRcuStru.strUserIdent = listRecord[i++];
                sRcuStru.strUserPhone = listRecord[i++];
                sRcuStru.strCarPlate = listRecord[i++];
                sRcuStru.strCardNum = listRecord[i++];
                sRcuStru.iCardType = CDbBaseTable.dicDbBaseParkingCardTypeDesc[listRecord[i++]];
                sRcuStru.iCarType = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            try {
                textBoxId.Text = listRecord[i++];
                textBoxUserName.Text = listRecord[i++];
                textBoxUserIdent.Text = listRecord[i++];
                textBoxUserPhone.Text = listRecord[i++];
                textBoxCarPlate.Text = listRecord[i++];
                textBoxCardNum.Text = listRecord[i++];
                comboBoxCardType.SelectedIndex = CDbBaseTable.dicDbBaseParkingCardTypeDesc[listRecord[i++]];
                comboBoxCarType.SelectedIndex = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public void dbStru2Ui ()
        {
            textBoxId.Text = sRcuStru.iId.ToString();
            textBoxUserName.Text = sRcuStru.strUserName;
            textBoxUserIdent.Text = sRcuStru.strUserIdent;
            textBoxUserPhone.Text = sRcuStru.strUserPhone;
            textBoxCarPlate.Text = sRcuStru.strCarPlate;
            textBoxCardNum.Text = sRcuStru.strCardNum;
            comboBoxCardType.SelectedIndex = sRcuStru.iCardType;
            comboBoxCarType.SelectedIndex = sRcuStru.iCarType;
        }

        public object dbStruGet ()
        {
            return sRcuStru;
        }

        public void dbUi2Stru ()
        {
            try {
                sRcuStru.iId = int.Parse( textBoxId.Text );
                sRcuStru.strUserName = textBoxUserName.Text;
                sRcuStru.strUserIdent = textBoxUserIdent.Text;
                sRcuStru.strUserPhone = textBoxUserPhone.Text;
                sRcuStru.strCarPlate = textBoxCarPlate.Text;
                sRcuStru.strCardNum = textBoxCardNum.Text;
                sRcuStru.iCardType = comboBoxCardType.SelectedIndex;
                sRcuStru.iCarType = comboBoxCarType.SelectedIndex;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbUi2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public void dbUiAddModeSet ()
        {
            textBoxId.Enabled = false;
        }

        public void dbUiInit ()
        {
            int i;

            for ( i=0; i< CDbBaseTable.strDbBaseParkingCardTypeDesc.Length; i++ ) {
                comboBoxCardType.Items.Add( CDbBaseTable.strDbBaseParkingCardTypeDesc[i] );
            }
            for ( i=0; i< CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxCarType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }

            textBoxId.Text = "0";
            textBoxPayMoney.Text = "0.0";
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
