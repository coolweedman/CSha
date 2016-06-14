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
        
        public CDatebaseBase ()
        {
            if ( !Directory.Exists( strDatabaseDir ) ) {
                Directory.CreateDirectory( strDatabaseDir );
            }

            dataBasBaseConn();
        }
        
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

        public virtual void dataBaseBaseDeRecordInsert ()
        {
        }

        public virtual SQLiteDataReader dataBaseBaseCommRead ()
        {
            return hReader;
        }

        public virtual int dataBaseBaseCommAdd (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        public virtual int dataBaseBaseCommDelete (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        public virtual int dataBaseBaseCommUpdate (ref object sRecord)
        {
            return (int)EDataBaseClassErrStat.DATABASEERR_FAIL;
        }

        public virtual string[] dataBaseBaseHeadDescGet ()
        {
            return null;
        }
    }
}
