using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardView : CDatebaseBase {

        protected CRegularCardUserDb hRegularCardUserDb;
        protected CRegularCardPaymentDb hRegularCardPaymentDb;

        public CRegularCardView ()
        {
            hRegularCardUserDb = new CRegularCardUserDb();
            hRegularCardPaymentDb = new CRegularCardPaymentDb();

            rcvViewCreate();
        }

        public void rcvViewCreate ()
        {
            string strCreateTable = "CREATE VIEW IF NOT EXISTS  RegularCardView AS SELECT " +
                                    "RegularCardUser.Id, RegularCardUser.UserName, RegularCardPayment.PayMoney " +
                                    "FROM RegularCardUser INNER JOIN RegularCardPayment " +
                                    "ON   RegularCardUser.Id = RegularCardPayment.RcuId";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardView";
            base.dataBaseBaseRecordRead();

            return hReader;
        }
    }
}
