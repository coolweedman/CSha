using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI {
    class RegularCardPaymentUi : DbWinBase {

        CRegularCardPayment hRegularCardPaymentDb;
        RegularCardPaymentEdit hRegularCardPaymentEdit;

        public RegularCardPaymentUi ()
        {
            hRegularCardPaymentDb = new CRegularCardPayment();
            hRegularCardPaymentEdit = new RegularCardPaymentEdit();

            hRegularCardPaymentDb.dataBaseBaseDeRecordInsert();
            this.Text = "固定卡缴费记录";

            dbWinBaseInit( hRegularCardPaymentDb, hRegularCardPaymentEdit );
        }
    }
}
