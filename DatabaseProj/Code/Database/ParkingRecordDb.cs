using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using System.Data.SQLite;

namespace DatabaseProj.Code.Database {
    class CParkingRecordDb : CDatebaseBase {

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
            public int iDBAId;
            public string strCardType;
            public string strRemarks;

            public SParkingRecordStru (int Id, int GarageNum, int SpaceNum, string CardNum, string BillNum, DateTime BillDate, DateTime CarInTime, DateTime CarOutTime, string CarPlate, string PicPath, double MoneyIn, double MoneyPay, int PayMode, int DBAId, string CardType, string Remarks)
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
                iDBAId = DBAId;
                strCardType = CardType;
                strRemarks = Remarks;
            }
        };

        public enum EParkingRecordPayMode {
            PARKINGRECORD_PAYFREE = 0,
            PARKINGRECORD_PAYCASH,
            PARKINGRECORD_PAYBALANCE,
            PARKINGRECORD_PAYBANKCARD,
        };

        public static string[] strPrPayModeDesc =
        {
            "免费",
            "现金",
            "余额",
            "刷卡",
        };

        public static Dictionary<string, int> dicPrPayMode2Enum = new Dictionary<string, int>
        {
            { strPrPayModeDesc[0], 0 },
            { strPrPayModeDesc[1], 1 },
            { strPrPayModeDesc[2], 2 },
            { strPrPayModeDesc[3], 3 },
        };

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
            "操作员ID",
            "停车卡类型",
            "备注",
        };

        public CParkingRecordDb ()
        {
            prTableCreate();
            base.sqlite3ForeignKeyEn();
        }

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
                                    "DBAId      INTEGER, " +
                                    "CardType   TEXT, " +
                                    "Remarks    TEXT, " +
                                    //"FOREIGN KEY(GarageNum) REFERENCES ParkingSpace(GarageNum) )";
                                    "FOREIGN KEY(SpaceNum)  REFERENCES ParkingSpace(SpaceNum) ) ";
                                    //"FOREIGN KEY(CardNum)   REFERENCES RegularCardUser(CardNum), " +
                                    //"FOREIGN KEY(DBAId)     REFERENCES DBAccount(Id), " +
                                    //"FOREIGN KEY(CardType)  REFERENCES RegularCardUser(CardType))";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override void dataBaseBaseDeRecordInsert ()
        {
            SParkingRecordStru sParkingRecordStru = new SParkingRecordStru( 1, 1, 1, "TestCardNum", "BillNum", DateTime.Now, DateTime.Now, DateTime.Now, "粤A-88888", "null", 8, 10, 0, 1, "月卡", "" );
            object sObject = sParkingRecordStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM ParkingRecord";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SParkingRecordStru sParkingRecordStru = (SParkingRecordStru)sRecord;

            hCmd.CommandText = "INSERT INTO ParkingRecord(GarageNum, SpaceNum, CardNum, BillNum, BillTime, CarInTime, CarOutTime, CarPlate, PicPath, MoneyIn, MoneyPay, PayMode, DBAId, CardType, Remarks) " +
                               "VALUES(@GarageNum, @SpaceNum, @CardNum, @BillNum, @BillTime, @CarInTime, @CarOutTime, @CarPlate, @PicPath, @MoneyIn, @MoneyPay, @PayMode, @DBAId, @CardType, @Remarks)";

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
            hCmd.Parameters.Add( new SQLiteParameter( "PayMode", strPrPayModeDesc[sParkingRecordStru.iPayMode] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAId", sParkingRecordStru.iDBAId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", sParkingRecordStru.strCardType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Remarks", sParkingRecordStru.strRemarks ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SParkingRecordStru sParkingRecordStru = (SParkingRecordStru)sRecord;

            hCmd.CommandText = "DELETE FROM ParkingRecord WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sParkingRecordStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

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
                               "MoneyPay=@MoneyPay " +
                               "PayMode=@PayMode " +
                               "DBAId=@DBAId, " +
                               "CardType=@CardType " +
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
            hCmd.Parameters.Add( new SQLiteParameter( "PayMode", strPrPayModeDesc[sParkingRecordStru.iPayMode] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "DBAId", sParkingRecordStru.iDBAId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardType", sParkingRecordStru.strCardType ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Remarks", sParkingRecordStru.strRemarks ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sParkingRecordStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strParkingRecordHeadDesc;
        }

        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "ParkingRecord" );
        }

    }
}
