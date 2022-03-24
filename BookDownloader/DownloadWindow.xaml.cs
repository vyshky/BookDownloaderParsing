using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace BookDownloader
{
    public partial class DownloadWindow : Window
    {
        Book _book;
        string _path;
        public DownloadWindow(Book book, string path)
        {
            InitializeComponent();
            _book = book;
            _path = path;
            Init();
        }

        private void Init()
        {
            LableNameBook.Content = $"{_book.Name}({_book.Author})";

            if (_book.Txt != null && _book.Txt.Length > 0)
            {
                LBUrlsDownload.Items.Add("TXT");
            }
            if (_book.Zip != null && _book.Zip.Length > 0)
            {
                LBUrlsDownload.Items.Add("ZIP");
            }
            if (_book.Jar != null && _book.Jar.Length > 0)
            {
                LBUrlsDownload.Items.Add("JAR");
            }
        }

        private void SelectUrl(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            string path;
            try
            {
                if (LBUrlsDownload.SelectedItem.ToString() == "TXT")
                {
                    path = $"{_path}\\{_book.Name}({_book.Author}).txt";
                    client.DownloadFile(new Uri(_book.Txt), path);                   
                }
                if (LBUrlsDownload.SelectedItem.ToString() == "ZIP")
                {
                    path = $"{_path}\\{_book.Name}({_book.Author}).zip";
                    client.DownloadFile(new Uri(_book.Zip), path);                   
                }
                if (LBUrlsDownload.SelectedItem.ToString() == "JAR")
                {
                    path = $"{_path}\\{_book.Name}({_book.Author}).jar";
                    client.DownloadFile(new Uri(_book.Jar), path);                   
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
