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

            bool online = !properties[0]["online"]!.ToString().Equals("false");
            int powerState = properties[1]["powerState"]!.ToString().Equals("off") ? 0 : 1;
            int brightness = (int)properties[2]!["brightness"]!;

            Color color;

            try
            {
                int r = (int)properties[3]!["color"]!["r"]!;
                int g = (int)properties[3]!["color"]!["g"]!;
                int b = (int)properties[3]!["color"]!["b"]!;
                color = Color.FromArgb(r, g, b);
            }
            catch (Exception ex)
            {
                color = Color.White;
            }
            
            return new DeviceState(online, powerState, brightness, color);
        }
    }
}
