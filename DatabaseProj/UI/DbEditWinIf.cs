using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProj.UI {

    interface DbEditWinIf {
        void dbUiInit ();
        void dbUi2Stru ();
        void dbStru2Ui ();
        void dbString2Ui (ref List<string> listRecord);
        void dbString2Stru ();
        void dbUiSHowDialog ();

        void dbUiUpdateModeSet ();
        void dbUiAddModeSet ();

        object dbStruGet ();
        DialogResult dbFinishStatGet ();
    }
}
