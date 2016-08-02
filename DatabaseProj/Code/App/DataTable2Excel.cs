using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Data;


namespace DatabaseProj.Code.App {
    public class CDataTable2Excel {

        public void excelCreate ()
        {
            Application hExcelFile = new Application();

            hExcelFile.Application.Workbooks.Add( true );
            hExcelFile.Visible = false;
            hExcelFile.DisplayAlerts = false;

            for ( int i=0; i<5; i++ ) {
                for ( int j=0; j<3; j++ ) {
                    hExcelFile.Cells[i + 1, j + 1] = i * j;
                }
            }

            hExcelFile.SaveWorkspace();
            hExcelFile.Quit();
        }

        public static void dataTable2Excel (ref System.Data.DataTable hDataTable)
        {
            if ( null == hDataTable ) {
                return;
            }

            Application hExcelFile = new Application();

            hExcelFile.Application.Workbooks.Add( true );
            hExcelFile.Visible = false;
            hExcelFile.DisplayAlerts = false;

            for ( int i = 0; i < hDataTable.Rows.Count; i++ ) {
                for ( int j = 0; j < hDataTable.Columns.Count; j++ ) {
                    hExcelFile.Cells[i + 1, j + 1] = hDataTable.Rows[i][j];
                }
            }

            hExcelFile.SaveWorkspace();
            hExcelFile.Quit();
        }
    }
}
