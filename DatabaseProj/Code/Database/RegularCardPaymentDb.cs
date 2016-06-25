using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardPayment : CDatebaseBase {

        /// <summary>
        /// 停车卡缴费 结构体
        /// </summary>
        public struct SRegularCardPaymentStru {
            public int iId;
            public int iRcuId;
            public DateTime sPayTime;
            public double dPayMoney;
            public DateTime sVaildTime;

            public SRegularCardPaymentStru (int Id, int RcuId, DateTime PayTime, double PayMoney, DateTime VaildTime)
            {
                iId = Id;
                iRcuId = RcuId;
                sPayTime = PayTime;
                dPayMoney = PayMoney;
                sVaildTime = VaildTime;
            }
        }

        /// <summary>
        /// 停车卡缴费 查询结构体
        /// </summary>
        public struct SRegularCardPaymentQueryStru {
            bool bPayTimeEn;
            bool bPayMoneyEn;
            bool bValidTime;

            DateTime sPayTimeStart;
            DateTime sPayTimeStop;
            double dPayMoneyMin;
            double dPayMoneyMax;
            DateTime sValidTimeStart;
            DateTime sValidTimeStop;
        };

        /// <summary>
        /// 停车卡缴费 表头描述
        /// </summary>
        public static string[] strRegularCardPaymentHeadDesc = {
            "ID",
            "固定卡ID",
            "付款时间",
            "付款金额",
            "有效时间",
        };

        /// <summary>
        /// 停车卡缴费 构造函数 创建表 使能外键
        /// </summary>
        public CRegularCardPayment ()
        {
            rcpTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 停车卡缴费 创建表
        /// </summary>
        public void rcpTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS RegularCardPayment ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "RcuId      INT, " +
                                    "PayTime    DATETIME, " +
                                    "PayMoney   REAL, " +
                                    "VaildTime  DATETIME, " +
                                    "FOREIGN    KEY(RcuId)  REFERENCES  RegularCardUser(Id) )";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 停车卡缴费 插入默认记录
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SRegularCardPaymentStru sRcpStru = new SRegularCardPaymentStru( 1, 1, DateTime.Now, 100, DateTime.Parse( "2020-1-1 23:59:59" ) );
            object sObject = sRcpStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        /// <summary>
        /// 停车卡缴费 读取所有记录
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardPayment";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车卡缴费 添加一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "INSERT INTO RegularCardPayment(RcuId, PayTime, PayMoney, VaildTime) " +
                               "VALUES(@RcuId, @PayTime, @PayMoney, @VaildTime)";

            hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sRcpStru.iRcuId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcpStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcpStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcpStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 删除一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "DELETE FROM RegularCardPayment WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcpStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 更新一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "UPDATE RegularCardPayment SET " +
                               "RcuId=@RcuId, " +
                               "PayTime=@PayTime, " +
                               "PayMoney=@PayMoney, " +
                               "VaildTime=@VaildTime " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sRcpStru.iRcuId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcpStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcpStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcpStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcpStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 获取表头描述
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardPaymentHeadDesc;
        }

        /// <summary>
        /// 停车卡缴费 清空表
        /// </summary>
        /// <returns></returns>
        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "RegularCardPayment" );
        }
    }
}
