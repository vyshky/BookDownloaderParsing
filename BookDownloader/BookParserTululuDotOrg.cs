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
        SiteToString siteToString;
        string htmlCode;
        string url = "target=\"_blank\" href=\"";
        string name = ">";
        string author = "class=\"t\">";

        string txt = "href=\"/txt";
        string zip = "href=\"/zip";
        string jar = "href=\"/jar";

        Encoding cyrillic = Encoding.GetEncoding(1251);
        public BookParserTululuDotOrg(string book)
        {
            htmlCode = String.Empty;
            books = new List<Book>();
            siteToString = new SiteToString();
            htmlCode = siteToString.GetHtmlPage($"{baseUrl}/search/?q={book}");
        }

        public List<Book> GetBooks()
        {
            Book book = new Book();


            int index = 0;

            for (int i = 0; i < htmlCode.Length / 2; ++i)
            {
                book = new Book();
                index = htmlCode.IndexOf(url);
                if (index < 0)
                { break; }
                htmlCode = htmlCode.Remove(0, index + url.Length);
                book.BaseUrl = baseUrl + htmlCode.Remove(htmlCode.IndexOf("\""));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("\""));

                index = htmlCode.IndexOf(name);
                if (index < 0)
                { break; }
                htmlCode = htmlCode.Remove(0, index + name.Length);
                book.Name = htmlCode.Remove(htmlCode.IndexOf("<"));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("<"));


                index = htmlCode.IndexOf(author);
                if (index < 0)
                { break; }
                htmlCode = htmlCode.Remove(0, index + author.Length);
                book.Author = htmlCode.Remove(htmlCode.IndexOf("<"));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("<"));

                books.Add(book);
            }
                   


            for (int i = 0; i < books.Count; ++i)
            {
                htmlCode = siteToString.GetHtmlPage(books[i].BaseUrl, cyrillic);
                index = htmlCode.IndexOf(txt);
                if (index < 0)
                { continue; }
                htmlCode = htmlCode.Remove(0, index + txt.Length);
                books[i].Txt = baseUrl + "/txt" + htmlCode.Remove(htmlCode.IndexOf("\""));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("\""));



                index = htmlCode.IndexOf(zip);
                if (index < 0)
                { continue; }
                htmlCode = htmlCode.Remove(0, index + zip.Length);
                books[i].Zip = baseUrl + "/zip" + htmlCode.Remove(htmlCode.IndexOf("\""));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("\""));


                index = htmlCode.IndexOf(jar);
                if (index < 0)
                { continue; }
                htmlCode = htmlCode.Remove(0, index + jar.Length);
                books[i].Jar = baseUrl + "/jar" + htmlCode.Remove(htmlCode.IndexOf("\""));
                htmlCode = htmlCode.Remove(0, htmlCode.IndexOf("\""));
            }

            return books;
        }

    }
}
