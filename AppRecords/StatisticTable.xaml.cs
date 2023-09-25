using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppRecords
{
    public partial class StatisticTable : Window
    {
        private readonly RowTableExecutor executor;
        private readonly TableType tableType;
        private List<RowTable> rows;
        private List<RowTable> newRows;

        public StatisticTable(RowTableExecutor executor, TableType tableType)
        {
            InitializeComponent();
            this.executor = executor;
            this.tableType = tableType;
            this.rows = executor.GetValuesFromTable(this.tableType);
            this.newRows = new List<RowTable>();

            dataGrid.ItemsSource = executor.ConvertListRowsToGrid(this.rows, this.tableType).ItemsSource;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int count = newRows.Count;
            newRows.AddRange(executor.GenerateAddRowTableDialog(this.tableType));
            
            if (newRows.Count != count)
            {
                List<RowTable> tableRows = new List<RowTable>();
                tableRows.AddRange(rows);
                tableRows.AddRange(newRows);
                dataGrid.ItemsSource = executor.ConvertListRowsToGrid(tableRows, this.tableType).ItemsSource;
                dataGrid.Items.Refresh();
            }
        }

        private void StatisticTable_Closed(object sender, EventArgs e)
        {
            foreach(var r in newRows) {
                executor.InsertRowToTable(r);
            }
        }
    }
}
