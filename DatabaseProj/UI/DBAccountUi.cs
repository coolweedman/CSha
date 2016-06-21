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

            this.Text = "数据库管理员窗口";
            dbWinBaseInit( hDBAccountDb, hDBAccountEdit );
        }
    }
}
