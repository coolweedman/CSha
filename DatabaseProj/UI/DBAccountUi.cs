using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;


namespace DatabaseProj.UI {
    public class DBAccountUi : DbWinBase {

        CDBAccountDb hDBAccountDb;
        DBAccountEdit hDBAccountEdit;

        public DBAccountUi ()
        {
            hDBAccountDb = new CDBAccountDb();
            hDBAccountEdit = new DBAccountEdit();

            hDBAccountDb.dataBaseBaseDeRecordInsert();

            dbWinBaseInit( hDBAccountDb, hDBAccountEdit );
        }
    }
}
