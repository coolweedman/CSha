using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using System.Data.SQLite;
using DatabaseProj.Code.Debug;
using System.Diagnostics;


namespace DatabaseProj.Code.Database {
    public class CDbBaseTable : CDatebaseBase {

        /// <summary>
        /// 默认卡号个数
        /// </summary>
        public const int iParkingCardNumCnt = 10;
        /// <summary>
        /// 默认车库号个数
        /// </summary>
        public const int iParkingSpaceGarageNumCnt = 100;
        /// <summary>
        /// 默认车位号个数
        /// </summary>
        public const int iParkingSpaceNumCnt = 100;

        /// <summary>
        /// 创建表字符串
        /// </summary>
        private static string strTableCreateCmd = "";

        /// <summary>
        /// 固定卡类型字符串描述
        /// </summary>
        public static string[] strDbBaseParkingCardTypeDesc = {
            "月卡",
            "季度卡",
            "临保卡",
        };
        /// <summary>
        /// 固定卡车位类型描述
        /// </summary>
        public static string[] strDbBaseParkingCarTypeDesc = {
            "大型车",
            "普通车",
            "小型车",
            "临时定义",
        };
        /// <summary>
        /// 停车位锁定状态描述
        /// </summary>
        public static string[] strDbBaseParkingSpaceLockStatDesc = {
            "空闲",
            "停车中",
            "锁定",
        };
        /// <summary>
        /// 停车位相对位置描述
        /// </summary>
        public static string[] strDbBaseParkingSpacePosiDesc = {
            "前",
            "后",
        };
        /// <summary>
        /// 付款方式描述
        /// </summary>
        public static string[] strDbBasePayModeDesc = {
            "现金",
            "刷卡",
            "免费",
            "余额",
        };

        /// <summary>
        /// 基本表创建
        /// </summary>
        public CDbBaseTable ()
        {
            dbParkingCardNumTableInit();
            dbParkingCardTypeTableInit();
            dbParkingCarTypeTableInit();
            dbParkingSpaceLockStatTableInit();
            dbParkingSpacePosiTableInit();
            dbParkingSpaceGarageNumTableInit();
            dbParkingSpaceNumTableInit();
            dbPayModeTableInit();
        }

        /// <summary>
        /// 固定卡卡号表
        /// </summary>
        public void dbParkingCardNumTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingCardNum (" +
                                    "Id                 INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingCardNum     TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                int iRef = 10000;
                for ( i = 0; i < iParkingCardNumCnt; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingCardNum(ParkingCardNum) VALUES(@ParkingCardNum)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingCardNum", (iRef + i).ToString() ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingCardTypeTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 固定卡类型表
        /// </summary>
        public void dbParkingCardTypeTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingCardType (" +
                                    "Id                 INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingCardType    TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                for ( i = 0; i < strDbBaseParkingCardTypeDesc.Length; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingCardType(ParkingCardType) VALUES(@ParkingCardType)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingCardType", strDbBaseParkingCardTypeDesc[i] ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingCardTypeTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 车大小类型表
        /// </summary>
        public void dbParkingCarTypeTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingCarType (" +
                                    "Id                 INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingCarType     TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                for ( i = 0; i < strDbBaseParkingCarTypeDesc.Length; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingCarType(ParkingCarType) VALUES(@ParkingCarType)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingCarType", strDbBaseParkingCarTypeDesc[i] ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingCarTypeTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 车库锁定状态表
        /// </summary>
        public void dbParkingSpaceLockStatTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingSpaceLockStat (" +
                                    "Id                     INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingSpaceLockStat   TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                for ( i = 0; i < strDbBaseParkingSpaceLockStatDesc.Length; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingSpaceLockStat(ParkingSpaceLockStat) VALUES(@ParkingSpaceLockStat)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingSpaceLockStat", strDbBaseParkingSpaceLockStatDesc[i] ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingSpaceLockStatTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 车库相对位置表
        /// </summary>
        public void dbParkingSpacePosiTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingSpacePosi (" +
                                    "Id                     INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingSpacePosi       TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                for ( i = 0; i < strDbBaseParkingSpacePosiDesc.Length; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingSpacePosi(ParkingSpacePosi) VALUES(@ParkingSpacePosi)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingSpacePosi", strDbBaseParkingSpacePosiDesc[i] ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingSpacePosiTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 车库号表
        /// </summary>
        public void dbParkingSpaceGarageNumTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingSpaceGarageNum (" +
                                    "Id                     INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingSpaceGarageNum  TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                int iRef = 1;
                for ( i = 0; i < iParkingSpaceGarageNumCnt; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingSpaceGarageNum(ParkingSpaceGarageNum) VALUES(@ParkingSpaceGarageNum)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingSpaceGarageNum", (iRef + i).ToString() ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingSpaceGarageNumTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 车位号表
        /// </summary>
        public void dbParkingSpaceNumTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BaseParkingSpaceNum (" +
                                    "Id                     INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingSpaceNum        TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                int iRef = 1;
                for ( i = 0; i < iParkingSpaceNumCnt; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BaseParkingSpaceNum(ParkingSpaceNum) VALUES(@ParkingSpaceNum)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "ParkingSpaceNum", (iRef + i).ToString() ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbParkingSpaceNumTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 付款方式表
        /// </summary>
        public void dbPayModeTableInit ()
        {
            try {
                strTableCreateCmd = "CREATE TABLE IF NOT EXISTS BasePayMode (" +
                                    "Id                     INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "PayMode                TEXT    UNIQUE  NOT NULL)";

                SQLiteCommand hDbCmd = new SQLiteCommand( strTableCreateCmd, hConn );
                base.dataBaseBaseTableCreate( strTableCreateCmd );

                int i;
                for ( i = 0; i < strDbBasePayModeDesc.Length; i++ ) {
                    hDbCmd.CommandText = "INSERT INTO BasePayMode(PayMode) VALUES(@PayMode)";
                    hDbCmd.Parameters.Add( new SQLiteParameter( "PayMode", strDbBasePayModeDesc[i] ) );
                    hDbCmd.ExecuteNonQuery();
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: dbPayModeTableInit table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }
    }
}
