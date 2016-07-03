using DatabaseProj.Code.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace DatabaseProj.UI.Base {
    public class DbTableMainBase : DbDataShowBase {

        private DevComponents.DotNetBar.ButtonX buttonAdd;
        private DevComponents.DotNetBar.ButtonX buttonQuery;
        private DevComponents.DotNetBar.ButtonX buttonFeFlash;
        private DevComponents.DotNetBar.ButtonX buttonClose;

        protected CDatebaseBase hDbTable;
        protected DbRecordEditBase hEditUi;

        /// <summary>
        /// 数据库界面主窗口基类 构造函数
        /// </summary>
        public DbTableMainBase ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据库界面主窗口基类 带参数构造函数
        /// </summary>
        /// <param name="hDbBase"></param>
        /// <param name="strTitle"></param>
        public DbTableMainBase (CDatebaseBase hDbBase, string strTitle = "Table")
        {
            InitializeComponent();

            hDbTable = hDbBase;
            this.Text = strTitle;

            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
        }

        /// <summary>
        /// 数据库界面主窗口基类 添加记录处理
        /// </summary>
        /// <returns></returns>
        protected virtual EDbDataShowStat dbTableAddProc ()
        {
            if ( DialogResult.OK == hEditUi.ShowDialog() ) {
                object sRecord = hEditUi.dbStruGet();
                if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL != hDbTable.dataBaseBaseCommAdd( ref sRecord ) ) {
                    dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
                    return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
                } else {
                    return EDbDataShowStat.DBDATASHOW_FAILED;
                }
            } else {
                return EDbDataShowStat.DBDATASHOW_READY;
            }
        }

        /// <summary>
        /// 数据库界面主窗口基类 查询处理
        /// </summary>
        /// <returns></returns>
        protected virtual EDbDataShowStat dbTableQueryProc ()
        {
            return EDbDataShowStat.DBDATASHOW_READY;
        }

        /// <summary>
        /// 数据库界面主窗口基类 编辑记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordEditProc ()
        {
            List<string> listStr = new List<string>();

            dbDataShowDgv2StringList( listStr );
            hEditUi.dbString2Ui( ref listStr );

            if ( DialogResult.OK != hEditUi.ShowDialog() ) {
                return EDbDataShowStat.DBDATASHOW_READY;
            }

            object sRecord = hEditUi.dbStruGet();

            if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL == hDbTable.dataBaseBaseCommUpdate( ref sRecord ) ) {
                return EDbDataShowStat.DBDATASHOW_FAILED;
            } else {
                dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );

                return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
            }
        }

        /// <summary>
        /// 数据库界面主窗口基类 删除记录处理
        /// </summary>
        /// <returns></returns>
        protected override EDbDataShowStat dbRecordDeleteProc ()
        {
            List<string> listStr = new List<string>();

            dbDataShowDgv2StringList( listStr );
            hEditUi.dbString2Stru( ref listStr );

            object sRecord = hEditUi.dbStruGet();

            if ( (int)EDataBaseClassErrStat.DATABASEERR_FAIL == hDbTable.dataBaseBaseCommDelete( ref sRecord ) ) {
                return EDbDataShowStat.DBDATASHOW_FAILED;
            } else {
                dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );

                return EDbDataShowStat.DBDATASHOW_SUCCEESSED;
            }
        }

        /// <summary>
        /// 数据库界面主窗口基类 添加按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click (object sender, EventArgs e)
        {
            base.dbDataShowStatSet( dbTableAddProc() );
        }

        /// <summary>
        /// 数据库界面主窗口基类 查询按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click (object sender, EventArgs e)
        {
            base.dbDataShowStatSet( dbTableQueryProc() );
        }

        /// <summary>
        /// 数据库界面主窗口基类 刷新按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFeFlash_Click (object sender, EventArgs e)
        {
            dbDataShowReFlash( hDbTable.dataBaseBaseCommRead() );
            base.dbDataShowStatSet( EDbDataShowStat.DBDATASHOW_SUCCEESSED );
        }

        /// <summary>
        /// 数据库界面主窗口基类 取消按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click (object sender, EventArgs e)
        {
            this.Close();
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
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAdd.Location = new System.Drawing.Point(76, 476);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(108, 36);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "添加";
            //this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonQuery.Location = new System.Drawing.Point(257, 476);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(105, 36);
            this.buttonQuery.TabIndex = 4;
            this.buttonQuery.Text = "查询";
            //this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // buttonFeFlash
            // 
            this.buttonFeFlash.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFeFlash.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonFeFlash.Location = new System.Drawing.Point(452, 476);
            this.buttonFeFlash.Name = "buttonFeFlash";
            this.buttonFeFlash.Size = new System.Drawing.Size(102, 36);
            this.buttonFeFlash.TabIndex = 5;
            this.buttonFeFlash.Text = "刷新";
            //this.buttonFeFlash.UseVisualStyleBackColor = true;
            this.buttonFeFlash.Click += new System.EventHandler(this.buttonFeFlash_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(643, 476);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(96, 36);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "关闭";
            //this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // DbTableMainBase
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(815, 571);
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
    }
}
