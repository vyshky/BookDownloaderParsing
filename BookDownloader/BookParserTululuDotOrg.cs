using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDownloader
{
    public class BookParserTululuDotOrg
    {
        string baseUrl = "https://tululu.org";
        List<Book> books;
        string htmlCode;
        string txt = "скачать txt";
        string zip = "скачать zip";
        string jar = "скачать jar";
        string name = "Название книги";
        string author = "Иванов Ваня";
        string href = "google.ru";

        HPath searchBookList = new HPath("class='gSearch__results'/li[1]");
        HPath downloadTxt = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[2]");
        HPath downloadZip = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[3]");
        HPath downloadJar = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[4]");

        public BookParserTululuDotOrg()
        {
            htmlCode = String.Empty;
            books = new List<Book>();
        }

        public void Search(string book)
        {
            SiteToString siteToString = new SiteToString();
            htmlCode = siteToString.GetHtmlPage($"{baseUrl}/search/?q={book}");
        }

        public List<Book> GetBooks()
        {
            List<string> list = searchBookList.GetList(htmlCode);


            // TODO :: реализовать цикл для перебора всего листа с книгами
            /////////////////////////////////////////////// 
            href = GetValue(list[0], "href=\"", "\"");
            name = GetValue(list[0], $"{href}\">", "</a>");
            author = GetValue(list[0], "class=\"t\">", "<");
            books.Add(new Book
            {
                Name = name,
                Author = author,
                Url = baseUrl + href,
                Txt = txt,
                Zip = zip,
                Jar = jar
            });
            ///////////////////////////////////////////////  


            // Реализовать получение ссылко на скачивание
            //txt = downloadTxt.GetHref(htmlCode);
            //zip = downloadZip.GetHref(htmlCode);
            //jar = downloadJar.GetHref(htmlCode);


            return books;
        }

        private string GetValue(string text, string startBlock, string endBlock)
        {
            int startIndex = text.IndexOf(startBlock);

            if (startIndex < 0)
                return string.Empty;

            int endIndex = text.IndexOf(endBlock, startIndex + startBlock.Length);

            if (endIndex < 0)
                return string.Empty;

            text = text.Remove(endIndex);
            text = text.Remove(0, startIndex + startBlock.Length);

            return text;
        }
    }
}
