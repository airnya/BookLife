using AngleSharp.Html.Parser;
using System;

namespace htmlParsing.Core
{
    class ParserWorker<T> where T : class //обобщенный класс
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;
        bool isActive;
        
        #region properties
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value); //
            }
        }
        
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)        //Принмает настройки парсера
        {
            this.parserSettings = parserSettings;
        }
        //Принмает настройки парсера

        public void Start()
        {
            isActive = true;
            Worker();
        }
        
        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for(int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if (!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return;
                }

                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);

                OnNewData?.Invoke(this, result);

            }
            OnCompleted?.Invoke(this);
            isActive = false;
        }
    }
}
