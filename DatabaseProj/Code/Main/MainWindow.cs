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
    public partial class MainWindow : Form {

        public MainWindow ()
        {
            InitializeComponent();

            CDbBaseTable hDbBaseTable = new CDbBaseTable();
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
    }
}
