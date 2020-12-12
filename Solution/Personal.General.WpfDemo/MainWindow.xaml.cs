﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Personal.General.WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadImage(this.Image1, "https://icatcare.org/app/uploads/2018/07/Thinking-of-getting-a-cat.png");
            DownloadImage(this.Image2, "https://static01.nyt.com/images/2020/04/22/science/22VIRUS-PETCATS1/22VIRUS-PETCATS1-mediumSquareAt3X.jpg");
            DownloadImage(this.Image3, "https://zjf683hopnivfq5d12xaooxr-wpengine.netdna-ssl.com/wp-content/uploads/2020/02/GettyImages-1199242002-1-1920x1080.jpg");
            DownloadImage(this.Image4, "https://media.wired.com/photos/5e1e646743940d0008009167/master/w_2560%2Cc_limit/Science_Cats-84873657.jpg");
            DownloadImage(this.Image5, "https://www.thesprucepets.com/thmb/V1oGzYAiUkinq94H0wZ8YM2CUsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Stocksy_txp33a24e10lxw100_Medium_214761-5af9d6d7875db900360440a7.jpg");
            DownloadImage(this.Image6, "https://www.thesprucepets.com/thmb/V1oGzYAiUkinq94H0wZ8YM2CUsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Stocksy_txp33a24e10lxw100_Medium_214761-5af9d6d7875db900360440a7.jpg");
            DownloadImage(this.Image7, "https://media.wired.com/photos/5e1e646743940d0008009167/master/w_2560%2Cc_limit/Science_Cats-84873657.jpg");
            DownloadImage(this.Image8, "https://zjf683hopnivfq5d12xaooxr-wpengine.netdna-ssl.com/wp-content/uploads/2020/02/GettyImages-1199242002-1-1920x1080.jpg");
            DownloadImage(this.Image9, "https://static01.nyt.com/images/2020/04/22/science/22VIRUS-PETCATS1/22VIRUS-PETCATS1-mediumSquareAt3X.jpg");
            DownloadImage(this.Image10, "https://icatcare.org/app/uploads/2018/07/Thinking-of-getting-a-cat.png");
        }

        private void DownloadImage(Image image, string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).GetAwaiter().GetResult();
            var byteArrayData = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            image.Source = this.LoadImage(byteArrayData);
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
