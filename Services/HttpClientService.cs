using System.Net.Http;

namespace GoveeControl.Services
{
    public static class GoveeHttpClient
    {
        private static readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Instance
        {
            get { return _httpClient.Value; }
        }
    }
}
