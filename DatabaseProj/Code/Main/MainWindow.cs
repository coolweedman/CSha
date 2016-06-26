using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.UI;
using DatabaseProj.Code.Database;

namespace DatabaseProj.Code.Main {
    public partial class MainWindow : DevComponents.DotNetBar.Office2007Form {

        public MainWindow ()
        {
            InitializeComponent();

        }

        private void regularCardUserToolStripMenuItem_Click_1 (object sender, EventArgs e)
        {
            RegularCardUserUi hRegularCardUserUi = new RegularCardUserUi();
            hRegularCardUserUi.Show();
        }

        private void regularCardPaymentToolStripMenuItem_Click (object sender, EventArgs e)
        {
            RegularCardPaymentUi hRegularCardPayment = new RegularCardPaymentUi();
            hRegularCardPayment.Show();
        }

        private void parkingSpaceToolStripMenuItem_Click (object sender, EventArgs e)
        {
            ParkingSpaceUi hParkingSpaceUi = new ParkingSpaceUi();
            hParkingSpaceUi.Show();
        }

        private void dBAccountToolStripMenuItem_Click (object sender, EventArgs e)
        {
            DBAccountUi hDBAccountUi = new DBAccountUi();
            hDBAccountUi.Show();

        }

        private void parkingRecordToolStripMenuItem_Click (object sender, EventArgs e)
        {
            ParkingRecordUi hParkingRecordUi = new ParkingRecordUi();
            hParkingRecordUi.Show();
        }

        /// <summary>
        /// 创建默认数据库表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createDefaultTableToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CDbBaseTable hDbBaseTable = new CDbBaseTable();

            CDBAccountDb hDBAccountDb = new CDBAccountDb();
            hDBAccountDb.dataBaseBaseDeRecordInsert();

            CRegularCardUserDb hCRegularCardUserDb = new CRegularCardUserDb();
            hCRegularCardUserDb.dataBaseBaseDeRecordInsert();

            CRegularCardPaymentDb hCRegularCardPaymentDb = new CRegularCardPaymentDb();
            hCRegularCardPaymentDb.dataBaseBaseDeRecordInsert();

            MessageBox.Show( "Default Table Created" );
        }

        private void logInToolStripMenuItem_Click (object sender, EventArgs e)
        {
            DBALogInUi hDbaLogInUi = new DBALogInUi();
            hDbaLogInUi.Show();
        }

        private void regularCardToolStripMenuItem_Click (object sender, EventArgs e)
        {
            RegularCardUi hRegularCardUi = new RegularCardUi();
            hRegularCardUi.Show();
        }

        private void dBATableToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }
    }
}
