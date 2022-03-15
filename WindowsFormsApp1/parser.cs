using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class parser
    {
        public static async Task<string> ParseAnsAsync(string url)
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:96.0) Gecko/20100101 Firefox/96.0");

            var content = await client.GetStringAsync(url);
            string buf = content;

            content = Clear(content, "</h3><span>", "</span>");
            content = content.Substring(1);
            if (content[content.Length - 1] == '>')
            {
                buf = Clear(buf, "-</span></span><span>", "</span>");
                buf = buf.Substring(1);
                content = buf;


            }
            if (content == "rror")
            {
                buf = Clear(buf, ":2\"><span>", "</span></div></div>");
                buf = buf.Substring(1);

                buf = Regex.Replace(buf, @"<em>", "");
                buf = Regex.Replace(buf, @"</em>", "");

                content = buf;
            }

            return content;



        }


        public static string Clear(string txt, string txtPrefix, string txtSuffix)
        {
            var prefixPosition = txt.IndexOf(txtPrefix, StringComparison.OrdinalIgnoreCase);
            var suffixPosition = txt.IndexOf(txtSuffix, prefixPosition + txtPrefix.Length, StringComparison.OrdinalIgnoreCase);
            if ((prefixPosition >= 0) && (suffixPosition >= 0) && (suffixPosition > prefixPosition) && ((prefixPosition + txtPrefix.Length) <= suffixPosition))
            {
                return txt.Substring(prefixPosition + txtPrefix.Length - 1, suffixPosition - prefixPosition - txtPrefix.Length);
            }
            else
                return "Error";
        }
    }
}
