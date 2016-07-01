﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardPaymentDb : CDatebaseBase {

        /// <summary>
        /// 停车卡缴费 结构体
        /// </summary>
        public struct SRegularCardPaymentStru {
            public int iId;
            public int iRcuId;
            public DateTime sPayTime;
            public double dPayMoney;
            public DateTime sVaildTime;

            public SRegularCardPaymentStru (int Id, int RcuId, DateTime PayTime, double PayMoney, DateTime VaildTime)
            {
                iId = Id;
                iRcuId = RcuId;
                sPayTime = PayTime;
                dPayMoney = PayMoney;
                sVaildTime = VaildTime;
            }
        }

        /// <summary>
        /// 停车卡缴费 查询结构体
        /// </summary>
        public struct SRegularCardPaymentQueryStru {
            public bool bIdEn;
            public bool bRcuIdEn;
            public bool bPayTimeEn;
            public bool bPayMoneyEn;
            public bool bValidTimeEn;

            public int iId;
            public int iRcuId;
            public DateTime sPayTimeStart;
            public DateTime sPayTimeStop;
            public double dPayMoney;
            public DateTime sValidTimeStart;
            public DateTime sValidTimeStop;
        };

        /// <summary>
        /// 停车卡缴费 表头描述
        /// </summary>
        public static string[] strRegularCardPaymentHeadDesc = {
            "ID",
            "固定卡ID",
            "付款时间",
            "付款金额",
            "有效时间",
        };

        /// <summary>
        /// 停车卡缴费 构造函数 创建表 使能外键
        /// </summary>
        public CRegularCardPaymentDb ()
        {
            rcpTableCreate();
            base.sqlite3ForeignKeyEn();
        }

        /// <summary>
        /// 停车卡缴费 创建表
        /// </summary>
        public void rcpTableCreate ()
        {
            string strCreateTable = "CREATE TABLE IF NOT EXISTS RegularCardPayment ( " +
                                    "Id         INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "RcuId      INT, " +
                                    "PayTime    DATETIME, " +
                                    "PayMoney   REAL, " +
                                    "VaildTime  DATETIME, " +
                                    "FOREIGN    KEY(RcuId)  REFERENCES  RegularCardUser(Id) )";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 停车卡缴费 插入默认记录
        /// </summary>
        public override void dataBaseBaseDeRecordInsert ()
        {
            SRegularCardPaymentStru sRcpStru = new SRegularCardPaymentStru( 1, 1, DateTime.Now, 100, DateTime.Parse( "2020-1-1 23:59:59" ) );
            object sObject = sRcpStru;
            dataBaseBaseCommAdd( ref sObject );
        }

        /// <summary>
        /// 停车卡缴费 读取所有记录
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardPayment";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车卡缴费 查询
        /// </summary>
        /// <param name="sCond">查询条件</param>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SRegularCardPaymentQueryStru sQueryStru = (SRegularCardPaymentQueryStru)sCond;

            if ( !sQueryStru.bIdEn && !sQueryStru.bRcuIdEn && !sQueryStru.bPayTimeEn && !sQueryStru.bPayMoneyEn && !sQueryStru.bValidTimeEn ) {
                return dataBaseBaseCommRead();
            }

            bool bFirstFlag = true;
            hCmd.CommandText = "SELECT * FROM RegularCardPayment WHERE ";

            if ( sQueryStru.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@Id";
            }
            if ( sQueryStru.bRcuIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RcuId=@RcuId";
            }
            if ( sQueryStru.bPayTimeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "PayTime>=@PayTimeStart AND PayTime<=@PayTimeEnd";
            }
            if ( sQueryStru.bPayMoneyEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "PayMoney=@PayMoney";
            }
            if ( sQueryStru.bValidTimeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "VaildTime>=@VaildTimeStart AND VaildTime<=@VaildTimeEnd";
            }

            if ( sQueryStru.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "Id", sQueryStru.iId ) );
            }
            if ( sQueryStru.bRcuIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sQueryStru.iRcuId ) );
            }
            if ( sQueryStru.bPayTimeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "PayTimeStart", sQueryStru.sPayTimeStart ) );
                hCmd.Parameters.Add( new SQLiteParameter( "PayTimeEnd", sQueryStru.sPayTimeStop ) );
            }
            if ( sQueryStru.bPayMoneyEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sQueryStru.dPayMoney ) );
            }
            if ( sQueryStru.bValidTimeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "VaildTimeStart", sQueryStru.sValidTimeStart ) );
                hCmd.Parameters.Add( new SQLiteParameter( "VaildTimeEnd", sQueryStru.sValidTimeStop ) );
            }

            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车卡缴费 添加一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommAdd (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "INSERT INTO RegularCardPayment(RcuId, PayTime, PayMoney, VaildTime) " +
                               "VALUES(@RcuId, @PayTime, @PayMoney, @VaildTime)";

            hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sRcpStru.iRcuId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcpStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcpStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcpStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 删除一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommDelete (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "DELETE FROM RegularCardPayment WHERE Id=@Id";
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcpStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 更新一条记录
        /// </summary>
        /// <param name="sRecord"></param>
        /// <returns></returns>
        public override int dataBaseBaseCommUpdate (ref object sRecord)
        {
            SRegularCardPaymentStru sRcpStru = (SRegularCardPaymentStru)sRecord;

            hCmd.CommandText = "UPDATE RegularCardPayment SET " +
                               "RcuId=@RcuId, " +
                               "PayTime=@PayTime, " +
                               "PayMoney=@PayMoney, " +
                               "VaildTime=@VaildTime " +
                               "WHERE Id=@Id";

            hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sRcpStru.iRcuId ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayTime", sRcpStru.sPayTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sRcpStru.dPayMoney ) );
            hCmd.Parameters.Add( new SQLiteParameter( "VaildTime", sRcpStru.sVaildTime.ToString( "yyyy-MM-dd HH:mm:ss" ) ) );
            hCmd.Parameters.Add( new SQLiteParameter( "Id", sRcpStru.iId ) );

            return base.dataBaseBaseCommCmdExec();
        }

        /// <summary>
        /// 停车卡缴费 获取表头描述
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardPaymentHeadDesc;
        }

        /// <summary>
        /// 停车卡缴费 清空表
        /// </summary>
        /// <returns></returns>
        public override int dataBaseBaseCommTableClr ()
        {
            return base.dataBaseBaseTableClr( "RegularCardPayment" );
        }
    }
}
