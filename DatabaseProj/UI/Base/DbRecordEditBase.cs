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

        public DbRecordEditBase ()
        {
            InitializeComponent();
        }

        public virtual void dbString2Stru (ref List<string> listRecord)
        {
        }

        public virtual void dbString2Ui (ref List<string> listRecord)
        {
        }

        public virtual void dbStru2Ui ()
        {
        }

        public virtual object dbStruGet ()
        {
            return null;
        }

        public virtual void dbUi2Stru ()
        {
        }

        public virtual void dbUiInit ()
        {
        }

        protected void buttonOk_Click (object sender, EventArgs e)
        {
            dbUi2Stru();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected void buttonCancel_Click (object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
