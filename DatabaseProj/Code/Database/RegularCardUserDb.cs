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
            public bool bIdEn;
            public bool bUserNameEn;
            public bool bUserIdent;
            public bool bUserPhone;
            public bool bCarPlate;
            public bool bCarNum;
            public bool bCardType;
            public bool bCarType;

            public int iId;
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

        /// <summary>
        /// 查询停车卡数据库
        /// </summary>
        /// <param name="sCond">查询条件</param>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SRegularCardUserQueryStru sQueryStru = (SRegularCardUserQueryStru)sCond;

            if ( !sQueryStru.bIdEn && !sQueryStru.bUserNameEn && !sQueryStru.bUserIdent && !sQueryStru.bUserPhone && !sQueryStru.bCarPlate && !sQueryStru.bCarNum && !sQueryStru.bCardType && !sQueryStru.bCarType ) {
                return dataBaseBaseCommRead();
            }

            bool bFirstFlag = true;
            hCmd.CommandText = "SELECT * FROM RegularCardUser WHERE ";

            if ( sQueryStru.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@Id";
            }
            if ( sQueryStru.bUserNameEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserName=@UserName";
            }
            if ( sQueryStru.bUserIdent ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserIdent=@UserIdent";
            }
            if ( sQueryStru.bUserPhone ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserPhone=@UserPhone";
            }
            if ( sQueryStru.bCarPlate ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CarPlate=@CarPlate";
            }
            if ( sQueryStru.bCarNum ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CardNum=@CardNum";
            }
            if ( sQueryStru.bCardType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CardType=@CardType";
            }
            if ( sQueryStru.bCarType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CarType=@CarType";
            }

            if ( sQueryStru.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "Id", sQueryStru.iId ) );
            }
            if ( sQueryStru.bUserNameEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserName", sQueryStru.strUserName ) );
            }
            if ( sQueryStru.bUserIdent ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sQueryStru.strUserIdent ) );
            }
            if ( sQueryStru.bUserPhone ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sQueryStru.strUserPhone ) );
            }
            if ( sQueryStru.bCarPlate ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sQueryStru.strCarPlate ) );
            }
            if ( sQueryStru.bCarNum ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sQueryStru.strCardNum ) );
            }
            if ( sQueryStru.bCardType ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CardType", CDbBaseTable.strDbBaseParkingCardTypeDesc[sQueryStru.iCardType] ) );
            }
            if ( sQueryStru.bCarType ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CarType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sQueryStru.iCarType] ) );
            }

            base.dataBaseBaseRecordRead();

            return hReader;
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
                               "CarType=@CarType " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "UserName", sRcuStru.strUserName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sRcuStru.strUserIdent ) );
            hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sRcuStru.strUserPhone ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", CDbBaseTable.strDbBaseParkingCardTypeDesc[sRcuStru.iCardType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sRcuStru.iCarType] ) );
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
