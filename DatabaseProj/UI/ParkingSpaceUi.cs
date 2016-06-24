using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;


namespace DatabaseProj.UI {
    public class ParkingSpaceUi : DbWinBase {

        CParkingSpaceDb hParingSpaceDb;
        ParkingSpaceEdit hParkingSpaceEdit;

        public ParkingSpaceUi ()
        {
            hParingSpaceDb = new CParkingSpaceDb();
            hParkingSpaceEdit = new ParkingSpaceEdit();

            this.Text = "停车位数据库";

            dbWinBaseInit( hParingSpaceDb, hParkingSpaceEdit );
        }

        public override void dbWinQueryProc ()
        {
            ParkingSpaceQueryUi hParkingSpaceQueryUi = new ParkingSpaceQueryUi( hParingSpaceDb );
            hParkingSpaceQueryUi.Show();
        }
    }
}
