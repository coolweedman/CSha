using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using DatabaseProj.Code.Debug;
using System.Diagnostics;


namespace DatabaseProj.Code.Database {
    public class CRegularCardUserDb : CDatebaseBase {

        public struct SRegularCardUserStru {
            public int iId;
            public string strUserName;
            public string strUserIdent;
            public string strUserPhone;
            public string strCarPlate;
            public string strCardNum;
            public int iCardType;
            public int iCarType;
            public DateTime sPayTime;
            public double dPayMoney;
            public DateTime sVaildTime;

            public SRegularCardUserStru (int Id, string UserName, string UserIdent, string UserPhone, string CarPlate, string CardNum, int CardType, int CarType, DateTime PayTime, double PayMoney, DateTime VaildTime )
            {
                iId = Id;
                strUserName = UserName;
                strUserIdent = UserIdent;
                strUserPhone = UserPhone;
                strCarPlate = CarPlate;
                strCardNum = CardNum;
                iCardType = CardType;
                iCarType = CarType;
                sPayTime = PayTime;
                dPayMoney = PayMoney;
                sVaildTime = VaildTime;
            }
        };

        public enum ERcuCardType {
            RCUCARDTYPE_MONTH = 0,
            RCUCARDTYPE_QUARTER,
            RCUCARDTYPE_TMP,
        };

        public enum ERcuCarType {
            RCUCARTYPE_LARGE = 0,
            RCUCARTYPE_MID,
            RCUCARTYPE_SMALL,
            RCUCARTYPE_TMP,
        };

        public static string[] strRegularCardUserHeadDesc = {
            "ID",
            "姓名",
            "身份证",
            "电话",
            "车牌",
            "卡号",
            "卡类型",
            "车类型",
            "付款时间",
            "付款金额",
            "有效时间",
        };
        public static string[] strRcuCardTypeDesc = {
            "月卡",
            "季度卡",
            "临保卡",
        };
        public static string[] strRcuCarTypeDesc = {
            "大型车",
            "普通车",
            "小型车",
            "临时定义",
        };

        public static Dictionary<string, int> dicRcuCardType2Enum = new Dictionary<string, int>
        {
            { strRcuCardTypeDesc[0], 0 },
            { strRcuCardTypeDesc[1], 1 },
            { strRcuCardTypeDesc[2], 2 },
        };
        public static Dictionary<string, int> dicRcuCarType2Enum = new Dictionary<string, int>
        {
            { strRcuCarTypeDesc[0], 0 },
            { strRcuCarTypeDesc[1], 1 },
            { strRcuCarTypeDesc[2], 2 },
            { strRcuCarTypeDesc[3], 3 },
        };

        public CRegularCardUserDb ()
        {
            rcuDTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        public void rcuDTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS RegularCardUser ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "UserName   TEXT, " +
                                    "UserIdent  TEXT    UNIQUE  NOT NULL, " +
                                    "UserPhone  TEXT            NOT NULL, " +
                                    "CarPlate   TEXT, " +
                                    "CardNum    TEXT    UNIQUE  NOT NULL, " +
                                    "CardType   TEXT, " +
                                    "CarType    TEXT, " +
                                    "PayTime    DATETIME, " +
                                    "PayMoney   REAL, " +
                                    "VaildTime  DATETIME)";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override void dataBaseBaseDeRecordInsert ()
        {
            SRegularCardUserStru sRegularCardUser = new SRegularCardUserStru( 1, "TestUserName", "TestUserIdent", "TestUserPhone", "粤A-88888", "TestCardNum", 0, 0, DateTime.Now, 100, DateTime.Parse( "2020-1-1 23:59:59" ) );
            object sObject = sRegularCardUser;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardUser";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SRegularCardUserStru sRcuStru = (SRegularCardUserStru)sRecord;

            hCmd.CommandText = "INSERT INTO RegularCardUser(UserName, UserIdent, UserPhone, CarPlate, CardNum, CardType, CarType, PayTime, PayMoney, VaildTime) " +
                               "VALUES(@UserName, @UserIdent, @UserPhone, @CarPlate, @CardNum, @CardType, @CarType, @PayTime, @PayMoney, @VaildTime)";

            hCmd.Parameters.Add( new SQLiteParameter( "UserName", sRcuStru.strUserName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sRcuStru.strUserIdent ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sRcuStru.strUserPhone ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", strRcuCardTypeDesc[sRcuStru.iCardType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarType", strRcuCarTypeDesc[sRcuStru.iCarType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcuStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcuStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcuStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SRegularCardUserStru sRcuStru = (SRegularCardUserStru)sRecord;

            hCmd.CommandText = "DELETE FROM RegularCardUser WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SRegularCardUserStru sRcuStru = (SRegularCardUserStru)sRecord;

            hCmd.CommandText = "UPDATE RegularCardUser SET " +
                               "UserName=@UserName, " +
                               "UserIdent=@UserIdent, " +
                               "UserPhone=@UserPhone, " +
                               "CarPlate=@CarPlate, " +
                               "CardNum=@CardNum, " +
                               "CardType=@CardType, " +
                               "CarType=@CarType, " +
                               "PayTime=@PayTime, " +
                               "PayMoney=@PayMoney, " +
                               "VaildTime=@VaildTime " + 
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "UserName", sRcuStru.strUserName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sRcuStru.strUserIdent ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sRcuStru.strUserPhone ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", sRcuStru.iCardType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarType", sRcuStru.iCarType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcuStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcuStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcuStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardUserHeadDesc;
        }

        public int rcuPaymentUpdate (int iId, DateTime sPayTime, double dPayMoney, DateTime sVaildTime)
        {
            hCmd.CommandText = "UPDATE RegularCardUser SET " +
                               "PayTime=@PayTime, " +
                               "PayMoney=@PayMoney, " +
                               "VaildTime=@VaildTime " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", iId ) );

            return base.dataBaseBaseCommCmdExec();
        }
    }
}
