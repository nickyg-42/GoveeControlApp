using GoveeControl.Interfaces;

namespace GoveeControl.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _goveeHttpClient;

        public RequestService(HttpClient goveeClient)
        {
            _goveeHttpClient = goveeClient;
        }

        /// <summary>
        /// Get method
        /// </summary>
        /// <param name="url">The target URL</param>
        /// <param name="headers">The necessary headers</param>
        /// <returns>A task representing the result of the request</returns>
        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            AddHeaders(headers, request);

            return await _goveeHttpClient.SendAsync(request);
        }

        /// <summary>
        /// Overloaded Get method, takes in body data
        /// </summary>
        /// <param name="url">The target URL</param>
        /// <param name="headers">The necessary headers</param>
        /// <param name="payload">The payload body</param>
        /// <returns>A task representing the result of the request</returns>
        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers, HttpContent payload)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = payload
            };

            AddHeaders(headers, request);

            return await _goveeHttpClient.SendAsync(request);
        }

        /// <summary>
        /// Put method
        /// </summary>
        /// <param name="url">The target URL</param>
        /// <param name="headers">The necessary headers</param>
        /// <param name="payload">The payload body</param>
        /// <returns>A task representing the result of the request</returns>
        public async Task<HttpResponseMessage> PutAsync(string url, Dictionary<string, string> headers, HttpContent payload)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = payload
            };

            AddHeaders(headers, request);

            return await _goveeHttpClient.SendAsync(request);
        }

        /// <summary>
        /// Post method, not implemented yet
        /// </summary>
        /// <param name="url">The target URL</param>
        /// <param name="headers">The necessary headers</param>
        /// <param name="payload">The payload body</param>
        /// <returns>A task representing the result of the request</returns>
        public Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> headers, HttpContent payload)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generic send method
        /// </summary>
        /// <param name="url">The target URL</param>
        /// <param name="headers">The necessary headers</param>
        /// <param name="method">The HTTP method</param>
        /// <param name="payload">The payload body</param>
        /// <returns>A task representing the result of the request</returns>
        public async Task<HttpResponseMessage> SendAsync(string url, Dictionary<string, string> headers, HttpMethod method, HttpContent payload)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = payload
            };

            AddHeaders(headers, request);

            return await _goveeHttpClient.SendAsync(request);
        }

        /// <summary>
        /// Helper method to reduce repetitive code
        /// </summary>
        /// <param name="headers">Dictionary of headers</param>
        /// <param name="req">HttpRequest to have headers added to it</param>
        private static void AddHeaders(Dictionary<string, string> headers, HttpRequestMessage req)
        {
            foreach (var header in headers)
            {
                req.Headers.Add(header.Key, header.Value);
            }
        }
    }
}
