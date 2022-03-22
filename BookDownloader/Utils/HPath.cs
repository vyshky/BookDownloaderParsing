using System;
using System.Collections.Generic;

namespace BookDownloader
{
    public class HPath
    {
        public string Path { get; private set; }

        public HPath(string hPath)
        {
            Path = hPath;
        }

        public string GetElement(string html)
        {
            HPath downloadTxt = new HPath("id='content'/table[1]/tbody/tr[4]/td/a[2]");
            Path = Path.Replace('\'', '"');
            string[] parser = Path.Split('/');

            int index = html.IndexOf(parser[0]);
            return string.Empty;
        }

        public List<string> GetList(string html)
        {
            HPath downloadTxt = new HPath("class='gSearch__results'/li[1]");
            Path = Path.Replace('\'', '"');
            string[] parser = Path.Split('/');

            List<string> list = new List<string>();


            int index = 0;
            int count;

            for (int i = 0; index != -1 && i < parser.Length; ++i)
            {
                count = 1;

                if (parser[i].Contains("[") && parser[i].Contains("]"))
                {
                    parser[i] = parser[i].Replace("[", "");
                    parser[i] = parser[i].Replace("]", "");
                    count = parser[i][parser[i].Length - 1] - 48;
                    parser[i] = parser[i].Replace(count.ToString(), "");

                    // обрезание лишних строк в начале
                    for (; count > 0; --count)
                    {
                        index = html.IndexOf(parser[i]);
                        html = html.Remove(0, index);
                    }

                    var endIndex = html.IndexOf(parser[i], parser[i].Length);

                    var tempHtml = html.Remove(endIndex + parser[i].Length);
                    html = html.Remove(0, endIndex);

                    list.Add(tempHtml);
                    continue;
                }

                // обрезание лишних строк в начале
                index = html.IndexOf(parser[i]);
                html = html.Remove(0, index);                
            }

            return list;
        }
    }
}
