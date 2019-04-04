using htmlParsing.Core;


namespace BookTime.Parsers
{
    class AmazonSettings : IParserSettings
    {
        public AmazonSettings(string id)
        {
            MiddleUrl = id;
        }
        public string BaseUrl { get; set; } = "https://www.amazon.co.uk/s?k=";
        public string Prefix { get; set; }
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public string MiddleUrl { get; set; }
        public string EndUrl { get; set; } = "&i=stripbooks&ref=nb_sb_noss";
    }
}