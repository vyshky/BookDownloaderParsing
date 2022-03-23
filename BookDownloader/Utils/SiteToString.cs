using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookDownloader
{
    public class SiteToString
    {
        public string GetHtmlPage(string url, Encoding encoding = null)
        {

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();

            StreamReader sr;

            if (encoding == null)
            {
                sr = new StreamReader(stream);
            }
            else
            {
                sr = new StreamReader(stream, encoding);
            }

            return sr.ReadToEnd();
        }
    }
}
