using System;
using System.Windows;

namespace AppRecords
{
    public partial class AddRowTableSwimDialog : Window
    {
        private int _userId;
        private double _distance;
        private TimeSpan _time;
        private DateTime _date;

        public AddRowTableSwimDialog(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        public RowTable Result()
        {
            return new RowTableSwim(_userId, _distance, _time, _date);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _distance = double.Parse(distance.Text);
                _time = TimeSpan.Parse(time.Text);
                _date = DateTime.Parse(date.Text);
                DialogResult = true;
            }
            catch
            {
                MessageBox.Show("Неккорктные входящие значения");
            }
        }
    }
}
