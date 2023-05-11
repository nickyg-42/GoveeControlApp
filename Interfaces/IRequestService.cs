using System;
using GoveeControl.Services;

namespace GoveeControl.Interfaces
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent payload);
    }
}
