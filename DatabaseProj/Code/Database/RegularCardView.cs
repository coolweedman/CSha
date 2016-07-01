﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace DatabaseProj.Code.Database {
    public class CRegularCardView : CDatebaseBase {

        public struct SRegularCardViewQueryStru {
            public CRegularCardUserDb.SRegularCardUserQueryStru sUserQuery;
            public CRegularCardPaymentDb.SRegularCardPaymentQueryStru sPaymentQuery;
        };

        protected CRegularCardUserDb hRegularCardUserDb;
        protected CRegularCardPaymentDb hRegularCardPaymentDb;

        public CRegularCardView ()
        {
            hRegularCardUserDb = new CRegularCardUserDb();
            hRegularCardPaymentDb = new CRegularCardPaymentDb();

            rcvViewCreate();
        }

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
                                    "RegularCardPayment.PayTime, " +
                                    "RegularCardPayment.PayMoney, " +
                                    "RegularCardPayment.VaildTime " +
                                    "FROM RegularCardUser INNER JOIN RegularCardPayment " +
                                    "ON   RegularCardUser.Id = RegularCardPayment.RcuId";

            base.dataBaseBaseTableCreate( strCreateTable );
        }

        public override SQLiteDataReader dataBaseBaseCommRead ()
        {
            hCmd.CommandText = "SELECT * FROM RegularCardView";
            base.dataBaseBaseRecordRead();

            return hReader;
        }

        public override SQLiteDataReader dataBaseBaseCommQuery (ref object sCond)
        {
            bool bFirstFlag = true;

            SRegularCardViewQueryStru sQueryStru = (SRegularCardViewQueryStru)sCond;


            if ( !sQueryStru.sUserQuery.bUserNameEn &&
                 !sQueryStru.sUserQuery.bUserIdent &&
                 !sQueryStru.sUserQuery.bUserPhone &&
                 !sQueryStru.sUserQuery.bCarPlate &&
                 !sQueryStru.sUserQuery.bCarNum &&
                 !sQueryStru.sUserQuery.bCardType &&
                 !sQueryStru.sUserQuery.bCarType &&
                 !sQueryStru.sPaymentQuery.bPayTimeEn &&
                 !sQueryStru.sPaymentQuery.bPayMoneyEn &&
                 !sQueryStru.sPaymentQuery.bValidTimeEn ) {

                return dataBaseBaseCommRead();
            }

            hCmd.CommandText = "SELECT * FROM RegularCardView WHERE ";

            if ( sQueryStru.sUserQuery.bUserNameEn ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.Id=@RegularCardUser.Id";
            }
            if ( sQueryStru.sUserQuery.bUserIdent ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.UserIdent=@RegularCardUser.UserIdent";
            }
            if ( sQueryStru.sUserQuery.bUserPhone ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.UserPhone=@RegularCardUser.UserPhone";
            }
            if ( sQueryStru.sUserQuery.bCarPlate ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.CarPlate=@RegularCardUser.CarPlate";
            }
            if ( sQueryStru.sUserQuery.bCarNum ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.CarNum=@RegularCardUser.CarNum";
            }
            if ( sQueryStru.sUserQuery.bCardType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.CardType=@RegularCardUser.CardType";
            }
            if ( sQueryStru.sUserQuery.bCarType ) {
                if ( !bFirstFlag ) {
                    hCmd.CommandText += "AND ";
                }
                bFirstFlag = false;

                hCmd.CommandText += "RegularCardUser.CarType=@RegularCardUser.CarType";
            }

            return null;
        }
    }
}
