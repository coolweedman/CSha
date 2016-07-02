using System;
using System.Collections.Generic;
using System.Text;
using DatabaseProj.UI.Base;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI.ParkingSpaceUi {
    public class ParkingSpaceQuery : DbRecordQueryBase {
        private System.Windows.Forms.ComboBox comboBoxSpaceAera;
        private System.Windows.Forms.CheckBox checkBoxSpaceAera;
        private System.Windows.Forms.ComboBox comboBoxSpaceType;
        private System.Windows.Forms.CheckBox checkBoxSpaceType;
        private System.Windows.Forms.ComboBox comboBoxLockStat;
        private System.Windows.Forms.CheckBox checkBoxId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.CheckBox checkBoxCarPlate;
        private System.Windows.Forms.CheckBox checkBoxCardNum;
        private System.Windows.Forms.CheckBox checkBoxSpaceNum;
        private System.Windows.Forms.CheckBox checkBoxGarageNum;
        private System.Windows.Forms.TextBox textBoxGarageNum;
        private System.Windows.Forms.TextBox textBoxSpaceNum;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.CheckBox checkBoxLockStat;

        protected CParkingSpaceDb.SParkingSpaceQueryStru sQueryStru;

        /// <summary>
        /// 停车位查询 构造函数
        /// </summary>
        /// <param name="hDbTableBase"></param>
        /// <param name="strTitle"></param>
        public ParkingSpaceQuery (CDatebaseBase hDbTableBase, string strTitle = "Parking Space Query Window") : base( hDbTableBase, strTitle )
        {
            InitializeComponent();
            dbRecordQueryUiInit();
        }

        /// <summary>
        /// 停车位查询 UI初始化
        /// </summary>
        protected override void dbRecordQueryUiInit ()
        {
            for ( int i=0; i< CDbBaseTable.strDbBaseParkingSpaceLockStatDesc.Length; i++ ) {
                comboBoxLockStat.Items.Add( CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[i] );
            }
            for ( int i=0; i< CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxSpaceType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }
            for ( int i=0; i< CDbBaseTable.strDbBaseParkingSpaceAeraDesc.Length; i++ ) {
                comboBoxSpaceAera.Items.Add( CDbBaseTable.strDbBaseParkingSpaceAeraDesc[i] );
            }
        }

        /// <summary>
        /// 停车位查询 UI转结构体
        /// </summary>
        /// <returns></returns>
        protected override object dbRecordQueryUi2Stru ()
        {
            sQueryStru.bIdEn = checkBoxId.Checked;
            sQueryStru.bGarageNumEn = checkBoxGarageNum.Checked;
            sQueryStru.bSpaceNumEn = checkBoxSpaceNum.Checked;
            sQueryStru.bCardNumEn = checkBoxCardNum.Checked;
            sQueryStru.bSpaceLockStatEn = checkBoxLockStat.Checked;
            sQueryStru.bSpaceTypeEn = checkBoxSpaceType.Checked;
            sQueryStru.bSpaceAeraEn = checkBoxSpaceAera.Checked;
            sQueryStru.bCarPlate = checkBoxCarPlate.Checked;

            if ( sQueryStru.bIdEn ) {
                sQueryStru.iId = int.Parse( textBoxId.Text );
            }
            if ( sQueryStru.bGarageNumEn ) {
                sQueryStru.iGarageNum = int.Parse( textBoxGarageNum.Text );
            }
            if ( sQueryStru.bSpaceNumEn ) {
                sQueryStru.iSpaceNum = int.Parse( textBoxSpaceNum.Text );
            }
            if ( sQueryStru.bCardNumEn ) {
                sQueryStru.strCardNum = textBoxCardNum.Text;
            }
            if ( sQueryStru.bSpaceLockStatEn ) {
                sQueryStru.iLockStat = comboBoxLockStat.SelectedIndex;
            }
            if ( sQueryStru.bSpaceTypeEn ) {
                sQueryStru.iSpaceType = comboBoxSpaceType.SelectedIndex;
            }
            if ( sQueryStru.bSpaceAeraEn ) {
                sQueryStru.iSpaceAera = comboBoxSpaceAera.SelectedIndex;
            }
            if ( sQueryStru.bCarPlate ) {
                sQueryStru.strCarPlate = textBoxCarPlate.Text;
            }

            return sQueryStru;
        }

        private void InitializeComponent ()
        {
            this.comboBoxSpaceAera = new System.Windows.Forms.ComboBox();
            this.checkBoxSpaceAera = new System.Windows.Forms.CheckBox();
            this.comboBoxSpaceType = new System.Windows.Forms.ComboBox();
            this.checkBoxSpaceType = new System.Windows.Forms.CheckBox();
            this.comboBoxLockStat = new System.Windows.Forms.ComboBox();
            this.checkBoxLockStat = new System.Windows.Forms.CheckBox();
            this.checkBoxId = new System.Windows.Forms.CheckBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.checkBoxCarPlate = new System.Windows.Forms.CheckBox();
            this.checkBoxCardNum = new System.Windows.Forms.CheckBox();
            this.checkBoxSpaceNum = new System.Windows.Forms.CheckBox();
            this.checkBoxGarageNum = new System.Windows.Forms.CheckBox();
            this.textBoxGarageNum = new System.Windows.Forms.TextBox();
            this.textBoxSpaceNum = new System.Windows.Forms.TextBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSpaceAera
            // 
            this.comboBoxSpaceAera.FormattingEnabled = true;
            this.comboBoxSpaceAera.Location = new System.Drawing.Point(392, 171);
            this.comboBoxSpaceAera.Name = "comboBoxSpaceAera";
            this.comboBoxSpaceAera.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceAera.TabIndex = 12;
            // 
            // checkBoxSpaceAera
            // 
            this.checkBoxSpaceAera.AutoSize = true;
            this.checkBoxSpaceAera.Location = new System.Drawing.Point(392, 126);
            this.checkBoxSpaceAera.Name = "checkBoxSpaceAera";
            this.checkBoxSpaceAera.Size = new System.Drawing.Size(106, 22);
            this.checkBoxSpaceAera.TabIndex = 11;
            this.checkBoxSpaceAera.Text = "车位分区";
            this.checkBoxSpaceAera.UseVisualStyleBackColor = true;
            // 
            // comboBoxSpaceType
            // 
            this.comboBoxSpaceType.FormattingEnabled = true;
            this.comboBoxSpaceType.Location = new System.Drawing.Point(201, 171);
            this.comboBoxSpaceType.Name = "comboBoxSpaceType";
            this.comboBoxSpaceType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceType.TabIndex = 10;
            // 
            // checkBoxSpaceType
            // 
            this.checkBoxSpaceType.AutoSize = true;
            this.checkBoxSpaceType.Location = new System.Drawing.Point(201, 126);
            this.checkBoxSpaceType.Name = "checkBoxSpaceType";
            this.checkBoxSpaceType.Size = new System.Drawing.Size(106, 22);
            this.checkBoxSpaceType.TabIndex = 9;
            this.checkBoxSpaceType.Text = "车位类型";
            this.checkBoxSpaceType.UseVisualStyleBackColor = true;
            // 
            // comboBoxLockStat
            // 
            this.comboBoxLockStat.FormattingEnabled = true;
            this.comboBoxLockStat.Location = new System.Drawing.Point(12, 171);
            this.comboBoxLockStat.Name = "comboBoxLockStat";
            this.comboBoxLockStat.Size = new System.Drawing.Size(121, 26);
            this.comboBoxLockStat.TabIndex = 8;
            // 
            // checkBoxLockStat
            // 
            this.checkBoxLockStat.AutoSize = true;
            this.checkBoxLockStat.Location = new System.Drawing.Point(12, 126);
            this.checkBoxLockStat.Name = "checkBoxLockStat";
            this.checkBoxLockStat.Size = new System.Drawing.Size(106, 22);
            this.checkBoxLockStat.TabIndex = 7;
            this.checkBoxLockStat.Text = "车位状态";
            this.checkBoxLockStat.UseVisualStyleBackColor = true;
            // 
            // checkBoxId
            // 
            this.checkBoxId.AutoSize = true;
            this.checkBoxId.Location = new System.Drawing.Point(12, 21);
            this.checkBoxId.Name = "checkBoxId";
            this.checkBoxId.Size = new System.Drawing.Size(52, 22);
            this.checkBoxId.TabIndex = 42;
            this.checkBoxId.Text = "ID";
            this.checkBoxId.UseVisualStyleBackColor = true;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(12, 63);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(127, 28);
            this.textBoxId.TabIndex = 41;
            // 
            // checkBoxCarPlate
            // 
            this.checkBoxCarPlate.AutoSize = true;
            this.checkBoxCarPlate.Location = new System.Drawing.Point(576, 126);
            this.checkBoxCarPlate.Name = "checkBoxCarPlate";
            this.checkBoxCarPlate.Size = new System.Drawing.Size(88, 22);
            this.checkBoxCarPlate.TabIndex = 43;
            this.checkBoxCarPlate.Text = "车牌号";
            this.checkBoxCarPlate.UseVisualStyleBackColor = true;
            // 
            // checkBoxCardNum
            // 
            this.checkBoxCardNum.AutoSize = true;
            this.checkBoxCardNum.Location = new System.Drawing.Point(576, 21);
            this.checkBoxCardNum.Name = "checkBoxCardNum";
            this.checkBoxCardNum.Size = new System.Drawing.Size(70, 22);
            this.checkBoxCardNum.TabIndex = 44;
            this.checkBoxCardNum.Text = "卡号";
            this.checkBoxCardNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpaceNum
            // 
            this.checkBoxSpaceNum.AutoSize = true;
            this.checkBoxSpaceNum.Location = new System.Drawing.Point(392, 21);
            this.checkBoxSpaceNum.Name = "checkBoxSpaceNum";
            this.checkBoxSpaceNum.Size = new System.Drawing.Size(88, 22);
            this.checkBoxSpaceNum.TabIndex = 45;
            this.checkBoxSpaceNum.Text = "车位号";
            this.checkBoxSpaceNum.UseVisualStyleBackColor = true;
            // 
            // checkBoxGarageNum
            // 
            this.checkBoxGarageNum.AutoSize = true;
            this.checkBoxGarageNum.Location = new System.Drawing.Point(201, 21);
            this.checkBoxGarageNum.Name = "checkBoxGarageNum";
            this.checkBoxGarageNum.Size = new System.Drawing.Size(88, 22);
            this.checkBoxGarageNum.TabIndex = 46;
            this.checkBoxGarageNum.Text = "车库号";
            this.checkBoxGarageNum.UseVisualStyleBackColor = true;
            // 
            // textBoxGarageNum
            // 
            this.textBoxGarageNum.Location = new System.Drawing.Point(201, 62);
            this.textBoxGarageNum.Name = "textBoxGarageNum";
            this.textBoxGarageNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxGarageNum.TabIndex = 47;
            // 
            // textBoxSpaceNum
            // 
            this.textBoxSpaceNum.Location = new System.Drawing.Point(392, 62);
            this.textBoxSpaceNum.Name = "textBoxSpaceNum";
            this.textBoxSpaceNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxSpaceNum.TabIndex = 48;
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(576, 61);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxCardNum.TabIndex = 49;
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(576, 168);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(100, 28);
            this.textBoxCarPlate.TabIndex = 50;
            // 
            // ParkingSpaceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(737, 667);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxSpaceNum);
            this.Controls.Add(this.textBoxGarageNum);
            this.Controls.Add(this.checkBoxGarageNum);
            this.Controls.Add(this.checkBoxSpaceNum);
            this.Controls.Add(this.checkBoxCardNum);
            this.Controls.Add(this.checkBoxCarPlate);
            this.Controls.Add(this.checkBoxId);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.comboBoxSpaceAera);
            this.Controls.Add(this.checkBoxSpaceAera);
            this.Controls.Add(this.comboBoxSpaceType);
            this.Controls.Add(this.checkBoxSpaceType);
            this.Controls.Add(this.comboBoxLockStat);
            this.Controls.Add(this.checkBoxLockStat);
            this.Name = "ParkingSpaceQuery";
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.checkBoxLockStat, 0);
            this.Controls.SetChildIndex(this.comboBoxLockStat, 0);
            this.Controls.SetChildIndex(this.checkBoxSpaceType, 0);
            this.Controls.SetChildIndex(this.comboBoxSpaceType, 0);
            this.Controls.SetChildIndex(this.checkBoxSpaceAera, 0);
            this.Controls.SetChildIndex(this.comboBoxSpaceAera, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxId, 0);
            this.Controls.SetChildIndex(this.checkBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.checkBoxCardNum, 0);
            this.Controls.SetChildIndex(this.checkBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.checkBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.textBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.textBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hDataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
