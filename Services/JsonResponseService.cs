using GoveeControl.Interfaces;
using Newtonsoft.Json;
using GoveeControl.Models;
using Newtonsoft.Json.Linq;

namespace GoveeControl.Services
{
    public class JsonResponseService : IResponseService
    {
        /// <summary>
        /// Generic parser, unused as of now
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="response">HTTP response message to parse</param>
        /// <returns>Generic return</returns>
        public async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            string resData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resData)!;
        }

        /// <summary>
        /// Deserializes JSON into a list of type GoveeDevice
        /// </summary>
        /// <param name="response">HTTP response message to parse</param>
        /// <returns>A list of type GoveeDevice</returns>
        public async Task<List<GoveeDevice>> DeserializeIntoDeviceList(HttpResponseMessage response)
        {
            List<GoveeDevice> devices = new();
            string resData = await response.Content.ReadAsStringAsync();

            JObject resObject = JObject.Parse(resData);
            JArray deviceObjects = (JArray)resObject["data"]!["devices"]!;

            foreach (var device in deviceObjects)
            {
                string deviceModel = device["model"]?.ToString() ?? "";
                string deviceAddress = device["device"]?.ToString() ?? "";
                bool controllable = device["controllable"]?.ToObject<bool>() ?? false;
                bool retrievable = device["retrievable"]?.ToObject<bool>() ?? false;
                List<string> supportCmds = ((device["supportCmds"] as JArray)?.Select(s => s?.ToString()).ToList() ?? new List<string>()!)!;
                string deviceName = device["deviceName"]?.ToString() ?? "";

                devices.Add(new GoveeDevice(
                    deviceAddress,
                    deviceModel,
                    controllable,
                    retrievable,
                    supportCmds,
                    deviceName
                ));
            }

            return devices;
        }

        /// <summary>
        /// Deserializes JSON response into an object of DeviceState
        /// </summary>
        /// <param name="response">HTTP response message to parse</param>
        /// <returns>A DeviceState object</returns>
        public async Task<DeviceState> DeserializeIntoDeviceState(HttpResponseMessage response)
        {
            string resData = await response.Content.ReadAsStringAsync();

            JObject resObject = JObject.Parse(resData);
            JArray properties = (JArray)resObject["data"]!["properties"]!;

            bool online = !properties["online"]!.ToString().Equals("false");
            int powerState = properties["powerState"]!.ToString().Equals("off") ? 0 : 1;
            int brightness = properties["brightness"]!.ToObject<int>();
            int r = properties["color"]!["r"]!.ToObject<int>();
            int g = properties["color"]!["g"]!.ToObject<int>();
            int b = properties["color"]!["b"]!.ToObject<int>();
            Color color = Color.FromArgb(r, g, b);

            return new DeviceState(online, powerState, brightness, color);
        }
    }
}
