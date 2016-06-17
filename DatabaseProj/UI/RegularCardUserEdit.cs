using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProj.UI {
    public partial class RegularCardUserEdit : Form, DbEditWinIf {

        public RegularCardUserEdit ()
        {
            InitializeComponent();
        }

        public DialogResult dbFinishStatGet ()
        {
            return DialogResult.Cancel;
        }

        public void dbString2Stru ()
        {

        }

        public void dbString2Ui (ref List<string> listRecord)
        {

        }

        public void dbStru2Ui ()
        {

        }

        public object dbStruGet ()
        {
            return null;
        }

        public void dbUi2Stru ()
        {

        }

        public void dbUiAddModeSet ()
        {

        }

        public void dbUiInit ()
        {

        }

        public void dbUiSHowDialog ()
        {

        }

        public void dbUiUpdateModeSet ()
        {

        }
    }
}
