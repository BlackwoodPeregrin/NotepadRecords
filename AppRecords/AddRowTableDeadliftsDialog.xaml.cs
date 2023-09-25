using System;
using System.Windows;

namespace AppRecords
{
    public partial class AddRowTableDeadliftsDialog : Window
    {
        private int _userId;
        private int _number;
        private double _rodWeight;
        private TimeSpan _time;
        private DateTime _date;

        public AddRowTableDeadliftsDialog(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        public RowTable Result()
        {
            return new RowTableDeadlifts(_userId, _number, _rodWeight, _time, _date);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _number = int.Parse(number.Text);
                _rodWeight = double.Parse(rodWeight.Text);
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
