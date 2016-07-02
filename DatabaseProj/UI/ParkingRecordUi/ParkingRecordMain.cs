using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.ParkingRecordUi {

    public class ParkingRecordMain : DbTableMainBase {

        public ParkingRecordMain (CDatebaseBase hDbBase, string strTitle = "Parking Record Main Window") : base( hDbBase, strTitle )
        {
        }
    }
}
