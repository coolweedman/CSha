using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;
using System.Windows.Forms;

namespace DatabaseProj.UI.DBAUi {
    public class DbDBAMain : DbTableMainBase {
        private DevComponents.DotNetBar.ButtonX buttonAdd;
        private DevComponents.DotNetBar.ButtonX buttonQuery;
        private DevComponents.DotNetBar.ButtonX buttonFeFlash;
        private DevComponents.DotNetBar.ButtonX buttonClose;

        /// <summary>
        /// 构造函数 待参数
        /// </summary>
        /// <param name="hDbBase"></param>
        /// <param name="strTitle"></param>
        public DbDBAMain (CDatebaseBase hDbBase, string strTitle = "DBA Main Window") : base( hDbBase, strTitle )
        {
            dbDataShowHeadSet( CDBAccountDb.strDBAccountHeadDesc );
        }

        /// <summary>
        /// 构造函数 为UI设计添加
        /// </summary>
        public DbDBAMain () : base(null)
        {
        }

        /// <summary>
        /// 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableAddProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbTableAddProc();
        }

        /// <summary>
        /// 编辑处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbRecordEditProc();
        }

        /// <summary>
        /// 删除处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            hEditUi = new DbDBAEdit();

            return base.dbRecordDeleteProc();
        }

        /// <summary>
        /// 查询处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbTableQueryProc ()
        {
            DbDBAQuery hDbDBAQuery = new DbDBAQuery( hDbTable );
            hDbDBAQuery.ShowDialog();

            return EDbDataShowStat.DBDATASHOW_READY;
        }

        private new void InitializeComponent ()
        {
            this.buttonAdd = new DevComponents.DotNetBar.ButtonX();
            this.buttonQuery = new DevComponents.DotNetBar.ButtonX();
            this.buttonFeFlash = new DevComponents.DotNetBar.ButtonX();
            this.buttonClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.Location = new System.Drawing.Point( 76, 521 );
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size( 108, 36 );
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "添加";
            // 
            // buttonQuery
            // 
            this.buttonQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonQuery.Location = new System.Drawing.Point( 341, 521 );
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size( 105, 36 );
            this.buttonQuery.TabIndex = 4;
            this.buttonQuery.Text = "查询";
            // 
            // buttonFeFlash
            // 
            this.buttonFeFlash.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFeFlash.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFeFlash.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonFeFlash.Location = new System.Drawing.Point( 536, 521 );
            this.buttonFeFlash.Name = "buttonFeFlash";
            this.buttonFeFlash.Size = new System.Drawing.Size( 102, 36 );
            this.buttonFeFlash.TabIndex = 5;
            this.buttonFeFlash.Text = "刷新";
            // 
            // buttonClose
            // 
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point( 811, 521 );
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size( 96, 36 );
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "关闭";
            // 
            // DbDBAMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 9F, 18F );
            this.ClientSize = new System.Drawing.Size( 983, 616 );
            this.Name = "DbDBAMain";
            this.Controls.SetChildIndex( this.buttonAdd, 0 );
            this.Controls.SetChildIndex( this.buttonQuery, 0 );
            this.Controls.SetChildIndex( this.buttonFeFlash, 0 );
            this.Controls.SetChildIndex( this.buttonClose, 0 );
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
    }
}
