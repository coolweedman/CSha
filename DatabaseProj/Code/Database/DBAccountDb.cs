using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CDBAccountDb : CDatebaseBase {

        public struct SDBAccountStru {
            int iId;
            int iType;
            string strAccount;
            string strPassword;
            int iAuthority;
            string strName;
            string strJobNum;

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


    }
}
