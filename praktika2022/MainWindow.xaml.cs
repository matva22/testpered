using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktika2022
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB1.Model1 gg = new DB1.Model1();
        
        public MainWindow()
        {
            InitializeComponent();
            gg.users.Load();
            login.Focus();
            
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            Auth(login.Text, password.Password);
           
        }
        public  bool Auth (string login, string password)
        {

            
















            if (gg.users.Where(x => x.login == login && x.password == password && x.role == "admin").FirstOrDefault() != null)
            {
                main window = new main();

                window.Show();
                this.Close();
                return true;
            }
            else if (gg.users.Where(x => x.login != login && x.password != password).FirstOrDefault() != null)
            {

                
                MessageBox.Show("Неверно введён логин или пароль");              
                return false;

            }


            else if (gg.users.Where(x => x.login == login && x.password == password && x.role == "client").FirstOrDefault() != null)
            {
                main window = new main();
                window.Show();
                this.Close();
                window.role2.Visibility = Visibility.Collapsed;
                return true;
            }
            return false;
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
