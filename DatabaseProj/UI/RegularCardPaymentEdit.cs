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
    public partial class RegularCardPaymentEdit : Form, DbEditWinIf {

        public CRegularCardPayment.SRegularCardPaymentStru sRcpStru;
        public DialogResult eDialogResult = DialogResult.OK;

        public RegularCardPaymentEdit ()
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
                sRcpStru.iId = int.Parse( listRecord[i++] );
                sRcpStru.iRcuId = int.Parse( listRecord[i++] );
                sRcpStru.sPayTime = Convert.ToDateTime( listRecord[i++] );
                sRcpStru.dPayMoney = double.Parse( listRecord[i++] );
                sRcpStru.sVaildTime = Convert.ToDateTime( listRecord[i++] );
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
                textBoxRcuId.Text = listRecord[i++];
                dateTimePickerPayTime.Value = Convert.ToDateTime( listRecord[i++] );
                textBoxPayMoney.Text = listRecord[i++];
                dateTimePickerVaildTime.Value = Convert.ToDateTime( listRecord[i++] );
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public void dbStru2Ui ()
        {
            textBoxId.Text = sRcpStru.iId.ToString();
            textBoxRcuId.Text = sRcpStru.iRcuId.ToString();
            dateTimePickerPayTime.Value = sRcpStru.sPayTime;
            textBoxPayMoney.Text = sRcpStru.dPayMoney.ToString();
            dateTimePickerVaildTime.Value = sRcpStru.sVaildTime;
        }

        public object dbStruGet ()
        {
            return sRcpStru;
        }

        public void dbUi2Stru ()
        {
            sRcpStru.iId = int.Parse( textBoxId.Text );
            sRcpStru.iRcuId = int.Parse( textBoxRcuId.Text );
            sRcpStru.sPayTime = dateTimePickerPayTime.Value;
            sRcpStru.dPayMoney = double.Parse( textBoxPayMoney.Text );
            sRcpStru.sVaildTime = dateTimePickerVaildTime.Value;
        }

        public void dbUiAddModeSet ()
        {
            textBoxId.Enabled = false;
        }

        public void dbUiInit ()
        {
            textBoxId.Text = "0";
            textBoxRcuId.Text = "1";
        }

        public void dbUiShowDialog ()
        {
            this.ShowDialog();
        }

        public void dbUiUpdateModeSet ()
        {
            textBoxId.Enabled = false;
        }

        private void RegularCardPaymentEdit_Load (object sender, EventArgs e)
        {

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
