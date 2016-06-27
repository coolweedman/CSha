using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.DBAUi {
    public class DbDBAMain : DbTableMainBase {

        /// <summary>
        /// 构造函数 待参数
        /// </summary>
        /// <param name="hDbBase"></param>
        /// <param name="strTitle"></param>
        public DbDBAMain (CDatebaseBase hDbBase, string strTitle = "Table") : base( hDbBase, strTitle )
        {
            hDbTable = hDbBase;
            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
            dbDataShowHeadSet( CDBAccountDb.strDBAccountHeadDesc );
        }

        /// <summary>
        /// 构造函数 为UI设计添加
        /// </summary>
        public DbDBAMain () : base(null)
        {
            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
            dbDataShowHeadSet( CDBAccountDb.strDBAccountHeadDesc );
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 编辑处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            DbDBAEdit hDbDBAEdit = new DbDBAEdit();
            List<string> listStr = new List<string>();

            dbDataShowDgv2StringList( listStr );
            hDbDBAEdit.dbString2Ui( ref listStr );

            if ( DialogResult.OK != hDbDBAEdit.ShowDialog() ) {
                return EDbDataShowStat.DBDATASHOW_READY;
            }

            object sRecord = hDbDBAEdit.dbStruGet();

            if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL == hDbTable.dataBaseBaseCommUpdate( ref sRecord ) ) {
                return EDbDataShowStat.DBDATASHOW_FAILED;
            } else {
                dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );

                return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
            }
        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            DbDBAEdit hDbDBAEdit = new DbDBAEdit();
            List<string> listStr = new List<string>();

            dbDataShowDgv2StringList( listStr );
            hDbDBAEdit.dbString2Stru( ref listStr );

            object sRecord = hDbDBAEdit.dbStruGet();

            if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL == hDbTable.dataBaseBaseCommDelete( ref sRecord ) ) {
                return EDbDataShowStat.DBDATASHOW_FAILED;
            } else {
                dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );

                return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
            }
        }
    }
}
