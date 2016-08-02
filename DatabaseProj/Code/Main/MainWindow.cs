using System;
using System.Windows.Forms;
using DatabaseProj.UI;
using DatabaseProj.Code.Database;
using DatabaseProj.UI.DBAUi;
using DatabaseProj.UI.RegularCardUserUi;
using DatabaseProj.UI.RegularCardPaymentUi;
using DatabaseProj.UI.ParkingSpaceUi;
using DatabaseProj.UI.ParkingRecordUi;
using DatabaseProj.UI.RegularCardViewUi;
using DatabaseProj.UI.FaultRecord;
using DatabaseProj.Code.App;

namespace DatabaseProj.Code.Main {
    public partial class MainWindow : DevComponents.DotNetBar.Office2007Form {

        public MainWindow ()
        {
            InitializeComponent();

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

        /// <summary>
        /// 停车记录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parkingRecordToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            CParkingRecordDb hParkingRecordDb = new CParkingRecordDb();
            ParkingRecordMain hParkingRecordMain = new ParkingRecordMain( hParkingRecordDb  );
            hParkingRecordMain.Show();
        }

        private void buttonClose_Click (object sender, EventArgs e)
        {
            Close();
        }

        private void regularCardToolStripMenuItem1_Click (object sender, EventArgs e)
        {
            CRegularCardView hRegularCardView = new CRegularCardView();
            RegularCardViewQuery hRegularCardViewQuery = new RegularCardViewQuery( hRegularCardView  );
            hRegularCardViewQuery.Show();
        }

        private void faultRecordToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CFaultRecordDb hFaultRecordDb = new CFaultRecordDb();
            FaultRecordMain hFaultRecordMain = new FaultRecordMain( hFaultRecordDb );
            hFaultRecordMain.Show();
        }

        private void 用户登录ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            DBALogInMain hDbaLogInUi = new DBALogInMain();
            hDbaLogInUi.Show();
        }

        private void 创建默认表ToolStripMenuItem_Click (object sender, EventArgs e)
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

            CParkingRecordDb hParkingRecordDb = new CParkingRecordDb();
            hParkingRecordDb.dataBaseBaseDeRecordInsert();

            CRegularCardView hRegularCardView = new CRegularCardView();
            hRegularCardView.rcvViewCreate();

            CFaultRecordDb hFaultRecordDb = new CFaultRecordDb();
            hFaultRecordDb.dataBaseBaseDeRecordInsert();

            MessageBox.Show( "Default Table Created" );
        }

        private void 退出系统ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void 出入库查询ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CParkingRecordDb hParkingRecordDb = new CParkingRecordDb();
            ParkingRecordMain hParkingRecordMain = new ParkingRecordMain( hParkingRecordDb );
            hParkingRecordMain.Show();
        }

        private void tableToolStripMenuItem_Click (object sender, EventArgs e)
        {

        }

        private void 计费查询ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CParkingRecordDb hParkingRecordDb = new CParkingRecordDb();
            ParkingRecordMain hParkingRecordMain = new ParkingRecordMain( hParkingRecordDb );
            hParkingRecordMain.Show();
        }

        private void 管理员编辑ToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CDatebaseBase hDBAccountDb = new CDBAccountDb();

            DbDBAMain hDbDBAMain = new DbDBAMain( hDBAccountDb );
            hDbDBAMain.Show();
        }

        private void excelTestToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CDataTable2Excel hExcel = new CDataTable2Excel();
            hExcel.excelCreate();
        }
    }
}
