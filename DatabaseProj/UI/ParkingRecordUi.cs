using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using System.Data;

namespace DatabaseProj.UI {
    public class ParkingRecordUi : DbWinBase {

        public ParkingRecordUi ()
        {
            hDatabaseBase = new CParkingRecordDb();
            hDatabaseBase.dataBaseBaseDeRecordInsert();
            hDataTable = new DataTable();

            dbDgvReFlash();
        }
    }
}
