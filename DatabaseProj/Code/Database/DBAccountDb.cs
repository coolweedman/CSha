using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CDBAccountDb : CDatebaseBase {

        public struct SDBAccountStru {
            public int iId;
            public int iType;
            public string strAccount;
            public string strPassword;
            public int iAuthority;
            public string strName;
            public string strJobNum;

            public SDBAccountStru (int Id, int Type, string Account, string Passward, int Authority, string Name, string JobNum)
            {
                iId = Id;
                iType = Type;
                strAccount = Account;
                strPassword = Passward;
                iAuthority = Authority;
                strName = Name;
                strJobNum = JobNum;
            }
        };

        public enum EDBAccountType {
            DBATYPE_ROOT = 0,
            DBATYPE_ADMIN,
            DBATYPE_USER,
            DBATYPE_GUEST,
        };

        public enum EDBAccountAuthority {
            DBAAUTHORITY_ROOT = 0,
            DBAAUTHORITY_HIGH,
            DBAAUTHORITY_READWRITE,
            DBAAUTHORITY_READ,
        };

        public static string[] strDBAccountHeadDesc = {
            "ID",
            "类型",
            "账号",
            "密码",
            "权限",
            "姓名",
            "工号",
        };

        public static string[] strDBATypeDesc = {
            "ROOT",
            "ADMIN",
            "普通用户",
            "访客",
        };

        public static string[] strDBAAuthorityDesc = {
            "ROOT",
            "高",
            "读写",
            "只读",
        };

        public static Dictionary<string, int> dicDBAType2Enum = new Dictionary<string, int>
        {
            { strDBATypeDesc[0], 0 },
            { strDBATypeDesc[1], 1 },
            { strDBATypeDesc[2], 2 },
            { strDBATypeDesc[3], 3 },
        };

        public static Dictionary<string, int> dicDBAAuthority2Enum = new Dictionary<string, int>
        {
            { strDBAAuthorityDesc[0], 0 },
            { strDBAAuthorityDesc[1], 1 },
            { strDBAAuthorityDesc[2], 2 },
            { strDBAAuthorityDesc[3], 3 },
        };

        public CDBAccountDb ()
        {
            dbaTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        public void dbaTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS DBAccount ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Type       TEXT, " +
                                    "Account    TEXT    UNIQUE  NOT NULL, " +
                                    "Password   TEXT, " +
                                    "Authority  TEXT, " +
                                    "Name       TEXT, " +
                                    "JobNum     TEXT)";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override void dataBaseBaseDeRecordInsert ()
        {
            SDBAccountStru sDBAStru = new SDBAccountStru( 1, 0, "root", "123456", 0, "ROOT_USER", "ROOT_JOBNUM" );
            object sObject = sDBAStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM DBAccount";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SDBAccountStru sDBAStru = (SDBAccountStru)sRecord;

            hCmd.CommandText = "INSERT INTO DBAccount(Type, Account, Password, Authority, Name, JobNum) " +
                               "VALUES(@Type, @Account, @Password, @Authority, @Name, @JobNum)";

            hCmd.Parameters.Add( new SQLiteParameter( "Type", strDBATypeDesc[sDBAStru.iType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sDBAStru.strAccount ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Password", sDBAStru.strPassword ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Authority", strDBAAuthorityDesc[sDBAStru.iAuthority] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Name", sDBAStru.strName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "JobNum", sDBAStru.strJobNum ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SDBAccountStru sDBAStru = (SDBAccountStru)sRecord;

            hCmd.CommandText = "DELETE FROM DBAccount WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sDBAStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SDBAccountStru sDBAStru = (SDBAccountStru)sRecord;

            hCmd.CommandText = "UPDATE DBAccount SET " +
                               "Type=@Type, " +
                               "Account=@Account, " +
                               "Password=@Password, " +
                               "Authority=@Authority, " +
                               "Name=@Name, " +
                               "JobNum=@JobNum " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "Type", strDBATypeDesc[sDBAStru.iType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sDBAStru.strAccount ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Password", sDBAStru.strPassword ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Authority", strDBAAuthorityDesc[sDBAStru.iAuthority] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Name", sDBAStru.strName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "JobNum", sDBAStru.strJobNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sDBAStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strDBAccountHeadDesc;
        }

        public bool dbAccountRead (ref SDBAccountStru sStru)
        {
            hCmd.CommandText = "SELECT Type, Password, Authority, Name, JobNum FROM DBAccount WHERE Account=@Account";
            base.dataBaseBaseRecordRead();
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sStru.strAccount ) );

            if ( null == hReader ) {
                return false;
            }

            int i = 0;
            sStru.iType = hReader.GetInt32( i++ );
            sStru.strPassword = hReader.GetString( i++ );
            sStru.iAuthority = hReader.GetInt32( i++ );
            sStru.strName = hReader.GetString( i++ );
            sStru.strJobNum = hReader.GetString( i++ );

            return false;
        }
    }
}
