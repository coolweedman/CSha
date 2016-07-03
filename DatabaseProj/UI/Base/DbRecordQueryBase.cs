using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using DatabaseProj.Code.Debug;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI.Base {
    public partial class DbRecordQueryBase : Form {

        protected CDatebaseBase hDbTable;
        protected DataTable hDataTable;

        protected int iDgvLeftSelectedRow;
        protected int iDgvLeftSelectedCol;

        protected int iDgvRightSelectedRow;
        protected int iDgvRightSelectedCol;

        /// <summary>
        /// 数据库查询界面基类 构造函数
        /// </summary>
        /// <param name="hDbTableBase">数据库基类</param>
        public DbRecordQueryBase (CDatebaseBase hDbTableBase, string strTitle = "DbRecordQueryBase")
        {
            InitializeComponent();

            hDbTable = hDbTableBase;
            dbRecordQueryInit();
            this.Text = strTitle;
        }

        /// <summary>
        /// 数据库查询界面基类 构造函数
        /// </summary>
        public DbRecordQueryBase ()
        {
            InitializeComponent();
            dbRecordQueryInit();
        }

        protected virtual void dbRecordQueryUiInit ()
        {
        }

        /// <summary>
        /// 数据库记录查询 初始化
        /// </summary>
        protected void dbRecordQueryInit ()
        {
            hDataTable = new DataTable();
        }

        /// <summary>
        /// 数据库记录查询 刷新数据
        /// </summary>
        /// <param name="hReader"></param>
        protected void dbRecordQueryReFlash (SQLiteDataReader hReader)
        {
            try {
                hDataTable.Clear();
                hDataTable.Load( hReader );
                dataGridViewDb.DataSource = hDataTable;
                dbRecordQueryHeadSet( hDbTable.dataBaseBaseHeadDescGet() );
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbRecordQuery: Reflash fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 数据库记录查询 设置表头
        /// </summary>
        /// <param name="strHead"></param>
        protected void dbRecordQueryHeadSet (string[] strHead)
        {
            int i;

            for ( i = 0; i < strHead.Length; i++ ) {
                dataGridViewDb.Columns[i].HeaderText = strHead[i];
            }
        }

        /// <summary>
        /// 数据库查询界面基类 UI转换到结构体
        /// </summary>
        /// <returns></returns>
        protected virtual object dbRecordQueryUi2Stru ()
        {
            return null;
        }

        /// <summary>
        /// 数据库查询界面基类 查询按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click (object sender, EventArgs e)
        {
            object sObject;

            sObject = dbRecordQueryUi2Stru();
            dbRecordQueryReFlash( hDbTable.dataBaseBaseCommQuery( ref sObject ) );
        }

        /// <summary>
        /// 数据库查询界面基类 取消按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
