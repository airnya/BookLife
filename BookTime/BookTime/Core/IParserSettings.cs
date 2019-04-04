using System;
using System.Collections.Generic;
using System.Text;

namespace htmlParsing.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }

        string MiddleUrl { get; set; }

        string Prefix { get; set; }

        int StartPoint { get; set; }

        int EndPoint { get; set; } //Отвечает за конец страницы

        string EndUrl { get; set; } //Отвечает за конец страницы

    }
}
