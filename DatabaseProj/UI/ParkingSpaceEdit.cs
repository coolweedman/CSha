using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatabaseProj.Code.Database;
using DatabaseProj.Code.Debug;
using System.Diagnostics;


namespace DatabaseProj.UI {
    public partial class ParkingSpaceEdit : Form, DbEditWinIf {

        public CParkingSpaceDb.SParkingSpaceStru sPsStru;
        public DialogResult eDialogResult = DialogResult.OK;

        public ParkingSpaceEdit ()
        {
            InitializeComponent();
            dbUiInit();
        }

        public DialogResult dbFinishStatGet ()
        {
            return eDialogResult;
        }

        public void dbString2Stru (ref List<string> listRecord)
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
                sPsStru.iLockStat = CParkingSpaceDb.dicPsLockStat2Enum[listRecord[i++]];
                sPsStru.iSpaceType = CParkingSpaceDb.dicPsCarType2Enum[listRecord[i++]];
                sPsStru.iSpacePosi = CParkingSpaceDb.dicPsSpacePosi2Enum[listRecord[i++]];
                sPsStru.iSpaceAera = CParkingSpaceDb.dicPsSpaceAera2Enum[listRecord[i++]];
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

        public void dbString2Ui (ref List<string> listRecord)
        {
            int i = 0;

            textBoxId.Text = listRecord[i++];
            textBoxGarageNum.Text = listRecord[i++];
            textBoxSpaceNum.Text = listRecord[i++];
            textBoxCardNum.Text = listRecord[i++];
            textBoxAxisX.Text = listRecord[i++];
            textBoxAxisY.Text = listRecord[i++];
            textBoxRearrange1.Text = listRecord[i++];
            textBoxRearrange2.Text = listRecord[i++];
            comboBoxLockStat.SelectedIndex = CParkingSpaceDb.dicPsLockStat2Enum[listRecord[i++]];
            comboBoxSpaceType.SelectedIndex = CParkingSpaceDb.dicPsCarType2Enum[listRecord[i++]];
            comboBoxSpacePosi.SelectedIndex = CParkingSpaceDb.dicPsSpacePosi2Enum[listRecord[i++]];
            comboBoxSpaceAera.SelectedIndex = CParkingSpaceDb.dicPsSpaceAera2Enum[listRecord[i++]];
            textBoxAttr1.Text = listRecord[i++];
            textBoxAttr2.Text = listRecord[i++];
            textBoxAttr3.Text = listRecord[i++];
            textBoxCarPlate.Text = listRecord[i++];
            textBoxPicPath.Text = listRecord[i++];
        }

        public void dbStru2Ui ()
        {
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
        }

        public object dbStruGet ()
        {
            return sPsStru;
        }

        public void dbUi2Stru ()
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

        public void dbUiAddModeSet ()
        {
            textBoxId.Enabled = false;
        }

        public void dbUiInit ()
        {
            int i;

            for ( i=0; i< CParkingSpaceDb.strPsLockStatDesc.Length; i++ ) {
                comboBoxLockStat.Items.Add( CParkingSpaceDb.strPsLockStatDesc[i] );
            }
            for ( i=0; i< CParkingSpaceDb.strPsSpaceTypeDesc.Length; i++ ) {
                comboBoxSpaceType.Items.Add( CParkingSpaceDb.strPsSpaceTypeDesc[i] );
            }
            for ( i=0; i< CParkingSpaceDb.strPsSpacePosiDesc.Length; i++ ) {
                comboBoxSpacePosi.Items.Add( CParkingSpaceDb.strPsSpacePosiDesc[i] );
            }
            for ( i=0; i< CParkingSpaceDb.strPsSpaceAreaDesc.Length; i++  ) {
                comboBoxSpaceAera.Items.Add( CParkingSpaceDb.strPsSpaceAreaDesc[i] );
            }

            textBoxId.Text = "0";
        }

        public void dbUiShowDialog ()
        {
            this.ShowDialog();
        }

        public void dbUiUpdateModeSet ()
        {
            textBoxId.Enabled = false;
        }

        private void buttonOk_Click (object sender, EventArgs e)
        {
            dbUi2Stru();
            eDialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonCancel_Click (object sender, EventArgs e)
        {
            eDialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
