using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using System.Diagnostics;

namespace DatabaseProj.UI {
    public partial class DbWinBase : Form {

        public CDatebaseBase hDatabaseBase;
        public DbEditWinIf hDbEditWinIf;
        public DataTable hDataTable;

        public int iDgvLeftSelectedRow;
        public int iDgvLeftSelectedCol;

        public int iDgvRightSelectedRow;
        public int iDgvRightSelectedCol;

        public DbWinBase ()
        {
            InitializeComponent();
        }

        public void dbWinBaseInit (CDatebaseBase hDbBase, DbEditWinIf hDbEdit)
        {
            hDatabaseBase = hDbBase;
            hDbEditWinIf = hDbEdit;

            hDataTable = new DataTable();

            dbDgvReFlash();
            dbDgvHeadInit();
        }

        protected void dbDgvReFlash ()
        {
            try {
                hDataTable.Clear();
                hDataTable.Load( hDatabaseBase.dataBaseBaseCommRead() );
                dataGridViewDb.DataSource = hDataTable;
            } catch (Exception ex) {
                CDebugPrint.dbgUserMsgPrint( "DatabaseWinBase: Reflash fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        protected void dbDgvHeadInit ()
        {
            int i;
            string[] strHead;

            strHead = hDatabaseBase.dataBaseBaseHeadDescGet();
            
            for ( i=0; i<strHead.Length; i++ ) {
                dataGridViewDb.Columns[i].HeaderText = strHead[i];
            }
        }

        private void dbDgv2String (ref List<string> listStr)
        {
            int i;

            for ( i=0; i<dataGridViewDb.ColumnCount; i++ ) {
                listStr.Add( dataGridViewDb.Rows[iDgvLeftSelectedRow].Cells[i].Value.ToString() );
            }
        }

        public virtual void buttonAdd_Click (object sender, EventArgs e)
        {
            hDbEditWinIf.dbUiAddModeSet();
            hDbEditWinIf.dbUiShowDialog();

            if ( DialogResult.OK == hDbEditWinIf.dbFinishStatGet()) {
                object sRecord = hDbEditWinIf.dbStruGet();
                hDatabaseBase.dataBaseBaseCommAdd( ref sRecord );

                dbDgvReFlash();
            }
        }

        private void buttonReFlash_Click (object sender, EventArgs e)
        {
            dbDgvReFlash();
        }

        private void buttonClose_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }
    }
}
