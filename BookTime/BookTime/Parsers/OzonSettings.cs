using htmlParsing.Core;


namespace BookTime.Parsers
{
    class OzonSettings : IParserSettings
    {
        public OzonSettings(string id)
        {
            Prefix = id;
        }

        public string BaseUrl { get; set; } = "https://www.ozon.ru/context/detail/id/";
        public string Prefix { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string EndUrl { get ; set; }
        public string MiddleUrl { get ; set ; }
    }
}