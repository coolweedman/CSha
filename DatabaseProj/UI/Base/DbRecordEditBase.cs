using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProj.UI.Base {
    public partial class DbRecordEditBase : Form {

        public DbDataShowBase.EDbDataShowStat eCloseStat = DbDataShowBase.EDbDataShowStat.DBDATASHOW_READY;

        public DbRecordEditBase (string strTitle = "DbRecordEditBase")
        {
            InitializeComponent();

            this.Text = strTitle;
        }

        protected virtual void dbString2Stru (ref List<string> listRecord)
        {
        }

        protected virtual void dbString2Ui (ref List<string> listRecord)
        {
        }

        protected virtual void dbStru2Ui ()
        {
        }

        protected virtual object dbStruGet ()
        {
            return null;
        }

        protected virtual void dbUi2Stru ()
        {
        }

        protected virtual void dbUiInit ()
        {
        }

        private void buttonOk_Click (object sender, EventArgs e)
        {
            dbUi2Stru();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click (object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
