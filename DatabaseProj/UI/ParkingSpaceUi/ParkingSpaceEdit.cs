using DatabaseProj.Code.Comm;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using DatabaseProj.UI.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DatabaseProj.UI.ParkingSpaceUi {

    public class ParkingSpaceEdit : DbRecordEditBase {
        private System.Windows.Forms.TextBox textBoxPicPath;
        private System.Windows.Forms.TextBox textBoxCarPlate;
        private System.Windows.Forms.TextBox textBoxAttr3;
        private System.Windows.Forms.TextBox textBoxAttr2;
        private System.Windows.Forms.TextBox textBoxAttr1;
        private System.Windows.Forms.ComboBox comboBoxSpaceAera;
        private System.Windows.Forms.ComboBox comboBoxSpacePosi;
        private System.Windows.Forms.ComboBox comboBoxSpaceType;
        private System.Windows.Forms.ComboBox comboBoxLockStat;
        private System.Windows.Forms.TextBox textBoxRearrange2;
        private System.Windows.Forms.TextBox textBoxRearrange1;
        private System.Windows.Forms.TextBox textBoxAxisY;
        private System.Windows.Forms.TextBox textBoxAxisX;
        private System.Windows.Forms.TextBox textBoxCardNum;
        private System.Windows.Forms.TextBox textBoxSpaceNum;
        private System.Windows.Forms.TextBox textBoxGarageNum;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public CParkingSpaceDb.SParkingSpaceStru sPsStru;

        /// <summary>
        /// 停车位编辑界面 构造函数
        /// </summary>
        /// <param name="strTitle"></param>
        public ParkingSpaceEdit (string strTitle = "Parking Space Edit") : base( strTitle )
        {
            InitializeComponent();
            dbUiInit();
        }

        /// <summary>
        /// 停车位编辑界面 UI初始化
        /// </summary>
        public override void dbUiInit ()
        {
            int i;

            for ( i = 0; i < CDbBaseTable.strDbBaseParkingSpaceLockStatDesc.Length; i++ ) {
                comboBoxLockStat.Items.Add( CDbBaseTable.strDbBaseParkingSpaceLockStatDesc[i] );
            }
            for ( i = 0; i < CDbBaseTable.strDbBaseParkingCarTypeDesc.Length; i++ ) {
                comboBoxSpaceType.Items.Add( CDbBaseTable.strDbBaseParkingCarTypeDesc[i] );
            }
            for ( i = 0; i < CDbBaseTable.strDbBaseParkingSpacePosiDesc.Length; i++ ) {
                comboBoxSpacePosi.Items.Add( CDbBaseTable.strDbBaseParkingSpacePosiDesc[i] );
            }
            for ( i = 0; i < CDbBaseTable.strDbBaseParkingSpaceAeraDesc.Length; i++ ) {
                comboBoxSpaceAera.Items.Add( CDbBaseTable.strDbBaseParkingSpaceAeraDesc[i] );
            }

            textBoxId.Text = "0";
            textBoxId.Enabled = false;
            textBoxRearrange1.Text = "0";
            textBoxRearrange2.Text = "0";
            textBoxAttr1.Text = "null";
            textBoxAttr2.Text = "null";
            textBoxAttr3.Text = "null";
            textBoxCarPlate.Text = "null";
            textBoxPicPath.Text = "null";

            comboBoxLockStat.SelectedIndex = (int)CParkingSpaceDb.EPsLockStat.PARKINGSPACE_LOCKSTATIDLE;
            comboBoxSpaceType.SelectedIndex = (int)CParkingSpaceDb.EPsCarType.PARKINGSPACE_CARTYPESMALL;
            comboBoxSpacePosi.SelectedIndex = (int)CParkingSpaceDb.EPsSpacePosi.PARKINGSPACE_POSIFORWARD;
            comboBoxSpaceAera.SelectedIndex = (int)CParkingSpaceDb.EPsSpaceAera.PARKINGSPACE_AREAA;
        }

        /// <summary>
        /// 停车位编辑界面 字符串转结构体
        /// </summary>
        /// <param name="listRecord"></param>
        public override void dbString2Stru (ref List<string> listRecord)
        {
            int i = 0;

            try {
                sPsStru.iId = int.Parse( listRecord[i++] );
                sPsStru.iGarageNum = int.Parse( listRecord[i++] );
                sPsStru.iSpaceNum = int.Parse( listRecord[i++] );
                sPsStru.strCardNum = listRecord[i++];
                sPsStru.dAxisX = double.Parse( listRecord[i++] );
                sPsStru.dAxisY = double.Parse( listRecord[i++] );
                sPsStru.iRearrange1 = int.Parse( listRecord[i++] );
                sPsStru.iRearrange2 = int.Parse( listRecord[i++] );
                sPsStru.iLockStat = CDbBaseTable.dicDbBaseParkingSpaceLockStatDesc[listRecord[i++]];
                sPsStru.iSpaceType = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
                sPsStru.iSpacePosi = CDbBaseTable.dicDbBaseParkingSpacePosiDesc[listRecord[i++]];
                sPsStru.iSpaceAera = CDbBaseTable.dicDbBaseParkingSpaceAeraDesc[listRecord[i++]];
                sPsStru.strAttr1 = listRecord[i++];
                sPsStru.strAttr2 = listRecord[i++];
                sPsStru.strAttr3 = listRecord[i++];
                sPsStru.strCardNum = listRecord[i++];
                sPsStru.strPicPath = listRecord[i++];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 停车位编辑界面 字符串转UI
        /// </summary>
        /// <param name="listRecord"></param>
        public override void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            try {
                textBoxId.Text = listRecord[i++];
                textBoxGarageNum.Text = listRecord[i++];
                textBoxSpaceNum.Text = listRecord[i++];
                textBoxCardNum.Text = listRecord[i++];
                textBoxAxisX.Text = listRecord[i++];
                textBoxAxisY.Text = listRecord[i++];
                textBoxRearrange1.Text = listRecord[i++];
                textBoxRearrange2.Text = listRecord[i++];
                comboBoxLockStat.SelectedIndex = CDbBaseTable.dicDbBaseParkingSpaceLockStatDesc[listRecord[i++]];
                comboBoxSpaceType.SelectedIndex = CDbBaseTable.dicDbBaseParkingCarTypeDesc[listRecord[i++]];
                comboBoxSpacePosi.SelectedIndex = CDbBaseTable.dicDbBaseParkingSpacePosiDesc[listRecord[i++]];
                comboBoxSpaceAera.SelectedIndex = CDbBaseTable.dicDbBaseParkingSpaceAeraDesc[listRecord[i++]];
                textBoxAttr1.Text = listRecord[i++];
                textBoxAttr2.Text = listRecord[i++];
                textBoxAttr3.Text = listRecord[i++];
                textBoxCarPlate.Text = listRecord[i++];
                textBoxPicPath.Text = listRecord[i++];
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 停车位编辑界面 结构体转UI
        /// </summary>
        public override void dbStru2Ui ()
        {
            try {
                textBoxId.Text = sPsStru.iId.ToString();
                textBoxGarageNum.Text = sPsStru.iGarageNum.ToString();
                textBoxSpaceNum.Text = sPsStru.iSpaceNum.ToString();
                textBoxCardNum.Text = sPsStru.strCardNum; ;
                textBoxAxisX.Text = sPsStru.dAxisX.ToString();
                textBoxAxisY.Text = sPsStru.dAxisY.ToString();
                textBoxRearrange1.Text = sPsStru.iRearrange1.ToString();
                textBoxRearrange2.Text = sPsStru.iRearrange2.ToString();
                comboBoxLockStat.SelectedIndex = sPsStru.iLockStat;
                comboBoxSpaceType.SelectedIndex = sPsStru.iSpaceType;
                comboBoxSpacePosi.SelectedIndex = sPsStru.iSpacePosi;
                comboBoxSpaceAera.SelectedIndex = sPsStru.iSpaceAera;
                textBoxAttr1.Text = sPsStru.strAttr1;
                textBoxAttr2.Text = sPsStru.strAttr2;
                textBoxAttr3.Text = sPsStru.strAttr3;
                textBoxCarPlate.Text = sPsStru.strCarPlate;
                textBoxPicPath.Text = sPsStru.strPicPath;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbStru2Ui..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 停车位编辑界面 结构体获取
        /// </summary>
        /// <returns></returns>
        public override object dbStruGet ()
        {
            return sPsStru;
        }

        /// <summary>
        /// 停车位编辑界面 UI转结构体
        /// </summary>
        public override void dbUi2Stru ()
        {
            try {
                sPsStru.iId = int.Parse( textBoxId.Text );
                sPsStru.iGarageNum = int.Parse( textBoxGarageNum.Text );
                sPsStru.iSpaceNum = int.Parse( textBoxSpaceNum.Text );
                sPsStru.strCardNum = textBoxCardNum.Text;
                sPsStru.dAxisX = double.Parse( textBoxAxisX.Text );
                sPsStru.dAxisY = double.Parse( textBoxAxisY.Text );
                sPsStru.iRearrange1 = int.Parse( textBoxRearrange1.Text );
                sPsStru.iRearrange2 = int.Parse( textBoxRearrange2.Text );
                sPsStru.iLockStat = comboBoxLockStat.SelectedIndex;
                sPsStru.iSpaceType = comboBoxSpaceType.SelectedIndex;
                sPsStru.iSpacePosi = comboBoxSpacePosi.SelectedIndex;
                sPsStru.iSpaceAera = comboBoxSpaceAera.SelectedIndex;
                sPsStru.strAttr1 = textBoxAttr1.Text;
                sPsStru.strAttr2 = textBoxAttr2.Text;
                sPsStru.strAttr3 = textBoxAttr3.Text;
                sPsStru.strCarPlate = textBoxCarPlate.Text;
                sPsStru.strPicPath = textBoxPicPath.Text;
            } catch ( Exception ex ) {
                CDebugPrint.dbgUserMsgPrint( "dbString2Stru..." );
                CDebugPrint.dbgMehtorMsgPrint( new StackTrace( new StackFrame( true ) ) );
                CDebugPrint.dbgExpectionMsgPrint( ex );
            }
        }

        /// <summary>
        /// 停车位编辑界面 输入检查
        /// </summary>
        /// <returns></returns>
        public override EDbEditUiStat dbUiStatChk ()
        {
            if ( "" == textBoxGarageNum.Text ) {
                textBoxGarageNum.Select();
                dbUiStatSet( "车库号未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxSpaceNum.Text ) {
                textBoxSpaceNum.Select();
                dbUiStatSet( "车位号未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxCardNum.Text ) {
                textBoxCardNum.Select();
                dbUiStatSet( "卡号未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxAxisX.Text ) {
                textBoxAxisX.Select();
                dbUiStatSet( "X轴未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }
            if ( "" == textBoxAxisY.Text ) {
                textBoxAxisY.Select();
                dbUiStatSet( "Y轴未输入..." );
                return EDbEditUiStat.DBEDITUISTAT_FAIL;
            }

            return EDbEditUiStat.DBEDITUISTAT_OK;
        }

        private new void InitializeComponent ()
        {
            this.textBoxPicPath = new System.Windows.Forms.TextBox();
            this.textBoxCarPlate = new System.Windows.Forms.TextBox();
            this.textBoxAttr3 = new System.Windows.Forms.TextBox();
            this.textBoxAttr2 = new System.Windows.Forms.TextBox();
            this.textBoxAttr1 = new System.Windows.Forms.TextBox();
            this.comboBoxSpaceAera = new System.Windows.Forms.ComboBox();
            this.comboBoxSpacePosi = new System.Windows.Forms.ComboBox();
            this.comboBoxSpaceType = new System.Windows.Forms.ComboBox();
            this.comboBoxLockStat = new System.Windows.Forms.ComboBox();
            this.textBoxRearrange2 = new System.Windows.Forms.TextBox();
            this.textBoxRearrange1 = new System.Windows.Forms.TextBox();
            this.textBoxAxisY = new System.Windows.Forms.TextBox();
            this.textBoxAxisX = new System.Windows.Forms.TextBox();
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.textBoxSpaceNum = new System.Windows.Forms.TextBox();
            this.textBoxGarageNum = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(429, 529);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 38);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            // 
            // buttonOk
            // 
            this.buttonOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonOk.Location = new System.Drawing.Point(228, 529);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(81, 38);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            // 
            // textBoxPicPath
            // 
            this.textBoxPicPath.Location = new System.Drawing.Point(29, 470);
            this.textBoxPicPath.Name = "textBoxPicPath";
            this.textBoxPicPath.Size = new System.Drawing.Size(280, 28);
            this.textBoxPicPath.TabIndex = 67;
            // 
            // textBoxCarPlate
            // 
            this.textBoxCarPlate.Location = new System.Drawing.Point(557, 361);
            this.textBoxCarPlate.Name = "textBoxCarPlate";
            this.textBoxCarPlate.Size = new System.Drawing.Size(100, 28);
            this.textBoxCarPlate.TabIndex = 66;
            // 
            // textBoxAttr3
            // 
            this.textBoxAttr3.Location = new System.Drawing.Point(395, 361);
            this.textBoxAttr3.Name = "textBoxAttr3";
            this.textBoxAttr3.Size = new System.Drawing.Size(100, 28);
            this.textBoxAttr3.TabIndex = 65;
            // 
            // textBoxAttr2
            // 
            this.textBoxAttr2.Location = new System.Drawing.Point(209, 360);
            this.textBoxAttr2.Name = "textBoxAttr2";
            this.textBoxAttr2.Size = new System.Drawing.Size(100, 28);
            this.textBoxAttr2.TabIndex = 64;
            // 
            // textBoxAttr1
            // 
            this.textBoxAttr1.Location = new System.Drawing.Point(29, 361);
            this.textBoxAttr1.Name = "textBoxAttr1";
            this.textBoxAttr1.Size = new System.Drawing.Size(100, 28);
            this.textBoxAttr1.TabIndex = 63;
            // 
            // comboBoxSpaceAera
            // 
            this.comboBoxSpaceAera.FormattingEnabled = true;
            this.comboBoxSpaceAera.Location = new System.Drawing.Point(557, 253);
            this.comboBoxSpaceAera.Name = "comboBoxSpaceAera";
            this.comboBoxSpaceAera.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceAera.TabIndex = 62;
            // 
            // comboBoxSpacePosi
            // 
            this.comboBoxSpacePosi.FormattingEnabled = true;
            this.comboBoxSpacePosi.Location = new System.Drawing.Point(395, 254);
            this.comboBoxSpacePosi.Name = "comboBoxSpacePosi";
            this.comboBoxSpacePosi.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpacePosi.TabIndex = 61;
            // 
            // comboBoxSpaceType
            // 
            this.comboBoxSpaceType.FormattingEnabled = true;
            this.comboBoxSpaceType.Location = new System.Drawing.Point(209, 254);
            this.comboBoxSpaceType.Name = "comboBoxSpaceType";
            this.comboBoxSpaceType.Size = new System.Drawing.Size(121, 26);
            this.comboBoxSpaceType.TabIndex = 60;
            // 
            // comboBoxLockStat
            // 
            this.comboBoxLockStat.FormattingEnabled = true;
            this.comboBoxLockStat.Location = new System.Drawing.Point(29, 254);
            this.comboBoxLockStat.Name = "comboBoxLockStat";
            this.comboBoxLockStat.Size = new System.Drawing.Size(121, 26);
            this.comboBoxLockStat.TabIndex = 59;
            // 
            // textBoxRearrange2
            // 
            this.textBoxRearrange2.Location = new System.Drawing.Point(557, 163);
            this.textBoxRearrange2.Name = "textBoxRearrange2";
            this.textBoxRearrange2.Size = new System.Drawing.Size(100, 28);
            this.textBoxRearrange2.TabIndex = 58;
            this.textBoxRearrange2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRearrange2_KeyPress);
            // 
            // textBoxRearrange1
            // 
            this.textBoxRearrange1.Location = new System.Drawing.Point(395, 162);
            this.textBoxRearrange1.Name = "textBoxRearrange1";
            this.textBoxRearrange1.Size = new System.Drawing.Size(100, 28);
            this.textBoxRearrange1.TabIndex = 57;
            this.textBoxRearrange1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRearrange1_KeyPress);
            // 
            // textBoxAxisY
            // 
            this.textBoxAxisY.Location = new System.Drawing.Point(209, 163);
            this.textBoxAxisY.Name = "textBoxAxisY";
            this.textBoxAxisY.Size = new System.Drawing.Size(100, 28);
            this.textBoxAxisY.TabIndex = 56;
            this.textBoxAxisY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAxisY_KeyPress);
            // 
            // textBoxAxisX
            // 
            this.textBoxAxisX.Location = new System.Drawing.Point(29, 163);
            this.textBoxAxisX.Name = "textBoxAxisX";
            this.textBoxAxisX.Size = new System.Drawing.Size(100, 28);
            this.textBoxAxisX.TabIndex = 55;
            this.textBoxAxisX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAxisX_KeyPress);
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(557, 63);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxCardNum.TabIndex = 54;
            this.textBoxCardNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCardNum_KeyPress);
            // 
            // textBoxSpaceNum
            // 
            this.textBoxSpaceNum.Location = new System.Drawing.Point(395, 63);
            this.textBoxSpaceNum.Name = "textBoxSpaceNum";
            this.textBoxSpaceNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxSpaceNum.TabIndex = 53;
            this.textBoxSpaceNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSpaceNum_KeyPress);
            // 
            // textBoxGarageNum
            // 
            this.textBoxGarageNum.Location = new System.Drawing.Point(209, 63);
            this.textBoxGarageNum.Name = "textBoxGarageNum";
            this.textBoxGarageNum.Size = new System.Drawing.Size(100, 28);
            this.textBoxGarageNum.TabIndex = 52;
            this.textBoxGarageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGarageNum_KeyPress);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(27, 64);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 28);
            this.textBoxId.TabIndex = 51;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 434);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 18);
            this.label17.TabIndex = 50;
            this.label17.Text = "车辆图片路径";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(554, 318);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 18);
            this.label16.TabIndex = 49;
            this.label16.Text = "车牌";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(392, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 48;
            this.label15.Text = "车位属性3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(206, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 18);
            this.label14.TabIndex = 47;
            this.label14.Text = "车位属性2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 18);
            this.label13.TabIndex = 46;
            this.label13.Text = "车位属性1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(554, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 45;
            this.label12.Text = "车位分区";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(392, 221);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 44;
            this.label11.Text = "车位位置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 43;
            this.label10.Text = "车位类型";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 42;
            this.label9.Text = "状态";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(554, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "重列车位2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 18);
            this.label7.TabIndex = 40;
            this.label7.Text = "重列车位1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 39;
            this.label6.Text = "垂直位置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 38;
            this.label5.Text = "水平位置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "卡号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "车位号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "车库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "ID";
            // 
            // ParkingSpaceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.textBoxPicPath);
            this.Controls.Add(this.textBoxCarPlate);
            this.Controls.Add(this.textBoxAttr3);
            this.Controls.Add(this.textBoxAttr2);
            this.Controls.Add(this.textBoxAttr1);
            this.Controls.Add(this.comboBoxSpaceAera);
            this.Controls.Add(this.comboBoxSpacePosi);
            this.Controls.Add(this.comboBoxSpaceType);
            this.Controls.Add(this.comboBoxLockStat);
            this.Controls.Add(this.textBoxRearrange2);
            this.Controls.Add(this.textBoxRearrange1);
            this.Controls.Add(this.textBoxAxisY);
            this.Controls.Add(this.textBoxAxisX);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.textBoxSpaceNum);
            this.Controls.Add(this.textBoxGarageNum);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ParkingSpaceEdit";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.textBoxId, 0);
            this.Controls.SetChildIndex(this.textBoxGarageNum, 0);
            this.Controls.SetChildIndex(this.textBoxSpaceNum, 0);
            this.Controls.SetChildIndex(this.textBoxCardNum, 0);
            this.Controls.SetChildIndex(this.textBoxAxisX, 0);
            this.Controls.SetChildIndex(this.textBoxAxisY, 0);
            this.Controls.SetChildIndex(this.textBoxRearrange1, 0);
            this.Controls.SetChildIndex(this.textBoxRearrange2, 0);
            this.Controls.SetChildIndex(this.comboBoxLockStat, 0);
            this.Controls.SetChildIndex(this.comboBoxSpaceType, 0);
            this.Controls.SetChildIndex(this.comboBoxSpacePosi, 0);
            this.Controls.SetChildIndex(this.comboBoxSpaceAera, 0);
            this.Controls.SetChildIndex(this.textBoxAttr1, 0);
            this.Controls.SetChildIndex(this.textBoxAttr2, 0);
            this.Controls.SetChildIndex(this.textBoxAttr3, 0);
            this.Controls.SetChildIndex(this.textBoxCarPlate, 0);
            this.Controls.SetChildIndex(this.textBoxPicPath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxGarageNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxSpaceNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxCardNum_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxAxisX_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxAxisY_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxRearrange1_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }

        private void textBoxRearrange2_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            CInputLimit.textBoxNumLimitProc( ref sender, ref e );
        }
    }
}
