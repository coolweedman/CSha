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
    public partial class ParkingSpaceQueryUi : Form {

        public CParkingSpaceDb hParkingSpaceDb;
        public DataTable hDataTable;
        public CParkingSpaceDb.SParkingSpaceQueryStru sParkingSpaceQueryStru;

        public ParkingSpaceQueryUi (CParkingSpaceDb hPsDb=null)
        {
            InitializeComponent();

            hParkingSpaceDb = hPsDb;
            hDataTable = new DataTable();

            psqUiInit();
            psqDgvDeInit();
        }


        public void psqUiInit ()
        {
            for ( int i = 0; i < CDbBaseTable.strDbBaseParkingSpaceLockStatDesc.Length; i++ ) {
                comboBoxLockStat.Items.Add( CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[i] );
            }
            for ( int i = 0; i < CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxSpaceType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }
            for ( int i = 0; i < CDbBaseTable.strDbBaseParkingSpaceAeraDesc.Length; i++ ) {
                comboBoxSpaceAera.Items.Add( CDbBaseTable.strDbBaseParkingSpaceAeraDesc[i] );
            }
        }

        public void psqDgvFlash ()
        {
            object sCond = sParkingSpaceQueryStru;
            try {
                hDataTable.Clear();
                hDataTable.Load( hParkingSpaceDb.dataBaseBaseCommQuery( ref sCond ) );
                dataGridView.DataSource = hDataTable;

                for ( int i = 0; i < CParkingSpaceDb.strParkingSpaceHeadDesc.Length; i++ ) {
                    dataGridView.Columns[i].HeaderText = CParkingSpaceDb.strParkingSpaceHeadDesc[i];
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "psqDgvFlash: Reflash fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        public void psqDgvDeInit ()
        {
            try {
                hDataTable.Clear();
                hDataTable.Load( hParkingSpaceDb.dataBaseBaseCommRead() );
                dataGridView.DataSource = hDataTable;

                for ( int i = 0; i < CParkingSpaceDb.strParkingSpaceHeadDesc.Length; i++ ) {
                    dataGridView.Columns[i].HeaderText = CParkingSpaceDb.strParkingSpaceHeadDesc[i];
                }
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "psqDgvDeInit: Reflash fail..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        private void psqUi2Stru ()
        {
            sParkingSpaceQueryStru.bSpaceLockStatEn = checkBoxLockStat.Checked;
            sParkingSpaceQueryStru.bSpaceTypeEn = checkBoxSpaceType.Checked;
            sParkingSpaceQueryStru.bSpaceAeraEn = checkBoxSpaceAera.Checked;

            sParkingSpaceQueryStru.iLockStat = comboBoxLockStat.SelectedIndex;
            sParkingSpaceQueryStru.iSpaceType = comboBoxSpaceType.SelectedIndex;
            sParkingSpaceQueryStru.iSpaceAera = comboBoxSpaceAera.SelectedIndex;
        }

        private void buttonOk_Click (object sender, EventArgs e)
        {
            psqUi2Stru();
            psqDgvFlash();
        }

        private void buttonCancel_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
