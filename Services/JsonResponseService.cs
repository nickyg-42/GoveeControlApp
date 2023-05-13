using GoveeControl.Interfaces;
using Newtonsoft.Json;
using GoveeControl.Models;
using Newtonsoft.Json.Linq;

namespace GoveeControl.Services
{
    public class JsonResponseService : IResponseService
    {
        public async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            string resData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resData)!;
        }

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
