using DatabaseProj.Code.Debug;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProj.UI.Base {
    public partial class DbDataShowBase : Form {

        /// <summary>
        /// 数据库数据显示 状态枚举
        /// </summary>
        public enum EDbDataShowStat {
            DBDATASHOW_INIT = 0,
            DBDATASHOW_READY,
            DBDATASHOW_SUCCEESSED,
            DBDATASHOW_FAILED,
            DBDATASHOW_WAITTING,
        };

        /// <summary>
        /// 数据库数据显示 状态字符串
        /// </summary>
        public static string[] strDbDataShowStat =
        {
            "Init...",
            "Ready",
            "Succeessed",
            "Failed",
            "Waitting",
        };

        protected DataTable hDataTable;

        protected int iDgvLeftSelectedRow;
        protected int iDgvLeftSelectedCol;

        protected int iDgvRightSelectedRow;
        protected int iDgvRightSelectedCol;


        /// <summary>
        /// 数据库数据显示 构造函数
        /// </summary>
        public DbDataShowBase ()
        {
            InitializeComponent();
            dbDataShowInit();
        }

        /// <summary>
        /// 数据库数据显示 初始化
        /// </summary>
        protected void dbDataShowInit ()
        {
            hDataTable = new DataTable();

            dbDataShowStatSet( EDbDataShowStat.DBDATASHOW_READY );
        }

        /// <summary>
        /// 数据库数据显示 刷新数据
        /// </summary>
        /// <param name="hReader"></param>
        protected void dbDataShowReFlash (SQLiteDataReader hReader)
        {
            try {
                hDataTable.Clear();
                hDataTable.Load( hReader );
                dataGridViewDb.DataSource = hDataTable;
            } catch (Exception ex) {
                CDebugPrint.dbgUserMsgPrint( "DbDataShow: Reflash fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库数据显示 设置表头
        /// </summary>
        /// <param name="strHead"></param>
        protected void dbDataShowHeadSet (string[] strHead)
        {
            int i;

            for ( i=0; i<strHead.Length; i++ ) {
                dataGridViewDb.Columns[i].HeaderText = strHead[i];
            }
        }

        /// <summary>
        /// 数据库数据显示 状态栏更新
        /// </summary>
        /// <param name="eStat"></param>
        protected void dbDataShowStatSet (EDbDataShowStat eStat)
        {
            int iStat = (int)eStat;

            toolStripStatusLabel.Text = strDbDataShowStat[iStat];
        }

        /// <summary>
        /// 数据库数据显示 数据转换到字符串列表
        /// </summary>
        /// <param name="listStr">字符串列表</param>
        protected void dbDataShowDgv2StringList (List<string> listStr)
        {
            int i;

            for ( i = 0; i < dataGridViewDb.ColumnCount; i++ ) {
                listStr.Add( dataGridViewDb.Rows[iDgvLeftSelectedRow].Cells[i].Value.ToString() );
            }
        }

        /// <summary>
        /// 鼠标按键时间处理 获取坐标并调用右键处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDb_CellMouseDown (object sender, DataGridViewCellMouseEventArgs e)
        {
            if ( MouseButtons.Left == e.Button ) {
                if ( e.RowIndex >= 0 ) {
                    iDgvLeftSelectedRow = e.RowIndex;
                    iDgvLeftSelectedCol = e.ColumnIndex;
                }
            } else if ( MouseButtons.Right == e.Button ) {
                if ( e.RowIndex >= 0 ) {
                    iDgvRightSelectedRow = e.RowIndex;
                    iDgvRightSelectedCol = e.ColumnIndex;

                    EDbDataShowStat eStat;

                    eStat = dbDataShowButtonCb( iDgvRightSelectedRow, iDgvRightSelectedCol );
                    dbDataShowStatSet( eStat );
                }
            }
        }

        /// <summary>
        /// 鼠标右键处理函数
        /// </summary>
        /// <param name="iX"></param>
        /// <param name="iY"></param>
        /// <returns></returns>
        protected virtual EDbDataShowStat dbDataShowButtonCb (int iX, int iY)
        {
            return EDbDataShowStat.DBDATASHOW_FAILED;
        }
    }
}
