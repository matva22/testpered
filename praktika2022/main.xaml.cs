
using praktika2022.DB1;
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
using ZXing;

namespace praktika2022
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        DB1.Model1 gg = new DB1.Model1();
        public main()
        {
            InitializeComponent();
            gg.Service.Load();
            table.ItemsSource =  gg.Service.Local;

            Barcode(Name);
                



        }

        private void role2_Click(object sender, RoutedEventArgs e)
        {
            QrCode role1 = new QrCode();
            role1.Show();
        }

        private void serach_TextChanged(object sender, TextChangedEventArgs e)
        {
            table.ItemsSource = gg.Service.Local.Where(x=> x.Title.ToLower().Contains(serach.Text.ToLower()));
        }

        private void cb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb2.SelectedIndex)
            {
                case 0:
                    table.ItemsSource = gg.Service.Local;
                    break;
                    case 1:
                    table.ItemsSource = gg.Service.Local.Where(x => x.Cost <=250);
                    break;
                case 2:
                    table.ItemsSource = gg.Service.Local.Where(x => x.Cost >=250 && x.Cost <=1000);
                    break;
                case 3:
                    table.ItemsSource = gg.Service.Local.Where(x => x.Cost >=1000);
                    break;

                default:
                    break;
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb.SelectedIndex)
            {
                case 0:
                    table.ItemsSource = gg.Service.Local;
                    break;
                case 1:
                    table.ItemsSource = gg.Service.Local.OrderBy(x => x.Title);
                    break;
                case 2:
                    table.ItemsSource = gg.Service.Local.OrderByDescending(x => x.Title);
                    break;
                default:
                    break;
            }
        }

        private void QR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var pp = (Service)table.SelectedItem;
            gg.Service.Remove(pp);
            gg.SaveChanges();
            table.ItemsSource =  gg.Service.Local;
            Service yu = new Service();
            yu.Title = serach.Text;
            gg.Service.Add(yu);
           

        }
        public string Barcode(string msg)
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.QR_CODE  };
            
            
            return msg;
        }
        public string wtf (string uu)
        {
            var tt = (DB1.Service)table.SelectedItem;
            gg.Service.Remove (tt);
            gg.SaveChanges();
            DB1.Service bb = new Service();
            bb.Title = serach.Text;
            gg.SaveChanges ();
            return uu;
        }
    }
}
