using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardView : CDatebaseBase {

        /// <summary>
        /// 停车卡视图 查询
        /// </summary>
        public struct SRegularCardViewQueryStru {
            public CRegularCardUserDb.SRegularCardUserQueryStru sUserQuery;
            public CRegularCardPaymentDb.SRegularCardPaymentQueryStru sPaymentQuery;
        };

        public static string[] strRegularCardViewHeadDesc = {
            "固定卡ID",
            "姓名",
            "身份证",
            "电话",
            "车牌",
            "卡号",
            "卡类型",
            "车类型",
            "付费ID",
            "付款时间",
            "付款金额",
            "有效时间",
  };

        protected CRegularCardUserDb hRegularCardUserDb;
        protected CRegularCardPaymentDb hRegularCardPaymentDb;

        /// <summary>
        /// 停车卡视图 构造函数
        /// </summary>
        public CRegularCardView ()
        {
            hRegularCardUserDb = new CRegularCardUserDb();
            hRegularCardPaymentDb = new CRegularCardPaymentDb();

            rcvViewCreate();
        }

        /// <summary>
        /// 停车卡视图 创建视图
        /// </summary>
        public void rcvViewCreate ()
        {
            string strCreateTable = "CREATE VIEW IF NOT EXISTS  RegularCardView AS SELECT " +
                                    "RegularCardUser.Id, " +
                                    "RegularCardUser.UserName, " +
                                    "RegularCardUser.UserIdent, " +
                                    "RegularCardUser.UserPhone, " +
                                    "RegularCardUser.CarPlate, " +
                                    "RegularCardUser.CardNum, " +
                                    "RegularCardUser.CardType, " +
                                    "RegularCardUser.CarType, " +
                                    "RegularCardPayment.Id, " +
                                    "RegularCardPayment.PayTime, " +
                                    "RegularCardPayment.PayMoney, " +
                                    "RegularCardPayment.ValidTime " +
                                    "FROM RegularCardUser INNER JOIN RegularCardPayment " +
                                    "ON   RegularCardUser.Id = RegularCardPayment.RcuId";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        /// <summary>
        /// 停车卡视图 读取所有记录
        /// </summary>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardView";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车卡视图 查询记录
        /// </summary>
        /// <param name="sCond"></param>
        /// <returns></returns>
        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            SRegularCardViewQueryStru sQueryStru = (SRegularCardViewQueryStru)sCond;


            if ( !sQueryStru.sUserQuery.bIdEn &&
                 !sQueryStru.sUserQuery.bUserNameEn &&
                 !sQueryStru.sUserQuery.bUserIdent &&
                 !sQueryStru.sUserQuery.bUserPhone &&
                 !sQueryStru.sUserQuery.bCarPlate &&
                 !sQueryStru.sUserQuery.bCardNum &&
                 !sQueryStru.sUserQuery.bCardType &&
                 !sQueryStru.sUserQuery.bCarType &&
                 !sQueryStru.sPaymentQuery.bIdEn &&
                 !sQueryStru.sPaymentQuery.bPayTimeEn &&
                 !sQueryStru.sPaymentQuery.bPayMoneyEn &&
                 !sQueryStru.sPaymentQuery.bValidTimeEn ) {

                return dataBaseBaseCommRead();
            }

            bool bFirstFlag = true;

            hCmd.CommandText = "SELECT * FROM RegularCardView WHERE ";

            if ( sQueryStru.sUserQuery.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@RcuId";
            }
            if ( sQueryStru.sUserQuery.bUserNameEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserName=@UserName";
            }
            if ( sQueryStru.sUserQuery.bUserIdent ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserIdent=@UserIdent";
            }
            if ( sQueryStru.sUserQuery.bUserPhone ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "UserPhone=@UserPhone";
            }
            if ( sQueryStru.sUserQuery.bCarPlate ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CarPlate=@CarPlate";
            }
            if ( sQueryStru.sUserQuery.bCardNum ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CardNum=@CardNum";
            }
            if ( sQueryStru.sUserQuery.bCardType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CardType=@CardType";
            }
            if ( sQueryStru.sUserQuery.bCarType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "CarType=@CarType";
            }
            if ( sQueryStru.sPaymentQuery.bIdEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "Id=@RcpId";
            }
            if ( sQueryStru.sPaymentQuery.bPayTimeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "PayTime>=@PayTimeStart AND PayTime<=@PayTimeEnd";
            }
            if ( sQueryStru.sPaymentQuery.bPayMoneyEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "PayMoney=@PayMoney";
            }
            if ( sQueryStru.sPaymentQuery.bValidTimeEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += " AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "ValidTime>=@ValidTimeStart AND ValidTime<=@ValidTimeEnd";
            }

            if ( sQueryStru.sUserQuery.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "RcuId", sQueryStru.sUserQuery.iId ) );
            }
            if ( sQueryStru.sUserQuery.bUserNameEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserName", sQueryStru.sUserQuery.strUserName ) );
            }
            if ( sQueryStru.sUserQuery.bUserIdent ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserIdent", sQueryStru.sUserQuery.strUserIdent ) );
            }
            if ( sQueryStru.sUserQuery.bUserPhone ) {
                hCmd.Parameters.Add( new SQLiteParameter( "UserPhone", sQueryStru.sUserQuery.strUserPhone ) );
            }
            if ( sQueryStru.sUserQuery.bCarPlate ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CarPlate", sQueryStru.sUserQuery.strCarPlate ) );
            }
            if ( sQueryStru.sUserQuery.bCardNum ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CardNum", sQueryStru.sUserQuery.strCardNum ) );
            }
            if ( sQueryStru.sUserQuery.bCardType ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CardType", CDbBaseTable.strDbBaseParkingCardTypeDesc[sQueryStru.sUserQuery.iCardType] ) );
            }
            if ( sQueryStru.sUserQuery.bCarType ) {
                hCmd.Parameters.Add( new SQLiteParameter( "CarType", CDbBaseTable.strDbBaseParkingCarTypeDesc[sQueryStru.sUserQuery.iCarType] ) );
            }
            if ( sQueryStru.sPaymentQuery.bIdEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "RcpId", sQueryStru.sPaymentQuery.iId ) );
            }
            if ( sQueryStru.sPaymentQuery.bPayTimeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "PayTimeStart", sQueryStru.sPaymentQuery.sPayTimeStart ) );
                hCmd.Parameters.Add( new SQLiteParameter( "PayTimeEnd", sQueryStru.sPaymentQuery.sPayTimeStop ) );
            }
            if ( sQueryStru.sPaymentQuery.bPayMoneyEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "PayMoney", sQueryStru.sPaymentQuery.dPayMoney ) );
            }
            if ( sQueryStru.sPaymentQuery.bValidTimeEn ) {
                hCmd.Parameters.Add( new SQLiteParameter( "ValidTimeStart", sQueryStru.sPaymentQuery.sValidTimeStart ) );
                hCmd.Parameters.Add( new SQLiteParameter( "ValidTimeEnd", sQueryStru.sPaymentQuery.sValidTimeStop ) );
            }

            base.dataBaseBaseRecordRead();

            return hReader;
        }

        /// <summary>
        /// 停车卡视图 表头获取
        /// </summary>
        /// <returns></returns>
        public override string[] dataBaseBaseHeadDescGet ()
        {
            return strRegularCardViewHeadDesc;
        }

    }
}
