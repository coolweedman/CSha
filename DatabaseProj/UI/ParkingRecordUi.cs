using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.Code.Database;
using System.Data;

namespace DatabaseProj.UI {
    public class ParkingRecordUi : DbWinBase {
        private DevComponents.DotNetBar.ButtonX buttonAdd;

        public ParkingRecordUi ()
        {
            hDatabaseBase = new CParkingRecordDb();
            hDataTable = new DataTable();

            dbDgvReFlash();
        }

        private void InitializeComponent ()
        {
            this.buttonAdd = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.Location = new System.Drawing.Point(74, 332);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 35);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "添加";
            // 
            // ParkingRecordUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(998, 457);
            this.Name = "ParkingRecordUi";
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.buttonReFlash, 0);
            this.Controls.SetChildIndex(this.buttonClose, 0);
            this.Controls.SetChildIndex(this.buttonQuery, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
