using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using QRCoder;
using ZXing;
using ZXing.Common;

namespace praktika2022
{
    /// <summary>
    /// Логика взаимодействия для QrCode.xaml
    /// </summary>
    public partial class QrCode : Window
    {
        DB1.Model1 gg = new DB1.Model1();
        public QrCode()
        {
            InitializeComponent();
            gg.Service.Load(); 
           

        }
        private  int  GeneratorQR(string msg)
        {
            Bitmap img = null;
            QRCodeGenerator QR = new QRCodeGenerator();
            var MyData = QR.CreateQrCode(msg, QRCodeGenerator.ECCLevel.H);
            var code = new QRCode(MyData);          
            Wtf.Source = BitmapToBitmapImage(code.GetGraphic(50));
            return 123;
        }
        public string GeneratorBarcode (string msg)
        {
           BarcodeWriter writer = new BarcodeWriter() { Format =  BarcodeFormat.CODE_128  };
            Wtf.Source = BitmapTo(writer.Write(msg));
            return "fsdfsd";
        }
        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            GeneratorBarcode(txt.Text);
        }
        public static BitmapImage BitmapTo(Bitmap bitmap)
        {
            using (MemoryStream ms  = new MemoryStream ())
            {
                bitmap.Save (ms,ImageFormat.Png);
                ms.Position = 0;
                BitmapImage result = new BitmapImage ();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = ms;
                result.EndInit();
                result.Freeze ();
                return result;
            }
        }
    }
}
