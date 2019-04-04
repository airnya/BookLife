using AngleSharp.Html.Dom;
using htmlParsing.Core;
using System.Collections.Generic;
using System.Linq;

namespace BookTime.Parsers
{
    class GoogleParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var booktitle = document.QuerySelectorAll("h1").Where(item => item.ClassName != null && item.ClassName.Contains("bItemName")).FirstOrDefault();
            var author = document.QuerySelectorAll("div[itemprop*='author']").FirstOrDefault();
            var img = document.QuerySelectorAll("img[itemprop*='image']").FirstOrDefault();
            var isbn = document.QuerySelectorAll("div[itemprop*='isbn']").FirstOrDefault();
            //var description = document.QuerySelectorAll("img[itemprop*='image']").First();
            //var isbn = document.QuerySelectorAll("img[itemprop*='image']").First();
            if (booktitle != null)
            {
                list.Add(booktitle.TextContent);
                list.Add(author.TextContent);
                list.Add(img.GetAttribute("src"));
                list.Add(isbn.TextContent);
                //list.Add(description.TextContent);
                //list.Add(isbn.TextContent);
                return list.ToArray();
            }
            else
            {
                return list.ToArray();
            }
        }
    }
}
