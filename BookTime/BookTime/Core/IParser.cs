using AngleSharp.Html.Dom;


namespace htmlParsing.Core
{
    interface IParser<T> where T : class 
    {
        T Parse(IHtmlDocument document);
    }
}
