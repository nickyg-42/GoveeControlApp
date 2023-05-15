using GoveeControl.Interfaces;
using GoveeControl.Models;

namespace GoveeControl.Services
{
    public class GoveeService : IGoveeService
    {
        private readonly IGoveeClient _goveeClient;

        public GoveeService(IGoveeClient goveeClient) 
        {
            _goveeClient = goveeClient;
        }

        public async Task<List<GoveeDevice>> GetDevices()
        {
            return await _goveeClient.GetDevices();
        }

        public async Task<DeviceState> GetDeviceState(GoveeDevice device)
        {
            return await _goveeClient.GetDeviceState(device);
        }

        public async Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device)
        {
            return await _goveeClient.TurnDeviceOn(device);
        }

        public async Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device)
        {
            return await _goveeClient.TurnDeviceOff(device);
        }

        public async Task<HttpResponseMessage> SetDeviceColor(GoveeDevice device, Color color)
        {
            return await _goveeClient.ChangeColor(device, color);
        }

        public async Task<HttpResponseMessage> SetDeviceBrightness(GoveeDevice device, int brightness)
        {
            return await _goveeClient.ChangeBrightness(device, brightness);
        }

        /// <summary>
        /// Loops through the list and calls the TurnDeviceOff method per device
        /// </summary>
        /// <param name="devices">A list of type GoveeDevice</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> TurnAllDevicesOff(List<GoveeDevice> devices)
        {
            var tasks = devices.Select(device => _goveeClient.TurnDeviceOff(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        /// <summary>
        /// Loops through the list and calls the TurnDeviceOn method per device
        /// </summary>
        /// <param name="devices">A list of type GoveeDevice</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> TurnAllDevicesOn(List<GoveeDevice> devices)
        {
            var tasks = devices.Select(device => _goveeClient.TurnDeviceOn(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        public void SetApiKey(string newApiKey)
        {
            _goveeClient.SetApiKey(newApiKey);
        }
    }
}
