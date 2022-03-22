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
        string openBookUrl;
        List<Book> books;
        string htmlCode;
        string txt = "скачать txt";
        string zip = "скачать zip";
        string jar = "скачать jar";

        HPath searchBookList = new HPath("class='gSearch__results'/li[1]");
        HPath downloadTxt = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[2]");
        HPath downloadZip = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[3]");
        HPath downloadJar = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[4]");

        public BookParserTululuDotOrg()
        {
            openBookUrl = String.Empty;
            htmlCode = String.Empty;
            books = new List<Book>();
        }


        string OpenBookUrl
        {
            get { return openBookUrl; }
            set
            {
                openBookUrl = baseUrl + value;
            }
        }


        public void Search(string book)
        {
            SiteToString siteToString = new SiteToString();
            htmlCode = siteToString.GetHtmlPage($"{baseUrl}/search/?q={book}");
        }

        public List<Book> GetBooks()
        {
            List<string> list = searchBookList.GetHrefList(htmlCode);

            int i = 0;

            //txt = downloadTxt.GetHref(htmlCode);
            //zip = downloadZip.GetHref(htmlCode);
            //jar = downloadJar.GetHref(htmlCode);
            return books;
        }
    }
}
