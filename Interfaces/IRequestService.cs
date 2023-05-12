namespace GoveeControl.Interfaces
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers);
        Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers, HttpContent payload);
        Task<HttpResponseMessage> PutAsync(string url, Dictionary<string, string> headers, HttpContent payload);
        Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> headers, HttpContent payload);
        Task<HttpResponseMessage> SendAsync(string url, Dictionary<string, string> headers, HttpMethod method, HttpContent payload);
    }
}
