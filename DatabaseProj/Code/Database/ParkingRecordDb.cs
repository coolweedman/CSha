using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using System.Data.SQLite;

namespace DatabaseProj.Code.Database {
    public class CParkingRecordDb : CDatebaseBase {

        /// <summary>
        /// 停车记录 结构体
        /// </summary>
        public struct SParkingRecordStru {
            public int iId;
            public int iGarageNum;
            public int iSpaceNum;
            public string strCardNum;
            public string strBillNum;
            public DateTime sBillDate;
            public DateTime sCarInTime;
            public DateTime sCarOutTime;
            public string strCarPlate;
            public string strPicPath;
            public double dMoneyIn;
            public double dMoneyPay;
            public int iPayMode;
            public string strDBAName;
            public int iDBAType;
            public string strRemarks;

            public SParkingRecordStru (int Id, int GarageNum, int SpaceNum, string CardNum, string BillNum, DateTime BillDate, DateTime CarInTime, DateTime CarOutTime, string CarPlate, string PicPath, double MoneyIn, double MoneyPay, int PayMode, string DBAName, int DBAType, string Remarks)
            {
                iId = Id;
                iGarageNum = GarageNum;
                iSpaceNum = SpaceNum;
                strCardNum = CardNum;
                strBillNum = BillNum;
                sBillDate = BillDate;
                sCarInTime = CarInTime;
                sCarOutTime = CarOutTime;
                strCarPlate = CarPlate;
                strPicPath = PicPath;
                dMoneyIn = MoneyIn;
                dMoneyPay = MoneyPay;
                iPayMode = PayMode;
                strDBAName = DBAName;
                iDBAType = DBAType;
                strRemarks = Remarks;
            }
        };

        public enum EParkingRecordPayMode {
            PARKINGRECORD_PAYFREE = 0,
            PARKINGRECORD_PAYCASH,
            PARKINGRECORD_PAYBALANCE,
            PARKINGRECORD_PAYBANKCARD,
        };

        /// <summary>
        /// 停车记录 表头
        /// </summary>
        public static string[] strParkingRecordHeadDesc = {
            "ID",
            "车库号",
            "车位号",
            "卡号",
            "票据编号",
            "出票日期",
            "入库时间",
            "出库时间",
            "车牌号",
            "车辆图片",
            "付费金额",
            "应收金额",
            "付款方式",
            "操作员姓名",
            "操作员类型",
            "备注",
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        public CParkingRecordDb ()
        {
            prTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 停车记录 创建表
        /// </summary>
        public void prTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS ParkingRecord ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "GarageNum  INT, " +
                                    "SpaceNum   INT, " +
                                    "CardNum    TEXT, " +
                                    "BillNum    TEXT, " +
                                    "BillTime   DATETIME, " +
                                    "CarInTime  DATETIME, " +
                                    "CarOutTime DATETIME, " +
                                    "CarPlate   TEXT, " +
                                    "PicPath    TEXT, " +
                                    "MoneyIn    REAL, " +
                                    "MoneyPay   REAL, " +
                                    "PayMode    TEXT, " +
                                    "DBAName    TEXT, " +
                                    "DBAType    TEXT, " +
                                    "Remarks    TEXT, " +
                                    "FOREIGN    KEY(GarageNum) REFERENCES BaseParkingSpaceGarageNum(ParkingSpaceGarageNum), " +
                                    "FOREIGN    KEY(SpaceNum)  REFERENCES BaseParkingSpaceNum(ParkingSpaceNum), " +
                                    "FOREIGN    KEY(CardNum)   REFERENCES BaseParkingCardNum(ParkingCardNum), " +
                                    "FOREIGN    KEY(PayMode)   REFERENCES BasePayMode(PayMode), " +
                                    "FOREIGN    KEY(DBAName)   REFERENCES DBAccount(Name), " +
                                    "FOREIGN    KEY(DBAType)   REFERENCES BaseDBAType(DBAType) )";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 停车记录 插入默认记录
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SParkingRecordStru sParkingRecordStru = new SParkingRecordStru( 1, 1, 1, "10001", "BillNum", DateTime.Now, DateTime.Now, DateTime.Now, "粤A-88888", "null", 8, 10, 0, "ROOT_USER", 0, "" );
            object sObject = sParkingRecordStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        /// <summary>
        /// 停车记录 读取所有记录
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM ParkingRecord";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车记录 添加一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SParkingRecordStru sParkingRecordStru = (SParkingRecordStru)sRecord;

            hCmd.CommandText = "INSERT INTO ParkingRecord(GarageNum, SpaceNum, CardNum, BillNum, BillTime, CarInTime, CarOutTime, CarPlate, PicPath, MoneyIn, MoneyPay, PayMode, DBAName, DBAType, Remarks) " +
                               "VALUES(@GarageNum, @SpaceNum, @CardNum, @BillNum, @BillTime, @CarInTime, @CarOutTime, @CarPlate, @PicPath, @MoneyIn, @MoneyPay, @PayMode, @DBAName, @DBAType, @Remarks)";

            hCmd.Parameters.Add( new SQLiteParameter( "GarageNum", sParkingRecordStru.iGarageNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceNum", sParkingRecordStru.iSpaceNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sParkingRecordStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "BillNum", sParkingRecordStru.strBillNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "BillTime", sParkingRecordStru.sBillDate.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarInTime", sParkingRecordStru.sCarInTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarOutTime", sParkingRecordStru.sCarOutTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sParkingRecordStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PicPath", sParkingRecordStru.strPicPath ) );
            hCmd.Parameters.Add( new SQLiteParameter( "MoneyIn", sParkingRecordStru.dMoneyIn ) );
            hCmd.Parameters.Add( new SQLiteParameter( "MoneyPay", sParkingRecordStru.dMoneyPay ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMode", CDbBaseTable.strDbBasePayModeDesc[sParkingRecordStru.iPayMode] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAName", sParkingRecordStru.strDBAName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAType", CDbBaseTable.strDbBaseDBATypeDesc[sParkingRecordStru.iDBAType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Remarks", sParkingRecordStru.strRemarks ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车记录 删除一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SParkingRecordStru sParkingRecordStru = (SParkingRecordStru)sRecord;

            hCmd.CommandText = "DELETE FROM ParkingRecord WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sParkingRecordStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车记录 更新记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SParkingRecordStru sParkingRecordStru = (SParkingRecordStru)sRecord;

            hCmd.CommandText = "UPDATE ParkingRecord SET " +
                               "GarageNum=@GarageNum, " +
                               "SpaceNum=@SpaceNum, " +
                               "CardNum=@CardNum, " +
                               "BillNum=@BillNum, " +
                               "BillTime=@BillTime, " +
                               "CarInTime=@CarInTime, " +
                               "CarOutTime=@CarOutTime, " +
                               "CarPlate=@CarPlate, " +
                               "PicPath=@PicPath, " +
                               "MoneyIn=@MoneyIn, " +
                               "MoneyPay=@MoneyPay, " +
                               "PayMode=@PayMode, " +
                               "DBAName=@DBAName, " +
                               "DBAType=@DBAType, " +
                               "Remarks=@Remarks " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "GarageNum", sParkingRecordStru.iGarageNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceNum", sParkingRecordStru.iSpaceNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sParkingRecordStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "BillNum", sParkingRecordStru.strBillNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "BillTime", sParkingRecordStru.sBillDate.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarInTime", sParkingRecordStru.sCarInTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarOutTime", sParkingRecordStru.sCarOutTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sParkingRecordStru.strCarPlate ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PicPath", sParkingRecordStru.strPicPath ) );
            hCmd.Parameters.Add( new SQLiteParameter( "MoneyIn", sParkingRecordStru.dMoneyIn ) );
            hCmd.Parameters.Add( new SQLiteParameter( "MoneyPay", sParkingRecordStru.dMoneyPay ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMode", CDbBaseTable.strDbBasePayModeDesc[sParkingRecordStru.iPayMode] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAName", sParkingRecordStru.strDBAName ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAType", CDbBaseTable.strDbBaseDBATypeDesc[sParkingRecordStru.iDBAType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Remarks", sParkingRecordStru.strRemarks ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sParkingRecordStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车记录 获取表头描述
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strParkingRecordHeadDesc;
        }

        /// <summary>
        /// 停车记录 清空表
        /// </summary>
        /// <returns></returns>
        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "ParkingRecord" );
        }

    }
}
