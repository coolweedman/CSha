using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.UI;

namespace DatabaseProj.Code.Main {
    public partial class MainWindow : Form {

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
    }
}
