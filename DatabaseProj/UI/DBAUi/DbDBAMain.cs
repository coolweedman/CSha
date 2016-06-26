using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.DBAUi {
    public class DbDBAMain : DbTableMainBase {

        protected CDatebaseBase hDbTable = null;

        public DbDBAMain (CDatebaseBase hDbBase, string strTitle = "Table") : base( hDbBase, strTitle )
        {
            hDbTable = hDbBase;
            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
        }

        protected override EDbDataShowStat dbTableAddProc ()
        {
            DbDBAEdit hDbDBAEdit = new DbDBAEdit();

            if ( DialogResult.OK == hDbDBAEdit.ShowDialog() ) {
                object sRecord = hDbDBAEdit.sDBAStru;
                if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL != hDbTable.dataBaseBaseCommAdd( ref sRecord  ) ) {
                    dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
                    return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
                } else {
                    return EDbDataShowStat.DBDATASHOW_FAILED;
                }
            } else {
                return EDbDataShowStat.DBDATASHOW_READY;
            }
        }
    }
}
