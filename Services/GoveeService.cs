using System.Reflection;
using GoveeControl.Interfaces;

namespace GoveeControl.Services
{
    public class GoveeService : IGoveeService
    {
        private readonly IGoveeClient _goveeClient;

        public GoveeService(IGoveeClient goveeClient) 
        {
            _goveeClient = goveeClient;
        }

        public async Task<HttpResponseMessage> GetDevices()
        {
            return await _goveeClient.GetDevices();
        }

        public async Task<HttpResponseMessage> GetDeviceState(string deviceId, string model)
        {
            return await _goveeClient.GetDeviceState(deviceId, model);
        }

        public async Task<HttpResponseMessage> TurnDeviceOn(string deviceId, string model)
        {
            return await _goveeClient.TurnDeviceOn(deviceId, model);
        }

        public async Task<HttpResponseMessage> TurnDeviceOff(string deviceId, string model)
        {
            return await _goveeClient.TurnDeviceOn(deviceId, model);
        }

        public async Task<HttpResponseMessage> SetDeviceColor(string deviceId, double r, double g, double b, string model)
        {
            return await _goveeClient.ChangeColor(deviceId, model, r, g, b);
        }

        public async Task<HttpResponseMessage> SetDeviceBrightness(string deviceId, int brightness, string model)
        {
            return await _goveeClient.ChangeBrightness(deviceId, model, brightness);
        }

        public async void TurnAllDevicesOff(Dictionary<string, string> deviceIdAndModelPairs)
        {
            foreach (var device in deviceIdAndModelPairs)
            {
                await _goveeClient.TurnDeviceOff(device.Key, device.Value);
            }
        }

        public async void TurnAllDevicesOn(Dictionary<string, string> deviceIdAndModelPairs)
        {
            foreach (var device in deviceIdAndModelPairs)
            {
                await _goveeClient.TurnDeviceOn(device.Key, device.Value);
            }
        }
    }
}
