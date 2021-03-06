﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseProj.UI.Base {
    public partial class DbRecordEditBase : DevComponents.DotNetBar.Office2007Form {

        public enum EDbEditUiStat {
            DBEDITUISTAT_OK = 0,
            DBEDITUISTAT_FAIL,
        };

        public DbDataShowBase.EDbDataShowStat eCloseStat = DbDataShowBase.EDbDataShowStat.DBDATASHOW_READY;

        /// <summary>
        /// 数据库编辑窗口基类 构造函数
        /// </summary>
        /// <param name="strTitle"></param>
        public DbRecordEditBase (string strTitle = "DbRecordEditBase")
        {
            InitializeComponent();

            this.Text = strTitle;
        }

        /// <summary>
        /// 数据库编辑窗口基类 不带参数构造函数
        /// </summary>
        public DbRecordEditBase ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据库编辑窗口基类 字符串转结构体
        /// </summary>
        /// <param name="listRecord"></param>
        public virtual void dbString2Stru (ref List<string> listRecord)
        {
        }

        /// <summary>
        /// 数据库编辑窗口基类 字符串转UI
        /// </summary>
        /// <param name="listRecord"></param>
        public virtual void dbString2Ui (ref List<string> listRecord)
        {
        }

        /// <summary>
        /// 数据库编辑窗口基类 结构体转UI
        /// </summary>
        public virtual void dbStru2Ui ()
        {
        }

        /// <summary>
        /// 数据库编辑窗口基类 结构体获取
        /// </summary>
        /// <returns></returns>
        public virtual object dbStruGet ()
        {
            return null;
        }

        /// <summary>
        /// 数据库编辑窗口基类 UI转结构体
        /// </summary>
        public virtual void dbUi2Stru ()
        {
        }

        /// <summary>
        /// 数据库编辑窗口基类 UI初始化
        /// </summary>
        public virtual void dbUiInit ()
        {
        }

        /// <summary>
        /// 数据库编辑窗口基类 检查UI状态
        /// </summary>
        /// <returns></returns>
        public virtual EDbEditUiStat dbUiStatChk ()
        {
            return EDbEditUiStat.DBEDITUISTAT_OK;
        }

        /// <summary>
        /// 数据库编辑窗口基类 设置状态栏
        /// </summary>
        /// <param name="strStat"></param>
        public void dbUiStatSet (string strStat = "Ready")
        {
            toolStripStatusLabel.Text = strStat;
        }

        /// <summary>
        /// 数据库编辑窗口基类 OK按键处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonOk_Click (object sender, EventArgs e)
        {
            if ( EDbEditUiStat.DBEDITUISTAT_OK != dbUiStatChk() ) {
                return;
            }

            dbUi2Stru();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 数据库编辑窗口基类 Cancel按键处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonCancel_Click (object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
