using System.Net;
using System.Text;
using GoveeControl.Interfaces;
using GoveeControl.Models;
using Newtonsoft.Json;

namespace GoveeControl.Services
{
    public class GoveeClient : IGoveeClient
    {
        private readonly IRequestService _requestService;
        private readonly IResponseService _responseService;
        private readonly string _baseUrl = "https://developer-api.govee.com/v1";
        private readonly Dictionary<string, string> _headers;

        public GoveeClient(IRequestService requestService, IResponseService responseService, string apiKey)
        {
            _requestService = requestService;
            _responseService = responseService;
            _headers = new Dictionary<string, string> { { "Govee-API-Key", apiKey } };
        }

        /// <summary>
        /// Method to retrieve all devices
        /// </summary>
        /// <returns>A list of all devices</returns>
        public async Task<List<GoveeDevice>> GetDevices()
        {
            string fullUrl = $"{_baseUrl}/devices";

            var res = await _requestService.GetAsync(fullUrl, _headers);

            if (res.IsSuccessStatusCode) return await _responseService.DeserializeIntoDeviceList(res);
            else throw new HttpRequestException(HandleHttpError(res.StatusCode));
        }

        /// <summary>
        /// Method to turn device off
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <returns>The response from the HTTP request</returns>
        public async Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device)
        {
            string payload = CreatePayload(device, new
            {
                name = "turn",
                value = "off"
            });

            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");

            return await MakeRequest("/devices/control", HttpMethod.Put, body);
        }

        /// <summary>
        /// Method to turn device on
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <returns>The response from the HTTP request</returns>
        public async Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device)
        {
            string payload = CreatePayload(device, new
            {
                name = "turn",
                value = "on"
            });

            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");

            return await MakeRequest("/devices/control", HttpMethod.Put, body);
        }

        /// <summary>
        /// Method to set device color
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <param name="rVal">The "red" pixel value</param>
        /// <param name="gVal">The "greem" pixel value</param>
        /// <param name="bVal">The "blue" pixel value</param>
        /// <returns>The response from the HTTP request</returns>
        public async Task<HttpResponseMessage> ChangeColor(GoveeDevice device, Color color)
        {
            string payload = CreatePayload(device, new
            {
                name = "color",
                value = new
                {
                    r = color.R,
                    g = color.G,
                    b = color.B,
                }
            }); 

            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");

            return await MakeRequest("/devices/control", HttpMethod.Put, body);
        }

        /// <summary>
        /// Method to set device brightness
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <param name="brightness">The desired brightness value</param>
        /// <returns>The response from the HTTP request</returns>
        public async Task<HttpResponseMessage> ChangeBrightness(GoveeDevice device, int brightness)
        {
            string payload = CreatePayload(device, new
            {
                name = "brightness",
                value = brightness
            });

            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");

            return await MakeRequest("/devices/control", HttpMethod.Put, body);
        }

        /// <summary>
        /// Method to get device state
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <returns>The response from the HTTP request</returns>
        public async Task<DeviceState> GetDeviceState(GoveeDevice device)
        {
            string fullUrl = $"{_baseUrl}/devices/state?device={device.DeviceId}&model={device.Model}";

            var res = await _requestService.GetAsync(fullUrl, _headers);

            if (res.IsSuccessStatusCode) return await _responseService.DeserializeIntoDeviceState(res);
            else throw new HttpRequestException(HandleHttpError(res.StatusCode));
        }

        /// <summary>
        /// Overloaded helper method to create payloads that takes in a cmd parameter
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <param name="cmd">An object containing the commands to execute</param>
        /// <returns></returns>
        private static string CreatePayload(GoveeDevice device, object cmd)
        {
            string payload = $@"
            {{
                ""device"": ""{device.DeviceId}"",
                ""model"": ""{device.Model}"",
                ""cmd"": {JsonConvert.SerializeObject(cmd)}
            }}
            ";

            return payload;
        }

        /// <summary>
        /// Helper method to modularize code and prevent repetition
        /// </summary>
        /// <param name="endpoint">The target endpoint</param>
        /// <param name="method">The HTTP method</param>
        /// <param name="content">The HTTP payload</param>
        /// <returns>The response from the request</returns>
        private async Task<HttpResponseMessage> MakeRequest(string endpoint, HttpMethod method, HttpContent content)
        {
            string fullUrl = $"{_baseUrl}{endpoint}";

            var res = await _requestService.SendAsync(fullUrl, _headers, method, content);
            if (res.IsSuccessStatusCode) return res;
            else throw new HttpRequestException(HandleHttpError(res.StatusCode));
        }

        /// <summary>
        /// Helper method to generate a string based on the HTTP error code
        /// </summary>
        /// <param name="code">HTTP error code</param>
        /// <returns>A string specific to the error code</returns>
        private static string HandleHttpError(HttpStatusCode code)
        {
            string exceptionText = "Too many requests! Please wait 30 seconds.\n\n" +
                "The application can only make 60 requests per minute, anything above that will trigger this error.\n\n" +
                "Group tasks utilize even more requests, since each device in the group sends a separate request.";

            switch ((int)code)
            {
                case 403:
                    exceptionText = "403: Invalid API key. Please verify your API key is accurate in the settings.";
                    break;
                case 500:
                    exceptionText = "500: Internal server error. Please try again later.";
                    break;
                case 400:
                    exceptionText = "400: Invalid parameter detected.";
                    break;
                case 401:
                    exceptionText = "401: Invalid API key. Please verify your API key is accurate in the settings.";
                    break;
                default:
                    break;
            }

            return exceptionText;
        }

        /// <summary>
        /// Helper to update the API key
        /// </summary>
        /// <param name="newApiKey">New API key value</param>
        public void SetApiKey(string newApiKey)
        {
            _headers["Govee-API-Key"] = newApiKey;
        }
    }
}
