using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.ParkingRecordUi {

    public class ParkingRecordMain : DbTableMainBase {

        public ParkingRecordMain (CDatebaseBase hDbBase, string strTitle = "Parking Record Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( CParkingRecordDb.strParkingRecordHeadDesc );
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new ParkingRecordEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new ParkingRecordEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new ParkingRecordEdit();

            return base.dbRecordDeleteProc();
        }

    }
}
