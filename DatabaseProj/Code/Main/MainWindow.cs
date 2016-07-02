using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.UI;
using DatabaseProj.Code.Database;
using DatabaseProj.UI.DBAUi;
using DatabaseProj.UI.RegularCardUserUi;
using DatabaseProj.UI.RegularCardPaymentUi;
using DatabaseProj.UI.ParkingSpaceUi;

namespace DatabaseProj.Code.Main {
    public partial class MainWindow : DevComponents.DotNetBar.Office2007Form {

        public MainWindow ()
        {
            InitializeComponent();

        }

        private void regularCardUserToolStripMenuItem_Click_1 (object sender, EventArgs e)
        {
            //RegularCardUserUi hRegularCardUserUi = new RegularCardUserUi();
            //hRegularCardUserUi.Show();
        }

        private void regularCardPaymentToolStripMenuItem_Click (object sender, EventArgs e)
        {
            //RegularCardPaymentUi hRegularCardPayment = new RegularCardPaymentUi();
            //hRegularCardPayment.Show();
        }

        private void parkingSpaceToolStripMenuItem_Click (object sender, EventArgs e)
        {
            //ParkingSpaceUi hParkingSpaceUi = new ParkingSpaceUi();
            //hParkingSpaceUi.Show();
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

            CParkingSpaceDb hParkingSpaceDb = new CParkingSpaceDb();
            hParkingSpaceDb.dataBaseBaseDeRecordInsert();

            MessageBox.Show( "Default Table Created" );
        }

        /// <summary>
        /// 数据库登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logInToolStripMenuItem_Click (object sender, EventArgs e)
        {
            DBALogInUi hDbaLogInUi = new DBALogInUi();
            hDbaLogInUi.Show();
        }

        /// <summary>
        /// 固定卡数据库界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularCardToolStripMenuItem_Click (object sender, EventArgs e)
        {
            RegularCardUi hRegularCardUi = new RegularCardUi();
            hRegularCardUi.Show();
        }

        /// <summary>
        /// 数据库管理员界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dBATableToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CDatebaseBase hDBAccountDb = new CDBAccountDb();

            DbDBAMain hDbDBAMain = new DbDBAMain( hDBAccountDb );
            hDbDBAMain.Show();
        }

        /// <summary>
        /// 固定卡用户界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularCardUserToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            CRegularCardUserDb hCRegularCardUserDb = new CRegularCardUserDb();

            RegularCardUserMain hRegularCardUserUi = new RegularCardUserMain( hCRegularCardUserDb );
            hRegularCardUserUi.Show();
        }

        /// <summary>
        /// 固定卡付款界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularCardPaymentToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            CRegularCardPaymentDb hCRegularCardPaymentDb = new CRegularCardPaymentDb();

            RegularCardPaymentMain hRegularCardPaymentMain = new RegularCardPaymentMain( hCRegularCardPaymentDb );
            hRegularCardPaymentMain.Show();
        }

        /// <summary>
        /// 停车位界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parkingSpaceToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            CParkingSpaceDb hCParkingSpaceDb = new CParkingSpaceDb();
            ParkingSpaceMain hParkingSpaceMain = new ParkingSpaceMain( hCParkingSpaceDb );
            hParkingSpaceMain.Show();
        }
    }
}
