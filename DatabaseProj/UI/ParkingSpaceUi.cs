using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;


namespace DatabaseProj.UI {
    class ParkingSpaceUi : DbWinBase {

        CParkingSpaceDb hParingSpaceDb;
        ParkingSpaceEdit hParkingSpaceEdit;

        public ParkingSpaceUi ()
        {
            hParingSpaceDb = new CParkingSpaceDb();

            hParingSpaceDb.dataBaseBaseDeRecordInsert();
        }
    }
}
