﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace DatabaseProj.Code.Database {
    public class CParkingSpaceDb : CDatebaseBase {

        public struct SParkingSpaceStru {
            public int iId;
            public int iGarageNum;
            public int iSpaceNum;
            public string strCardNum;
            public double dAxisX;
            public double dAxisY;
            public int iRearrange1;
            public int iRearrange2;
            public int iLockStat;
            public int iSpaceType;
            public int iSpacePosi;
            public int iSpaceAera;
            public string strAttr1;
            public string strAttr2;
            public string strAttr3;
            public string strCarPlate;
            public string strPicPath;

            public SParkingSpaceStru (int Id, int GarageNum, int SpaceNum, string CardNum, double AxisX, double AxisY, int Rearrange1, int Rearrange2, int LockStat, int SpaceType, int SpacePosi, int SpaceArea, string Attr1, string Attr2, string Attr3, string CarPlate, string PicPath)
            {
                iId = Id;
                iGarageNum = GarageNum;
                iSpaceNum = SpaceNum;
                strCardNum = CardNum;
                dAxisX = AxisX;
                dAxisY = AxisY;
                iRearrange1 = Rearrange1;
                iRearrange2 = Rearrange2;
                iLockStat = LockStat;
                iSpaceType = SpaceType;
                iSpacePosi = SpacePosi;
                iSpaceAera = SpaceArea;
                strAttr1 = Attr1;
                strAttr2 = Attr2;
                strAttr3 = Attr3;
                strCarPlate = CarPlate;
                strPicPath = PicPath;
            }
        };

        public enum EPsLockStat {
            PARKINGSPACE_LOCKSTATIDLE = 0,
            PARKINGSPACE_LOCKSTATBUSY,
            PARKINGSPACE_LOCKSTATBOOK,
        };

        public enum EPsCarType {
            PARKINGSPACE_CARTYPELARGE = 0,
            PARKINGSPACE_CARTYPEMID,
            PARKINGSPACE_CARTYPESMALL,
        };

        public enum EPsSpacePosi {
            PARKINGSPACE_POSIFORWARD = 0,
            PARKINGSPACE_POSIBACKWORD,
            PARKINGSPACE_POSILEFT,
            PARKINGSPACE_POSIRIGHT,
        };

        public enum EPsSpaceAera {
            PARKINGSPACE_AREAA = 0,
            PARKINGSPACE_AREAB,
            PARKINGSPACE_AREAC,
            PARKINGSPACE_AREAD,
        };

        public static string[] strParkingSpaceHeadDesc = {
            "ID",
            "车库号",
            "车位号",
            "卡号",
            "水平坐标",
            "垂直坐标",
            "重列车位1",
            "重列车位2",
            "车位锁定",
            "车位类型",
            "车位位置",
            "车位分区",
            "车位属性1",
            "车位属性2",
            "车位属性3",
            "车牌",
            "图片路径",
        };

        public CParkingSpaceDb ()
        {
            psTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        public void psTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS ParkingSpace ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "GarageNum  INT, " +
                                    "SpaceNum   INT, " +
                                    "CardNum    TEXT, " +
                                    "AxisX      REAL, " +
                                    "AxisY      REAL, " +
                                    "Rearrange1 INT     DEFAULT 0, " +
                                    "Rearrange2 INT     DEFAULT 0, " +
                                    "LockStat   TEXT, " +
                                    "SpaceType  TEXT, " +
                                    "SpacePosi  TEXT, " +
                                    "SpaceAera  TEXT, " +
                                    "Attr1      TEXT    DEFAULT '', " +
                                    "Attr2      TEXT    DEFAULT '', " +
                                    "Attr3      TEXT    DEFAULT '', " +
                                    "CarPlate   TEXT    DEFAULT '', " +
                                    "PicPath    TEXT    DEFAULT '', " +
                                    "FOREIGN    KEY(GarageNum)  REFERENCES  BaseParkingSpaceGarageNum(ParkingSpaceGarageNum), " +
                                    "FOREIGN    KEY(SpaceNum)   REFERENCES  BaseParkingSpaceNum(ParkingSpaceNum), " +
                                    "FOREIGN    KEY(LockStat)   REFERENCES  BaseParkingSpaceLockStat(ParkingSpaceLockStat), " +
                                    "FOREIGN    KEY(SpaceType)  REFERENCES  BaseParkingCarType(ParkingCarType), " +
                                    "FOREIGN    KEY(SpacePosi)  REFERENCES  BaseParkingSpacePosi(ParkingSpacePosi) " +
                                    ")";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override void dataBaseBaseDeRecordInsert ()
        {
            SParkingSpaceStru sParkingSpaceStru = new SParkingSpaceStru( 1, 1, 1, "TestCardNum", 10, 12, 0, 0, 0, 0, 0, 0, "", "", "", "粤A-88888", "none" );
            object sObject = sParkingSpaceStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM ParkingSpace";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SParkingSpaceStru sRcuStru = (SParkingSpaceStru)sRecord;

            hCmd.CommandText = "INSERT INTO ParkingSpace(GarageNum, SpaceNum, CardNum, AxisX, AxisY, Rearrange1, Rearrange2, LockStat, SpaceType, SpacePosi, SpaceAera, Attr1, Attr2, Attr3, CarPlate, PicPath) " +
                               "VALUES(@GarageNum, @SpaceNum, @CardNum, @AxisX, @AxisY, @Rearrange1, @Rearrange2, @LockStat, @SpaceType, @SpacePosi, @SpaceAera, @Attr1, @Attr2, @Attr3, @CarPlate, @PicPath)";

            hCmd.Parameters.Add( new SQLiteParameter( "GarageNum", sRcuStru.iGarageNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceNum", sRcuStru.iSpaceNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "AxisX", sRcuStru.dAxisX ) );
            hCmd.Parameters.Add( new SQLiteParameter( "AxisY", sRcuStru.dAxisY ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Rearrange1", sRcuStru.iRearrange1 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Rearrange2", sRcuStru.iRearrange2 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "LockStat", CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[sRcuStru.iLockStat] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sRcuStru.iSpaceType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpacePosi", CDbBaseTable.strDbBaseParkingSpacePosiDesc[sRcuStru.iSpacePosi] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceAera", CDbBaseTable.strDbBaseParkingSpaceAeraDesc[sRcuStru.iSpaceAera] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr1", sRcuStru.strAttr1 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr2", sRcuStru.strAttr2 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr3", sRcuStru.strAttr3 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PicPath", sRcuStru.strPicPath ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SParkingSpaceStru sRcuStru = (SParkingSpaceStru)sRecord;

            hCmd.CommandText = "DELETE FROM ParkingSpace WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SParkingSpaceStru sRcuStru = (SParkingSpaceStru)sRecord;

            hCmd.CommandText = "UPDATE ParkingSpace SET " +
                               "GarageNum=@GarageNum, " +
                               "SpaceNum=@SpaceNum, " +
                               "CardNum=@CardNum, " +
                               "AxisX=@AxisX, " +
                               "AxisY=@AxisY, " +
                               "Rearrange1=@Rearrange1, " +
                               "Rearrange2=@Rearrange2, " +
                               "LockStat=@LockStat, " +
                               "SpaceType=@SpaceType, " +
                               "SpacePosi=@SpacePosi, " +
                               "SpaceAera=@SpaceAera, " +
                               "Attr1=@Attr1, " +
                               "Attr2=@Attr2, " +
                               "Attr3=@Attr3, " +
                               "CarPlate=@CarPlate, " +
                               "PicPath=@PicPath " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "GarageNum", sRcuStru.iGarageNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceNum", sRcuStru.iSpaceNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "AxisX", sRcuStru.dAxisX ) );
            hCmd.Parameters.Add( new SQLiteParameter( "AxisY", sRcuStru.dAxisY ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Rearrange1", sRcuStru.iRearrange1 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Rearrange2", sRcuStru.iRearrange2 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "LockStat", CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[sRcuStru.iLockStat] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sRcuStru.iSpaceType] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpacePosi", CDbBaseTable.strDbBaseParkingSpacePosiDesc[sRcuStru.iSpacePosi] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "SpaceAera", CDbBaseTable.strDbBaseParkingSpaceAeraDesc[sRcuStru.iSpaceAera] ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr1", sRcuStru.strAttr1 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr2", sRcuStru.strAttr2 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Attr3", sRcuStru.strAttr3 ) );
            hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sRcuStru.strCardNum ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PicPath", sRcuStru.strPicPath ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strParkingSpaceHeadDesc;
        }

        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "ParkingSpace" );
        }

        public bool dbParkingSpaceRead (ref List<SParkingSpaceStru> listParkingSpace)
        {
            dataBaseBaseCommRead();

            if ( null == hReader ) {
                return false;
            }

            listParkingSpace.Clear();

            int i;
            while (hReader.Read()) {
                i = 0;

                SParkingSpaceStru sStru = new SParkingSpaceStru();

                sStru.iId = hReader.GetInt32( i++ );
                sStru.iGarageNum = hReader.GetInt32( i++ );
                sStru.iSpaceNum = hReader.GetInt32( i++ );
                sStru.strCardNum = hReader.GetString( i++ );
                sStru.dAxisX = hReader.GetDouble( i++ );
                sStru.dAxisY = hReader.GetDouble( i++ );
                sStru.iRearrange1 = hReader.GetInt32( i++ );
                sStru.iRearrange2 = hReader.GetInt32( i++ );
                sStru.iLockStat = CDbBaseTable.dicDbBaseParkingSpaceLockStatDesc[hReader.GetString( i++ )];
                sStru.iSpaceType = CDbBaseTable.dicDbBaseParkingCarTypeDesc[hReader.GetString( i++ )];
                sStru.iSpacePosi = CDbBaseTable.dicDbBaseParkingSpacePosiDesc[hReader.GetString( i++ )];
                sStru.iSpaceAera = CDbBaseTable.dicDbBaseParkingSpaceAeraDesc[hReader.GetString( i++ )];
                sStru.strAttr1 = hReader.GetString( i++ );
                sStru.strAttr2 = hReader.GetString( i++ );
                sStru.strAttr3 = hReader.GetString( i++ );
                sStru.strCarPlate = hReader.GetString( i++ );
                sStru.strPicPath = hReader.GetString( i++ );

                listParkingSpace.Add( sStru );
            }

            return true;
        }
    }
}
