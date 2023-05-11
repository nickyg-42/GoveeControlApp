using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _goveeHttpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent payload)
        {
            return await _goveeHttpClient.PostAsync(url, payload);
        }
    }
}
