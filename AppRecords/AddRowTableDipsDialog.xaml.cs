using System;
using System.Windows;

namespace AppRecords
{
    public partial class AddRowTableDipsDialog : Window
    {
        private int _userId;
        private int _number;
        private double _extraWeight;
        private TimeSpan _time;
        private DateTime _date;

        public AddRowTableDipsDialog(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        public RowTable Result()
        {
            return new RowTableDips(_userId, _number, _extraWeight, _time, _date);
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
                _extraWeight = double.Parse(extraWeight.Text);
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
