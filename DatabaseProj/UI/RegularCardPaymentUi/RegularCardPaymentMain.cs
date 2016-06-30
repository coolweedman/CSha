using DatabaseProj.Code.Database;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.RegularCardPaymentUi {

    public class RegularCardPaymentMain : DbTableMainBase {

        public RegularCardPaymentMain (CDatebaseBase hDbBase, string strTitle = "Regular Card Payment Main Window") : base( hDbBase, strTitle )
        {
            
        }

        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbTableAddProc();
        }

        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbRecordEditProc();
        }

        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbRecordDeleteProc();
        }


    }
}
