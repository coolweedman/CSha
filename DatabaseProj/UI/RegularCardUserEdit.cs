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
                sRcuStru.iCardType = CRegularCardUserDb.dicRcuCardType2Enum[listRecord[i++]];
                sRcuStru.iCarType = CRegularCardUserDb.dicRcuCarType2Enum[listRecord[i++]];
                sRcuStru.sPayTime = Convert.ToDateTime( listRecord[i++] );
                sRcuStru.dPayMoney = double.Parse( listRecord[i++] );
                sRcuStru.sVaildTime = Convert.ToDateTime( listRecord[i++] );
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Read record fail..." );
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
                comboBoxCardType.SelectedIndex = CRegularCardUserDb.dicRcuCardType2Enum[listRecord[i++]];
                comboBoxCarType.SelectedIndex = CRegularCardUserDb.dicRcuCarType2Enum[listRecord[i++]];
                dateTimePickerPayTime.Value = Convert.ToDateTime( listRecord[i++] );
                textBoxPayMoney.Text = listRecord[i++];
                dateTimePickerValidTime.Value = Convert.ToDateTime( listRecord[i++] );
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Read record fail..." );
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
            dateTimePickerPayTime.Value = sRcuStru.sPayTime;
            textBoxPayMoney.Text = sRcuStru.dPayMoney.ToString();
            dateTimePickerValidTime.Value = sRcuStru.sVaildTime;
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
                sRcuStru.sPayTime = dateTimePickerPayTime.Value;
                sRcuStru.dPayMoney = double.Parse( textBoxPayMoney.Text );
                sRcuStru.sVaildTime = dateTimePickerValidTime.Value;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Read record fail..." );
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

            for ( i=0; i<CRegularCardUserDb.strRcuCardTypeDesc.Length; i++ ) {
                comboBoxCardType.Items.Add( CRegularCardUserDb.strRcuCardTypeDesc[i] );
            }
            for ( i=0; i<CRegularCardUserDb.strRcuCarTypeDesc.Length; i++ ) {
                comboBoxCarType.Items.Add( CRegularCardUserDb.strRcuCarTypeDesc[i] );
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
