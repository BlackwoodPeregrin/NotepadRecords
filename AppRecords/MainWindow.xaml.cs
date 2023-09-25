using System.Windows;

namespace AppRecords
{
    public partial class MainWindow : Window
    {
        private RowTableExecutor executor;
        
        public MainWindow(RowTableExecutor executor)
        {
            InitializeComponent();
            this.executor = executor;
        }

        private void RunClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.Run);
        }

        private void SwimClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.Swim);
        }

        private void PullUpsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.PullUps);
        }

        private void MuscleUpsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.MuscleUps);
        }

        private void PushUpsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.PushUps);
        }

        private void DipsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.Dips);
        }

        private void PlankaClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.Planka);
        }

        private void BenchPressClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.BenchPress);

        }

        private void BackSquatsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.BackSquats);
        }

        private void DeadliftsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.Deadlifts);
        }

        private void BicepCurlsClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.BicepCurls);
        }

        private void OverheadPressClick(object sender, RoutedEventArgs e)
        {
            ShowStaticTable(TableType.OverheadPress);
        }

        private void ShowStaticTable(TableType tableType)
        {
            this.Visibility = Visibility.Hidden;
            StatisticTable t = new StatisticTable(executor, tableType);
            if (t.ShowDialog() == false)
            {
                this.Visibility = Visibility.Visible;
            }
        }
    }
}
