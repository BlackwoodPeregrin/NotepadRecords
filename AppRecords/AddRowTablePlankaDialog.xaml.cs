using System;
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
    public partial class AddRowTablePlankaDialog : Window
    {
        private int _userId;
        private TimeSpan _time;
        private DateTime _date;

        public AddRowTablePlankaDialog(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        public RowTable Result()
        {
            return new RowTablePlanka(_userId, _time, _date);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try {
                _time = TimeSpan.Parse(time.Text);
                _date = DateTime.Parse(date.Text);
                DialogResult = true;
            } catch {
                MessageBox.Show("Неккорктные входящие значения");
            }
        }
    }
}
