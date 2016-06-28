using DatabaseProj.Code.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.UI.Base {
    public class DbTableMainBase : DbDataShowBase {

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Button buttonFeFlash;
        private System.Windows.Forms.Button buttonClose;

        protected CDatebaseBase hDbTable;

        public DbTableMainBase ()
        {
            InitializeComponent();
        }

        public DbTableMainBase (CDatebaseBase hDbBase, string strTitle = "Table")
        {
            InitializeComponent();

            hDbTable = hDbBase;
            this.Text = strTitle;
        }

        protected virtual EDbDataShowStat dbTableAddProc ()
        {
            return EDbDataShowStat.DBDATASHOW_READY;
        }

        protected virtual EDbDataShowStat dbTableQueryProc ()
        {
            return EDbDataShowStat.DBDATASHOW_READY;
        }

        private new void InitializeComponent ()
        {
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.buttonFeFlash = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.Location = new System.Drawing.Point(76, 476);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(108, 36);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonQuery.Location = new System.Drawing.Point(286, 476);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(105, 36);
            this.buttonQuery.TabIndex = 4;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonFeFlash
            // 
            this.buttonFeFlash.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFeFlash.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonFeFlash.Location = new System.Drawing.Point(469, 476);
            this.buttonFeFlash.Name = "buttonFeFlash";
            this.buttonFeFlash.Size = new System.Drawing.Size(102, 36);
            this.buttonFeFlash.TabIndex = 5;
            this.buttonFeFlash.Text = "刷新";
            this.buttonFeFlash.UseVisualStyleBackColor = true;
            this.buttonFeFlash.Click += new System.EventHandler(this.buttonFeFlash_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(676, 476);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(96, 36);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DbTableMainBase
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(848, 571);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonFeFlash);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.buttonAdd);
            this.Name = "DbTableMainBase";
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.buttonQuery, 0);
            this.Controls.SetChildIndex(this.buttonFeFlash, 0);
            this.Controls.SetChildIndex(this.buttonClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonAdd_Click (object sender, EventArgs e)
        {
            base.dbDataShowStatSet( dbTableAddProc() );
        }

        private void buttonQuery_Click (object sender, EventArgs e)
        {
            base.dbDataShowStatSet( dbTableQueryProc() );
        }

        private void buttonFeFlash_Click (object sender, EventArgs e)
        {
            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
            base.dbDataShowStatSet( EDbDataShowStat.DBDATASHOW_SUCCEESSED );
        }

        private void buttonClose_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
