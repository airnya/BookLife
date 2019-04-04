using System.Net.Http;
using System.Threading.Tasks;

namespace htmlParsing.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}{settings.MiddleUrl}{settings.EndUrl}/{settings.Prefix}";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrendId}", id.ToString());
            var response = await client.GetAsync(currentUrl); //Принимает результат метода GetAsync по указанной ссылке
            string source = null; 
            if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            return source;

        }
    }
}
