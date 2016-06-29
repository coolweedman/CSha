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
        public DbDBAMain (CDatebaseBase hDbBase, string strTitle = "DBA Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( CDBAccountDb.strDBAccountHeadDesc );
        }

        /// <summary>
        /// 构造函数 为UI设计添加
        /// </summary>
        public DbDBAMain () : base(null)
        {
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbRecordDeleteProc();
        }

        /// <summary>
        /// 查询处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableQueryProc ()
        {
            DbDBAQuery hDbDBAQuery = new DbDBAQuery( hDbTable );
            hDbDBAQuery.ShowDialog();

            return EDbDataShowStat.DBDATASHOW_READY;
        }
    }
}
