using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CDBAccountDb : CDatebaseBase {

        /// <summary>
        /// 数据库管理员结构体
        /// </summary>
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

        /// <summary>
        /// 数据库管理员表头
        /// </summary>
        public static string[] strDBAccountHeadDesc = {
            "ID",
            "类型",
            "账号",
            "密码",
            "权限",
            "姓名",
            "工号",
        };

        /// <summary>
        /// 数据库管理员表 构造函数
        /// 创建表, 使能外键
        /// </summary>
        public CDBAccountDb ()
        {
            dbaTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 创建数据库管理员表
        /// </summary>
        public void dbaTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS DBAccount ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Type       TEXT    DEFAULT '访客', " +
                                    "Account    TEXT    UNIQUE  NOT NULL, " +
                                    "Password   TEXT, " +
                                    "Authority  TEXT    DEFAULT '只读', " +
                                    "Name       TEXT, " +
                                    "JobNum     TEXT, "+
                                    "FOREIGN    KEY(Type)       REFERENCES BaseDBAType(DBAType), "+
                                    "FOREIGN    KEY(Authority)  REFERENCES BaseDBAAuthority(Authority))";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 添加默认数据库管理员
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SDBAccountStru sDBAStru = new SDBAccountStru( 1, 0, "root", "123456", 0, "ROOT_USER", "ROOT_JOBNUM" );
            object sObject = sDBAStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        /// <summary>
        /// 读取数据库管理员
        /// </summary>
        /// <returns>读取结果Reader</returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM DBAccount";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 添加数据库管理员
        /// </summary>
        /// <param name="sRecord">数据库管理员结构体</param>
        /// <returns>添加结果</returns>
        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SDBAccountStru sDBAStru = (SDBAccountStru)sRecord;

            hCmd.CommandText = "INSERT INTO DBAccount(Type, Account, Password, Authority, Name, JobNum) " +
                               "VALUES(@Type, @Account, @Password, @Authority, @Name, @JobNum)";

            hCmd.Parameters.Add( new SQLiteParameter( "Type", CDbBaseTable.strDbBaseDBATypeDesc[sDBAStru.iType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sDBAStru.strAccount ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Password", sDBAStru.strPassword ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Authority", CDbBaseTable.strDbBaseAuthorityDesc[sDBAStru.iAuthority] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Name", sDBAStru.strName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "JobNum", sDBAStru.strJobNum ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 删除数据库管理员
        /// </summary>
        /// <param name="sRecord">数据库管理员结构体</param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SDBAccountStru sDBAStru = (SDBAccountStru)sRecord;

            hCmd.CommandText = "DELETE FROM DBAccount WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sDBAStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 更新数据库管理员
        /// </summary>
        /// <param name="sRecord">数据库管理员结构体</param>
        /// <returns>更新结果</returns>
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

            hCmd.Parameters.Add( new SQLiteParameter( "Type", CDbBaseTable.strDbBaseDBATypeDesc[sDBAStru.iType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sDBAStru.strAccount ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Password", sDBAStru.strPassword ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Authority", CDbBaseTable.strDbBaseAuthorityDesc[sDBAStru.iAuthority] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Name", sDBAStru.strName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "JobNum", sDBAStru.strJobNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sDBAStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 获取数据库管理员表头描述
        /// </summary>
        /// <returns>表头</returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strDBAccountHeadDesc;
        }

        /// <summary>
        /// 根据数据库管理员账号读取密码
        /// </summary>
        /// <param name="sStru">数据库管理员结构体</param>
        /// <returns>读取结果</returns>
        public bool dbAccountRead (ref SDBAccountStru sStru)
        {
            hCmd.CommandText = "SELECT Type, Password, Authority, Name, JobNum FROM DBAccount WHERE Account=@Account";
            hCmd.Parameters.Add( new SQLiteParameter( "Account", sStru.strAccount ) );
            base.dataBaseBaseRecordRead();

            if ( null == hReader ) {
                return false;
            }

            if ( !hReader.HasRows ) {
                hReader.Close();
                return false;
            }

            hReader.Read();
            int i = 0;
            sStru.iType = CDbBaseTable.dicDbBaseDBATypeDesc[hReader.GetString( i++ )];
            sStru.strPassword = hReader.GetString( i++ );
            sStru.iAuthority = CDbBaseTable.dicDbBaseAuthorityDesc[hReader.GetString( i++ )];
            sStru.strName = hReader.GetString( i++ );
            sStru.strJobNum = hReader.GetString( i++ );

            hReader.Close();

            return true;
        }
    }
}
