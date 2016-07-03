using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.RegularCardUserUi {

    public class RegularCardUserMain : DbTableMainBase {

        public RegularCardUserMain(CDatebaseBase hDbBase, string strTitle = "DBA Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( hDbTable.dataBaseBaseHeadDescGet() );
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new RegularCardUserEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new RegularCardUserEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new RegularCardUserEdit();

            return base.dbRecordDeleteProc();
        }

        /// <summary>
        /// 查询处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableQueryProc ()
        {
            RegularCardUserQuery hRegularCardUserQuery = new RegularCardUserQuery( hDbTable );
            hRegularCardUserQuery.Show();

            return EDbDataShowStat.DBDATASHOW_READY;
        }
    }
}
