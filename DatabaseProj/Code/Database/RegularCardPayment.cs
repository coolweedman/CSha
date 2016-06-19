using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardPayment : CDatebaseBase {

        public struct SRegularCardPayment {
            public int iId;
            public int iRcuId;
            public DateTime sPayTime;
            public double dPayMoney;
            public DateTime sVaildTime;

            public SRegularCardPayment (int Id, int RcuId, DateTime PayTime, double PayMoney, DateTime VaildTime)
            {
                iId = Id;
                iRcuId = RcuId;
                sPayTime = PayTime;
                dPayMoney = PayMoney;
                sVaildTime = VaildTime;
            }
        }

        public static string[] strRegularCardPaymentHeadDesc = {
            "ID",
            "固定卡ID",
            "付款时间",
            "付款金额",
            "有效时间",
        };

        public CRegularCardPayment ()
        {
            rcpTableCreate();
            base.sqlite3ForeignKeyEn();
        }

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

        public override void dataBaseBaseDeRecordInsert ()
        {
            SRegularCardPayment sRcpStru = new SRegularCardPayment( 1, 1, DateTime.Now, 100, DateTime.Parse( "2020-1-1 23:59:59" ) );
            object sObject = sRcpStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardPayment";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SRegularCardPayment sRcpStru = (SRegularCardPayment)sRecord;

            hCmd.CommandText = "INSERT INTO RegularCardPayment(RcuId, PayTime, PayMoney, VaildTime) " +
                               "VALUES(@RcuId, @PayTime, @PayMoney, @VaildTime)";

            hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sRcpStru.iRcuId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcpStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcpStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcpStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SRegularCardPayment sRcpStru = (SRegularCardPayment)sRecord;

            hCmd.CommandText = "DELETE FROM RegularCardPayment WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcpStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SRegularCardPayment sRcpStru = (SRegularCardPayment)sRecord;

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

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardPaymentHeadDesc;
        }

        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "RegularCardPayment" );
        }
    }
}
