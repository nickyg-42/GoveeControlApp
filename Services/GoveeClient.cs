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
            _headers = new Dictionary<string, string>
            {
                // unsure why this causes an error as of now commenting it works
                //{ "Content-Type", "application/json" },
                { "Govee-API-Key", apiKey },
            };
        }

        /// <summary>
        /// Method to retrieve all devices
        /// </summary>
        /// <returns>A list of all devices</returns>
        public async Task<HttpResponseMessage> GetDevices()
        {
            string fullUrl = $"{_baseUrl}/devices";

            return await _requestService.GetAsync(fullUrl, _headers);
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
        public async Task<HttpResponseMessage> ChangeColor(GoveeDevice device, double rVal, double gVal, double bVal)
        {
            // r, g, and b can be 0-255
            string payload = CreatePayload(device, new
            {
                name = "color",
                value = new
                {
                    r = rVal,
                    g = gVal,
                    b = bVal,
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
        public async Task<HttpResponseMessage> ChangeBrightness(GoveeDevice device, double brightness)
        {
            // brightness can be 0-100
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
        public async Task<HttpResponseMessage> GetDeviceState(GoveeDevice device)
        {
            string payload = CreatePayload(device);

            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");

            return await MakeRequest("/devices/state", HttpMethod.Put, body);
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
        /// Helper method to create payloads
        /// </summary>
        /// <param name="device">The Govee device object</param>
        /// <returns>The created payload as a string</returns>
        private static string CreatePayload(GoveeDevice device)
        {
            string payload = $@"
            {{
                ""device"": ""{device.DeviceId}"",
                ""model"": ""{device.Model}""
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

            return await _requestService.SendAsync(fullUrl, _headers, method, content);
        }
    }
}
