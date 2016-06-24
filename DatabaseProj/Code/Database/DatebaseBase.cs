using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using DatabaseProj.Code.Debug;
using System.IO;
using System.Diagnostics;


namespace DatabaseProj.Code.Database {

    public enum EDataBaseClassErrStat {
        DATABASEERR_NOERR = 0,
        DATABASEERR_FAIL = -1,
    };

    public class CDatebaseBase {

        public static string strDatabaseDir = "Database";
        public static string strDatabaseName = "Parking.db";
        public static string strDatabaseConn = "Data Source=" + strDatabaseDir + "/" + strDatabaseName + ";Version=3";

        protected SQLiteCommand hCmd;
        protected SQLiteDataReader hReader;
        protected SQLiteConnection hConn;

        /// <summary>
        /// 数据库构造函数 创建数据库文件并连接
        /// </summary>
        public CDatebaseBase ()
        {
            if ( !Directory.Exists( strDatabaseDir ) ) {
                Directory.CreateDirectory( strDatabaseDir );
            }

            dataBasBaseConn();
        }

        /// <summary>
        /// 数据库连接
        /// </summary>
        /// <returns></returns>
        protected int dataBasBaseConn ()
        {
            try {
                hConn = new SQLiteConnection( strDatabaseConn );
                hConn.Open();

                return (int)EDataBaseClassErrStat.DATABASEERR_NOERR;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Connect to database fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库使能外键
        /// </summary>
        /// <returns></returns>
        public int sqlite3ForeignKeyEn ()
        {
            try {
                hCmd.CommandText = "PRAGMA foreign_keys=ON";

                return hCmd.ExecuteNonQuery();
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Enable foreign key fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库表创建
        /// </summary>
        /// <param name="strCreateTable"></param>
        /// <returns></returns>
        protected int dataBaseBaseTableCreate (string strCreateTable)
        {
            try {
                hCmd = new SQLiteCommand( strCreateTable, hConn );
                hCmd.CommandText = strCreateTable;

                return hCmd.ExecuteNonQuery();
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Create table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库读取命令执行
        /// </summary>
        /// <returns></returns>
        protected int dataBaseBaseRecordRead ()
        {
            try {
                hReader = hCmd.ExecuteReader();

                return (int)EDataBaseClassErrStat.DATABASEERR_NOERR;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Read record fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库非读取命令执行
        /// </summary>
        /// <returns></returns>
        protected int dataBaseBaseCommCmdExec ()
        {
            try {
                return hCmd.ExecuteNonQuery();
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Comm Cmd fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库插入默认记录
        /// </summary>
        public virtual void dataBaseBaseDeRecordInsert ()
        {
            
        }

        /// <summary>
        /// 数据库读取数据表
        /// </summary>
        /// <returns></returns>
        public virtual SQLiteDataReader dataBaseBaseCommRead ()
        {
            return hReader;
        }

        public virtual SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            return null;
        }

        /// <summary>
        /// 数据库插入记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public virtual int dataBaseBaseCommAdd (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        /// <summary>
        /// 数据库删除记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public virtual int dataBaseBaseCommDelete (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        /// <summary>
        /// 数据库更新记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public virtual int dataBaseBaseCommUpdate (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        /// <summary>
        /// 数据库清空表
        /// </summary>
        /// <returns></returns>
        public virtual int dataBaseBaseCommTableClr ()
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        /// <summary>
        /// 数据库根据表名清空表
        /// </summary>
        /// <param name="strTable"></param>
        /// <returns></returns>
        protected int dataBaseBaseTableClr (string strTable)
        {
            try {
                hCmd.CommandText = "DELETE FROM " + strTable;

                return hCmd.ExecuteNonQuery();

            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "Database: Delete table fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );

                return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
            }
        }

        /// <summary>
        /// 数据库获取数据表头描述
        /// </summary>
        /// <returns></returns>
        public virtual string[] dataBaseBaseHeadDescGet ()
        {
            return null;
        }
    }
}
