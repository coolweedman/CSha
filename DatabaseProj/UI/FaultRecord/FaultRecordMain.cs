﻿using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.FaultRecord {

    public class FaultRecordMain : DbTableMainBase {

        public FaultRecordMain (CDatebaseBase hDbBase, string strTitle = "Fault Record Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( CFaultRecordDb.strFaultRecordHeadDesc );
        }

    }
}
