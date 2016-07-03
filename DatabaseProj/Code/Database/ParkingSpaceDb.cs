using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using DatabaseProj.Code.Debug;
using System.Diagnostics;

namespace DatabaseProj.Code.Database {
    public class CParkingSpaceDb : CDatebaseBase {

        /// <summary>
        /// 停车位数据库 结构体
        /// </summary>
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

        /// <summary>
        /// 停车位数据库 查询结构体
        /// </summary>
        public struct SParkingSpaceQueryStru {
            public bool bIdEn;
            public bool bGarageNumEn;
            public bool bSpaceNumEn;
            public bool bCardNumEn;
            public bool bSpaceLockStatEn;
            public bool bSpaceTypeEn;
            public bool bSpaceAeraEn;
            public bool bCarPlate;

            public int iId;
            public int iGarageNum;
            public int iSpaceNum;
            public string strCardNum;
            public int iLockStat;
            public int iSpaceType;
            public int iSpaceAera;
            public string strCarPlate;
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

        /// <summary>
        /// 停车位数据库 表头描述
        /// </summary>
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

        /// <summary>
        /// 停车位数据库 构造函数 创建表并使能外键
        /// </summary>
        public CParkingSpaceDb ()
        {
            psTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 停车位数据库 创建表
        /// </summary>
        public void psTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS ParkingSpace ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "GarageNum  INT, " +
                                    "SpaceNum   INT     UNIQUE, " +
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

        /// <summary>
        /// 停车位数据库 插入默认记录
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SParkingSpaceStru sParkingSpaceStru = new SParkingSpaceStru( 1, 1, 1, "TestCardNum", 10, 12, 0, 0, 0, 0, 0, 0, "", "", "", "粤A-88888", "none" );
            object sObject = sParkingSpaceStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        /// <summary>
        /// 停车位数据库 读取所有记录
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM ParkingSpace";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车位数据库 条件查询
        /// </summary>
        /// <param name="sCond"></param>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SParkingSpaceQueryStru sQueryStru = (SParkingSpaceQueryStru)sCond;

            if ( !sQueryStru.bIdEn && !sQueryStru.bGarageNumEn && !sQueryStru.bSpaceNumEn && !sQueryStru.bCardNumEn && !sQueryStru.bSpaceLockStatEn && !sQueryStru.bSpaceTypeEn && !sQueryStru.bSpaceAeraEn && !sQueryStru.bCarPlate ) {
                return dataBaseBaseCommRead();
            }

            bool bFirstFlag = true;
            hCmd.CommandText = "SELECT * FROM ParkingSpace WHERE ";
            if ( sQueryStru.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@Id";
            }
            if ( sQueryStru.bGarageNumEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "GarageNum=@GarageNum";
            }
            if ( sQueryStru.bSpaceNumEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "SpaceNum=@SpaceNum";
            }
            if ( sQueryStru.bCardNumEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CardNum=@CardNum";
            }
            if ( sQueryStru.bSpaceLockStatEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "LockStat=@LockStat";
            }
            if ( sQueryStru.bSpaceTypeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "SpaceType=@SpaceType";
            }
            if ( sQueryStru.bSpaceAeraEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "SpaceAera=@SpaceAera";
            }
            if ( sQueryStru.bCarPlate ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CarPlate=@CarPlate";
            }

            if ( sQueryStru.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "Id", sQueryStru.iId ) );
            }
            if ( sQueryStru.bGarageNumEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "GarageNum", sQueryStru.bGarageNumEn ) );
            }
            if ( sQueryStru.bSpaceNumEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "SpaceNum", sQueryStru.iSpaceNum ) );
            }
            if ( sQueryStru.bCardNumEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sQueryStru.strCardNum ) );
            }
            if ( sQueryStru.bSpaceLockStatEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "LockStat", CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[sQueryStru.iLockStat] ) );
            }
            if ( sQueryStru.bSpaceTypeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "SpaceType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sQueryStru.iSpaceType] ) );
            }
            if ( sQueryStru.bSpaceAeraEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "SpaceAera", CDbBaseTable.strDbBaseParkingSpaceAeraDesc[sQueryStru.iSpaceAera] ) );
            }
            if ( sQueryStru.bCarPlate ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sQueryStru.strCarPlate ) );
            }

            base.dataBaseBaseRecordRead();

            return hReader;

        }
        /// <summary>
        /// 停车位数据库 按照List读取
        /// </summary>
        /// <param name="sCond">null读取全部</param>
        /// <returns></returns>
        public override List<object> dataBaseBaseListQuery (ref object sCond)
        {
            if ( null == sCond ) {
                dataBaseBaseCommRead();
            } else {
                dataBaseBaseCommQuery( ref sCond );
            }

            if ( null == hReader ) {
                return null;
            }

            if ( !hReader.HasRows ) {
                hReader.Close();

                return null;
            }

            List<object> listStru = new List<object>();
            SParkingSpaceStru sStru;

            while ( hReader.Read() ) {
                try {
                    int i = 0;
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

                    listStru.Add( sStru );
                } catch ( Exception ex ) {
                    CDebugPrint.dbgUserMsgPrint( "dataBaseBaseListQuery fail..." );
                    CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                    CDebugPrint.dbgExpectionMsgPrint( ex );
                }
            }

            hReader.Close();

            return listStru;
        }

        /// <summary>
        /// 停车位数据库 插入一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 停车位数据库 删除一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SParkingSpaceStru sRcuStru = (SParkingSpaceStru)sRecord;

            hCmd.CommandText = "DELETE FROM ParkingSpace WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车位数据库 更新一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 停车位数据库 获取表头描述
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strParkingSpaceHeadDesc;
        }

        /// <summary>
        /// 停车位数据库 清空表
        /// </summary>
        /// <returns></returns>
        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "ParkingSpace" );
        }

        /// <summary>
        /// 停车位数据库 读取所有记录到列表
        /// </summary>
        /// <param name="listParkingSpace">数据记录列表</param>
        /// <returns></returns>
        public bool dbParkingSpaceRead (ref List<SParkingSpaceStru> listParkingSpace)
        {
            dataBaseBaseCommRead();

            if ( null == hReader ) {
                return false;
            }

            if ( !hReader.HasRows ) {
                hReader.Close();
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
            hReader.Close();

            return true;
        }
    }
}
