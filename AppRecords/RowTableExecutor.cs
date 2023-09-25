using System.Collections.Generic;
using System.Windows.Controls;

namespace AppRecords
{
    public class RowTableExecutor
    {
        private readonly DBExecutor executor = new DBExecutor();
        private readonly int userId;

        public RowTableExecutor(int userId)
        {
            this.userId = userId;
        }

        public List<RowTable> GetValuesFromTable(TableType type)
        {
            List<RowTable> result = new List<RowTable>();
            DataGrid dataGrid = new DataGrid();
            
            switch (type)
            {
                case TableType.Run:
                    result.AddRange(executor.SelectFromTableRun(userId));
                    break;
                case TableType.Swim:
                    result.AddRange(executor.SelectFromTableSwim(userId));
                    break;
                case TableType.Planka:
                    result.AddRange(executor.SelectFromTablePlanka(userId));
                    break;
                case TableType.PullUps:
                    result.AddRange(executor.SelectFromTablePullUps(userId));
                    break;
                case TableType.PushUps:
                    result.AddRange(executor.SelectFromTablePushUps(userId));
                    break;
                case TableType.Dips:
                    result.AddRange(executor.SelectFromTableDips(userId));
                    break;
                case TableType.MuscleUps:
                    result.AddRange(executor.SelectFromTableMuscleUps(userId));
                    break;
                case TableType.BenchPress:
                    result.AddRange(executor.SelectFromTableBenchPress(userId));
                    break;
                case TableType.BackSquats:
                    result.AddRange(executor.SelectFromTableBackSquats(userId));
                    break;
                case TableType.Deadlifts:
                    result.AddRange(executor.SelectFromTableDeadlifts(userId));
                    break;
                case TableType.BicepCurls:
                    result.AddRange(executor.SelectFromTableBicepCurls(userId));
                    break;
                case TableType.OverheadPress:
                    result.AddRange(executor.SelectFromTableOverheadPress(userId));
                    break;
                default:
                    break;
            }
            return result;
        }

        public int InsertRowToTable(RowTable row)
        {
            switch (row.Type())
            {
                case TableType.Run:
                    return executor.InsertIntoTableRun((RowTableRun)row);
                case TableType.Swim:
                    return executor.InsertIntoTableSwim((RowTableSwim)row);
                case TableType.Planka:
                    return executor.InsertIntoTablePlanka((RowTablePlanka)row);
                case TableType.PullUps:
                    return executor.InsertIntoTablePullUps((RowTablePullUps)row);
                case TableType.PushUps:
                    return executor.InsertIntoTablePushUps((RowTablePushUps)row);
                case TableType.Dips:
                    return executor.InsertIntoTableDips((RowTableDips)row);
                case TableType.MuscleUps:
                    return executor.InsertIntoTableMuscleUps((RowTableMuscleUps)row);
                case TableType.BenchPress:
                    return executor.InsertIntoTableBenchPress((RowTableBenchPress)row);
                case TableType.BackSquats:
                    return executor.InsertIntoTableBackSquats((RowTableBackSquats)row);
                case TableType.Deadlifts:
                    return executor.InsertIntoTableDeadlifts((RowTableDeadlifts)row);
                case TableType.BicepCurls:
                    return executor.InsertIntoTableBicepCurls((RowTableBicepCurls)row);
                case TableType.OverheadPress:
                    return executor.InsertIntoTableOverheadPress((RowTableOverheadPress)row);
                default:
                    return -1;
            }
        }

        public List<RowTable> GenerateAddRowTableDialog(TableType type)
        {
            List<RowTable> result = new List<RowTable>();
            switch (type)
            {
                case TableType.Run:
                    {
                        var d = new AddRowTableRunDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.Swim:
                    {
                        var d = new AddRowTableSwimDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.Planka:
                    {
                        var d = new AddRowTablePlankaDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.PullUps:
                    {
                        var d = new AddRowTablePullUpsDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.PushUps:
                    {
                        var d = new AddRowTablePushUpsDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.Dips:
                    {
                        var d = new AddRowTableDipsDialog(userId);
                        if (d.ShowDialog() == true) {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.MuscleUps:
                    {
                        var d = new AddRowTableMuscleUpsDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.BenchPress:
                    {
                        var d = new AddRowTableBenchPressDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.BackSquats:
                    {
                        var d = new AddRowTableBackSquatsDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.Deadlifts:
                    {
                        var d = new AddRowTableDeadliftsDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.BicepCurls:
                    {
                        var d = new AddRowTableBicepCurlsDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;
                case TableType.OverheadPress:
                    {
                        var d = new AddRowTableOverheadPressDialog(userId);
                        if (d.ShowDialog() == true)
                        {
                            result.Add(d.Result());
                        }
                    }
                    break;

            }
            return result;
        }

        public DataGrid ConvertListRowsToGrid(List<RowTable> rows, TableType tableType)
        {
            var dataGrid = new DataGrid();
            switch (tableType)
            {
                case TableType.Run:
                    {
                        var lst = new List<RowTableRun>();
                        foreach (var row in rows) {
                            lst.Add((RowTableRun)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                    case TableType.Swim:
                    {
                        var lst = new List<RowTableSwim>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableSwim)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.Planka:
                    {
                        var lst = new List<RowTablePlanka>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTablePlanka)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.PullUps:
                    {
                        var lst = new List<RowTablePullUps>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTablePullUps)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.PushUps:
                    {
                        var lst = new List<RowTablePushUps>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTablePushUps)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.Dips:
                    {
                        var lst = new List<RowTableDips>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableDips)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.MuscleUps:
                    {
                        var lst = new List<RowTableMuscleUps>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableMuscleUps)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.BenchPress:
                    {
                        var lst = new List<RowTableBenchPress>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableBenchPress)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.BackSquats:
                    {
                        var lst = new List<RowTableBackSquats>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableBackSquats)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.Deadlifts:
                    {
                        var lst = new List<RowTableDeadlifts>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableDeadlifts)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.BicepCurls:
                    {
                        var lst = new List<RowTableBicepCurls>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableBicepCurls)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
                case TableType.OverheadPress:
                    {
                        var lst = new List<RowTableOverheadPress>();
                        foreach (var row in rows)
                        {
                            lst.Add((RowTableOverheadPress)row);
                        }
                        dataGrid.ItemsSource = lst;
                    }
                    break;
            }
            return dataGrid;
        }
    }
}
