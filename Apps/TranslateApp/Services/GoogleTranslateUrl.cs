using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using HtmlAgilityPack;

namespace TranslateApp.Services
{
    public class GoogleTranslateUrl
    {
        public HtmlNode TryIt()
        {
            var url = "https://translate.google.com/" + "#auto" + "/en" + "gwneud";
            var web = new HtmlWeb();
            var doc = web.LoadFromWebAsync(url).Result.DocumentNode;

            var res = Enumerate(doc);
            return res;
        }

        private HtmlNode Enumerate(HtmlNode htmlNodeCollection)
        {
            HtmlNode result = null;
            foreach (HtmlNode item in htmlNodeCollection.ChildNodes)
            {
                if (item.HasAttributes)
                {
                    if (item.Id != "result_box")
                    {
                        continue;
                    }

                    result = item;
                    return result;
                }
                if (item.HasChildNodes)
                {
                    Enumerate(item);
                }
            }
            return result;
        }
    }
}
