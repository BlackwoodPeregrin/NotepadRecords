using System;
using System.Windows;

namespace AppRecords
{
    public partial class EntryDialog : Window
    {
        private DBExecutor executor = new DBExecutor();

        public EntryDialog()
        {
            InitializeComponent();
        }        

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var resSql = executor.SelectUser(txtUsername.Text, txtPassword.Text);
            if (resSql.HasValue == false) {
                MessageBox.Show("Incorrect username or password");
                return;
            }

            MainWindow mainWindow = new MainWindow(new RowTableExecutor(resSql.Value));
            mainWindow.Closed += Window_Closed;
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (executor.InsertUser(txtUsername.Text, txtPassword.Text)) {
                MessageBox.Show("registration success");
            } else {
                MessageBox.Show(string.Format("User with name {0} already exist", txtUsername.Text));
            }
            ClearFields();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ClearFields();
            this.Visibility = Visibility.Visible;
        }


        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
