using System.Collections.Generic;
using System.Windows;

namespace BookDownloader
{
    public partial class MainWindow : Window
    {
        List<Book> books;
        public MainWindow()
        {
            InitializeComponent();
            books = new List<Book>();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            LB.Items.Clear();
            BookParserTululuDotOrg site = new BookParserTululuDotOrg();
            site.Search(TextSearch.Text);
            books = site.GetBooks();
            //foreach (Book b in books)
            //{
            //    LB.Items.Add($"{b.Name} ({b.Author})");
            //}


            //SiteToString siteToString = new SiteToString();
            //string htmlCode = siteToString.GetHtmlPage("https://tululu.org/search/?q=" + TextSearch.Text);

            //BookParser parser = new BookParser();
            //books = parser.GetBooksUrl(htmlCode);

            //// переписать foreach так, чтобы в боок можно было добавить ссылки на скачивание
            //foreach (Book b in books)
            //{
            //    LB.Items.Add($"{b.Name} ({b.Author})");
            //    htmlCode = siteToString.GetHtmlPage(b.Url);
            //    //htmlCode = siteToString.GetHtmlPage("https://tululu.org/b20468/");
            //    var bookDownloadUrl = parser.ClickButtonDownload(htmlCode, button1, b);
            //}

            // <a href="/read20468/" title="Быть победителем (Сталкер-2) - читать онлайн">читать книгу онлайн</a>
            // <a href="/txt.php?id=20468" title="Быть победителем (Сталкер-2) - скачать книгу txt">скачать txt</a>
            // <a href="/zip.php?id=20468" title="Быть победителем (Сталкер-2) - скачать книгу zip">скачать zip</a>
            // <a href="/jar.php?id=20468" title="Быть победителем (Сталкер-2) - скачать книгу jar">скачать jar</a>


        }
    }
}
