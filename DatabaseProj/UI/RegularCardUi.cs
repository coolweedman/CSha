using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DatabaseProj.Code.Database;

namespace DatabaseProj.UI {
    class RegularCardUi : DbWinBase {

        CRegularCardView hRegularCardView;

        public RegularCardUi ()
        {
            hDataTable = new DataTable();
            hRegularCardView = new CRegularCardView();
            hDataTable.Load( hRegularCardView.dataBaseBaseCommRead() );
            dataGridViewDb.DataSource = hDataTable;
        }
    }
}
