using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI {
    class RegularCardPaymentUi : DbWinBase {

        CRegularCardPaymentDb hRegularCardPaymentDb;
        RegularCardPaymentEdit hRegularCardPaymentEdit;

        public RegularCardPaymentUi ()
        {
            hRegularCardPaymentDb = new CRegularCardPaymentDb();
            hRegularCardPaymentEdit = new RegularCardPaymentEdit();

            this.Text = "固定卡缴费记录";

            dbWinBaseInit( hRegularCardPaymentDb, hRegularCardPaymentEdit );
        }
    }
}
