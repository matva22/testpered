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
using System.Windows.Shapes;

namespace praktika2022
{
    /// <summary>
    /// Логика взаимодействия для role1.xaml
    /// </summary>
    public partial class role1 : Window
    {
        DB1.Model1 gg = new DB1.Model1();
        public role1()
        {
            InitializeComponent();
            gg.users.Load();
            table2.ItemsSource = gg.users.Local;
            
           
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            DB1.users t = new DB1.users();
            t.login = log.Text;
            t.password = pas.Text;

            switch (cb3.SelectedIndex)
            {
                case 0:
                    t.role = "admin";
                    break;
                case 1:
                    t.role = "client";
                    break;
                default:
                    break;
                    
            }
            gg.users.Add(t);
            gg.SaveChanges();
            table2.ItemsSource = gg.users.Local;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            
            
           
                
                var pp = (DB1.users)table2.SelectedItem;
                gg.users.Remove(pp);
                gg.SaveChanges();
                table2.ItemsSource = gg.users.Local;
           
            
        }

        private void table2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (table2.IsMouseOver == false)
            {
                delete.Visibility = Visibility.Collapsed;
            }
            else
            {
                delete.Visibility = Visibility.Visible;
            }
        }
    }
}
