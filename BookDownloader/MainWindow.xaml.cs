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
            BookParserTululuDotOrg site = new BookParserTululuDotOrg(TextSearch.Text);

            books = site.GetBooks();

            foreach (Book b in books)
            {
                LB.Items.Add($"{b.Name} ({b.Author})");
            }
        }
    }
}
