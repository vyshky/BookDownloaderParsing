using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookDownloader
{
    public class BookParser
    {
        List<Book> books;
        string BaseUrl = "https://tululu.org/";
        string formatFileTxt = "txt.php?id=";
        string formatFileZip = "zip.php?id=";
        string formatFileJar = "jar.php?id=";

        public List<Book> GetBooksUrl(string site)
        {
            books = new List<Book>();
            string bookName = string.Empty;
            string url = string.Empty;
            string author = string.Empty;
            (string Text, int Index) block = ("", 0);
            site = GetBlock(site, "<ul class=\"gSearch__results\"", "</ul>").Text;

            if (site == string.Empty)
            {
                MessageBox.Show("По данному запросу ни чего не найдено");
                return books;
            }

            while (block.Index >= 0)
            {
                // Поиск url
                block = GetBlock(site, "href=\"", "\""); // находим параметр href
                if (block.Index < 0) continue;

                url = GetValue(block.Text, "\"/", "/\""); // получаем значение из параметра href
                if (url == string.Empty) continue;

                site = site.Remove(0, block.Index + block.Text.Length); // стираем данные с 0 indexa до последнего символа href="url"

                // Поиск название книги
                block = GetBlock(site, ">", "</a");
                if (block.Index < 0) continue;

                bookName = GetValue(block.Text, ">", "<");
                if (bookName == string.Empty) continue;

                site = site.Remove(0, block.Index + block.Text.Length);


                // Поиск автора книги
                block = GetBlock(site, "class=\"t\"", "</d");
                if (block.Index < 0) continue;

                author = GetValue(block.Text, ">", "<");
                if (author == string.Empty) continue;

                site = site.Remove(0, block.Index + block.Text.Length);

                books.Add(new Book()
                {
                    Name = bookName,
                    Url = BaseUrl + url,
                    Author = author
                });
            }

            return books;
        }

        private string GetValue(string text, string begin, string end)
        {
            var indexStart = text.IndexOf(begin);

            if (indexStart < 0)
                return string.Empty;

            var indexEnd = text.IndexOf(end, indexStart);

            if (indexEnd < 0)
                return string.Empty;

            text = text.Remove(indexEnd);
            return text.Remove(0, indexStart + begin.Length);
        }

        private (string Text, int Index) GetBlock(string text, string startBlock, string endBlock)
        {
            int startIndex = text.IndexOf(startBlock);

            if (startIndex < 0)
                return (string.Empty, -1);

            int endIndex = text.IndexOf(endBlock, startIndex + startBlock.Length);

            if (endIndex < 0)
                return (string.Empty, -1);

            text = text.Remove(endIndex + endBlock.Length);
            text = text.Remove(0, startIndex);

            return (text, startIndex);
        }


        public Book ClickButtonDownload(string site, string button, Book book)
        {
            // 29 td
            //<td> </td>
            //int startIndex1 = site.LastIndexOf("читать книгу онлайн");
            //int startIndex2 = site.LastIndexOf("скачать txt");
            //int startIndex3 = site.LastIndexOf("скачать zip");
            //int startIndex4 = site.LastIndexOf("скачать jar");
            //int startIndex5 = site.LastIndexOf(button);
            //if (startIndex5 < 0)
            //    return string.Empty;

            string path = "href=\"/read";
            string path2 = "\"";
            (string Text, int Index) block = GetBlock(site, path, path2);



            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();



            // TODO:: выбрать определенный бук и довать ссылки для скачивания
           // book.UrlDownload = keyValuePairs;
            return book;
        }
    }
}
