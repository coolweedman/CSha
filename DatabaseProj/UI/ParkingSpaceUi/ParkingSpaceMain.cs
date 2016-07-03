using DatabaseProj.Code.Database;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.ParkingSpaceUi {
    public class ParkingSpaceMain : DbTableMainBase {

        public ParkingSpaceMain (CDatebaseBase hDbBase, string strTitle = "Parking Space Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( hDbTable.dataBaseBaseHeadDescGet() );
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new ParkingSpaceEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new ParkingSpaceEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new ParkingSpaceEdit();

            return base.dbRecordDeleteProc();
        }
        
        /// <summary>
        /// 查询处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableQueryProc ()
        {
            ParkingSpaceQuery hDbParkingSpaceQuery = new ParkingSpaceQuery( hDbTable );
            hDbParkingSpaceQuery.ShowDialog();

            return EDbDataShowStat.DBDATASHOW_READY;
        }

    }
}
