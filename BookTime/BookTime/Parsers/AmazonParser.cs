using AngleSharp.Html.Dom;
using htmlParsing.Core;
using System.Collections.Generic;
using System.Linq;

namespace BookTime.Parsers
{
    class AmazonParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            //            var booktitle = document.QuerySelectorAll("h5").Where(item => item.ClassName != null && item.ClassName.Contains("a-color-base")).FirstOrDefault();
            var booktitle = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("a-size-base")).FirstOrDefault();
            var author = document.QuerySelectorAll("div[class$='a-color-secondary']").FirstOrDefault();
            var img = document.QuerySelectorAll("img[src^='https://m.media-amazon.com/images']").FirstOrDefault();
            var isbn = "";
            //            var author = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("a-row a-spacing-micro")).First();

            if (booktitle != null)
            {
                list.Add(booktitle.TextContent);
                list.Add(author.TextContent);
                list.Add(img.GetAttribute("src"));
                list.Add(isbn);
                return list.ToArray();
            }
            else
            {
                return list.ToArray();
            }
        }
    }
}
