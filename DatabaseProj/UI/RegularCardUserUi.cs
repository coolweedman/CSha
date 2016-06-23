using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using DatabaseProj.UI;


namespace DatabaseProj.UI {
    public class RegularCardUserUi : DbWinBase {

        CRegularCardUserDb hRegularCardUserDb;
        RegularCardUserEdit hRegularCardUserEdit;

        public RegularCardUserUi ()
        {
            hRegularCardUserDb = new CRegularCardUserDb();
            hRegularCardUserEdit = new RegularCardUserEdit ();

            dbWinBaseInit( hRegularCardUserDb , hRegularCardUserEdit );
        }
    }
}
