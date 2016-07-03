using DatabaseProj.Code.Database;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.RegularCardPaymentUi {

    public class RegularCardPaymentMain : DbTableMainBase {

        public RegularCardPaymentMain (CDatebaseBase hDbBase, string strTitle = "Regular Card Payment Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( hDbTable.dataBaseBaseHeadDescGet() );
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new RegularCardPaymentEdit();

            return base.dbRecordDeleteProc();
        }

        /// <summary>
        /// 查询处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableQueryProc ()
        {
            RegularCardPaymentQuery hRegularCardPaymentQuery = new RegularCardPaymentQuery( hDbTable );
            hRegularCardPaymentQuery.ShowDialog();

            return EDbDataShowStat.DBDATASHOW_READY;
        }
    }
}
