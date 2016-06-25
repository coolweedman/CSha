using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using DatabaseProj.Code.Debug;
using System.Diagnostics;


namespace DatabaseProj.Code.Database {
    public class CRegularCardUserDb : CDatebaseBase {

        /// <summary>
        /// 数据库停车卡 结构体
        /// </summary>
        public struct SRegularCardUserStru {
            public int iId;
            public string strUserName;
            public string strUserIdent;
            public string strUserPhone;
            public string strCarPlate;
            public string strCardNum;
            public int iCardType;
            public int iCarType;

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
            }
        };

        public struct SRegularCardUserQueryStru {
            public bool bUserNameEn;
            public bool bUserIdent;
            public bool bUserPhone;
            public bool bCarPlate;
            public bool bCarNum;
            public bool bCardType;
            public bool bCarType;

            public string strUserName;
            public string strUserIdent;
            public string strUserPhone;
            public string strCarPlate;
            public string strCardNum;
            public int iCardType;
            public int iCarType;
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

        /// <summary>
        /// 数据库 停车卡表头描述
        /// </summary>
        public static string[] strRegularCardUserHeadDesc = {
            "ID",
            "姓名",
            "身份证",
            "电话",
            "车牌",
            "卡号",
            "卡类型",
            "车类型",
        };

        /// <summary>
        /// 数据库停车卡 构造函数 创建表 使能外键
        /// </summary>
        public CRegularCardUserDb ()
        {
            rcuDTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 数据库 停车卡 创建表
        /// </summary>
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
                                    "FOREIGN    KEY(CardNum)    REFERENCES  BaseParkingCardNum(ParkingCardNum), " +
                                    "FOREIGN    KEY(CardType)   REFERENCES  BaseParkingCardType(ParkingCardType), " +
                                    "FOREIGN    KEY(CarType)    REFERENCES  BaseParkingCarType(ParkingCarType))";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 数据库停车卡 添加默认卡
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SRegularCardUserStru sRegularCardUser = new SRegularCardUserStru( 1, "TestUserName", "TestUserIdent", "TestUserPhone", "粤A-88888", "10000", 0, 0, DateTime.Now, 100, DateTime.Parse( "2020-1-1 23:59:59" ) );
            object sObject = sRegularCardUser;
            dataBaseBaseCommAdd( ref sObject );
        }


        /// <summary>
        /// 数据库停车卡添加一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SRegularCardUserStru sRcuStru = (SRegularCardUserStru)sRecord;

            hCmd.CommandText = "INSERT INTO RegularCardUser(UserName, UserIdent, UserPhone, CarPlate, CardNum, CardType, CarType) " +
                               "VALUES(@UserName, @UserIdent, @UserPhone, @CarPlate, @CardNum, @CardType, @CarType)";

            hCmd.Parameters.Add( new SQLiteParameter( "UserName", sRcuStru.strUserName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sRcuStru.strUserIdent ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sRcuStru.strUserPhone ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", CDbBaseTable.strDbBaseParkingCardTypeDesc[sRcuStru.iCardType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sRcuStru.iCarType] ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 读取停车卡数据库
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardUser";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SRegularCardUserQueryStru sQueryStru = (SRegularCardUserQueryStru)sCond;


            return null;
        }

        /// <summary>
        /// 停车卡数据库 删除一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SRegularCardUserStru sRcuStru = (SRegularCardUserStru)sRecord;

            hCmd.CommandText = "DELETE FROM RegularCardUser WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡数据库 更新一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
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
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "UserName", sRcuStru.strUserName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sRcuStru.strUserIdent ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sRcuStru.strUserPhone ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", sRcuStru.iCardType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarType", sRcuStru.iCarType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡数据库 获取表头描述
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardUserHeadDesc;
        }

        /// <summary>
        /// 停车卡数据库 清空表
        /// </summary>
        /// <returns></returns>
        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "RegularCardUser" );
        }
    }
}
