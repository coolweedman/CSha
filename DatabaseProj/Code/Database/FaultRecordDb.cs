using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using DatabaseProj.Code.Debug;
using System.Diagnostics;

namespace DatabaseProj.Code.Database {
    public class CFaultRecordDb : CDatebaseBase {

        public struct SFaultRecordStru {
            public int iId;
            public int iParkingSpaceId;
            public DateTime sStartTime;
            public string strFaultCont;
            public int iFaultId;
            public DateTime sConfirmTime;
            public string strComment;

            public SFaultRecordStru (int Id, int ParkingSopaceId, DateTime StartTime, string FaultCont, int FaultId, DateTime ConfirmTime, string Comment)
            {
                iId = Id;
                iParkingSpaceId = ParkingSopaceId;
                sStartTime = StartTime;
                strFaultCont = FaultCont;
                iFaultId = FaultId;
                sConfirmTime = ConfirmTime;
                strComment = Comment;
            }
        };

        public struct SFaultRecordQueryStru {
            public bool bIdEn;
            public bool bParkingSpaceIdEn;
            public bool bStartTimeEn;
            public bool bFaultContEn;
            public bool bFaultIdEn;
            public bool bConfirmTime;

            public int iId;
            public int iParkingSpaceId;
            public DateTime sStartTime;
            public string strFaultCont;
            public int iFaultId;
            public DateTime sConfirmTime;
        };

        public enum EFaultId {
            FAULTRECORD_NONE = 0,
            FAULTRECORD_CLEANING,
            FAULTRECORD_FAULT,
            FAULTRECORD_FIXING,
        };

        public static string[] strFaultRecordHeadDesc = {
            "ID",
            "车库号",
            "发生时间",
            "故障内容",
            "代码",
            "确认时间",
            "备注",
        };

        public CFaultRecordDb ()
        {
            frTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        public void frTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS FaultRecord ( " +
                                    "Id             INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "ParkingSpaceId INT, " +
                                    "StartTime      DATETIME, " +
                                    "FaultCont      TEXT, " +
                                    "FaultId      INT, " +
                                    "ConfirmTime    DATETIME, " +
                                    "Comment        TEXT, " +
                                    "FOREIGN        KEY(ParkingSpaceId)  REFERENCES  ParkingSpace(Id), " +
                                    ")";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override void dataBaseBaseDeRecordInsert ()
        {
            SFaultRecordStru sFaultRecordStru = new SFaultRecordStru( 1, 1, DateTime.Parse( "2016-8-1 10:00:00" ), "车位清洁中", 0, DateTime.Now, "null");
            object sObject = sFaultRecordStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM FaultRecord";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SFaultRecordQueryStru sQueryStru = (SFaultRecordQueryStru)sCond;

            if ( !sQueryStru.bIdEn && !sQueryStru.bParkingSpaceIdEn && !sQueryStru.bStartTimeEn && !sQueryStru.bFaultContEn && !sQueryStru.bConfirmTime && !sQueryStru.bFaultIdEn ) {
                return dataBaseBaseCommRead();
            }

            bool bFirstFlag = true;
            hCmd.CommandText = "SELECT * FROM FaultRecord WHERE ";

            if ( sQueryStru.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@Id";
            }
            if ( sQueryStru.bParkingSpaceIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "ParkingSpaceId=@ParkingSpaceId";
            }
            if ( sQueryStru.bStartTimeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "StartTime=@StartTime";
            }
            if ( sQueryStru.bFaultContEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "FaultCont=@FaultCont";
            }
            if ( sQueryStru.bFaultIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "FaultId=@FaultId";
            }
            if ( sQueryStru.bConfirmTime ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "ConfirmTime=@ConfirmTime";
            }

            if ( sQueryStru.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "Id", sQueryStru.iId ) );
            }
            if ( sQueryStru.bParkingSpaceIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "ParkingSpaceId", sQueryStru.iParkingSpaceId ) );
            }
            if ( sQueryStru.bStartTimeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "StartTime", sQueryStru.sStartTime ) );
            }
            if ( sQueryStru.bFaultContEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "FaultCont", sQueryStru.strFaultCont ) );
            }
            if ( sQueryStru.bConfirmTime ) {
                hCmd.Parameters.Add( new SQLiteParameter( "FaultCode", sQueryStru.sConfirmTime ) );
            }
            if ( sQueryStru.bFaultIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "ConfirmTime", sQueryStru.iFaultId ) );
            }

            base.dataBaseBaseRecordRead();

            return hReader;
        }

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
            SFaultRecordStru sStru = new SFaultRecordStru();

            while ( hReader.Read() ) {
                try {
                    int i = 0;
                    sStru.iId = hReader.GetInt32( i++ );
                    sStru.iParkingSpaceId = hReader.GetInt32( i++ );
                    sStru.sStartTime = hReader.GetDateTime( i++ );
                    sStru.strFaultCont = hReader.GetString( i++ );
                    sStru.sConfirmTime = hReader.GetDateTime( i++ );
                    sStru.iFaultId = hReader.GetInt32( i++ );

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

        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SFaultRecordStru sFrStru = (SFaultRecordStru)sRecord;

            hCmd.CommandText = "INSERT INTO FaultRecord(ParkingSpaceId, StartTime, FaultCont, FaultId, ConfirmTime, Comment) " +
                               "VALUES(@ParkingSpaceId, @StartTime, @FaultCont, @FaultId, @ConfirmTime, @Comment)";

            hCmd.Parameters.Add( new SQLiteParameter ( "ParkingSpaceId", sFrStru.iParkingSpaceId ) );
            hCmd.Parameters.Add( new SQLiteParameter ( "StartTime", sFrStru.sStartTime ) );
            hCmd.Parameters.Add( new SQLiteParameter ( "FaultCont", sFrStru.strFaultCont ) );
            hCmd.Parameters.Add( new SQLiteParameter ( "FaultId", sFrStru.sConfirmTime ) );
            hCmd.Parameters.Add( new SQLiteParameter ( "ConfirmTime", sFrStru.iFaultId ) );
            hCmd.Parameters.Add( new SQLiteParameter ( "Comment", sFrStru.strComment ) );

            return base.dataBaseBaseCommAdd ( ref sRecord );
        }

        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SFaultRecordStru sRcuStru = (SFaultRecordStru)sRecord;

            hCmd.CommandText = "DELETE FROM FaultRecord WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcuStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SFaultRecordStru sRcuStru = (SFaultRecordStru)sRecord;

            hCmd.CommandText = "UPDATE FaultRecord SET " +
                               "ParkingSpaceId=@ParkingSpaceId, " +
                               "StartTime=@StartTime, " +
                               "FaultCont=@FaultCont, " +
                               "FaultId=@FaultId, " +
                               "ConfirmTime=@ConfirmTime, " +
                               "Comment=@Comment, " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "iParkingSpaceId", sRcuStru.iParkingSpaceId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "StartTime", sRcuStru.sStartTime ) );
            hCmd.Parameters.Add( new SQLiteParameter( "FaultCont", sRcuStru.strFaultCont ) );
            hCmd.Parameters.Add( new SQLiteParameter( "FaultId", sRcuStru.sConfirmTime ) );
            hCmd.Parameters.Add( new SQLiteParameter( "ConfirmTime", sRcuStru.iFaultId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Comment", sRcuStru.strComment ) );

            return base.dataBaseBaseCommCmdExec();
        }

        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strFaultRecordHeadDesc;
        }

        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "FaultRecord" );
        }

    }
}
