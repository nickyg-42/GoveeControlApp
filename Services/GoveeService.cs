using System.Runtime.CompilerServices;
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
        /// Loops through the groups devices and calls the TurnDeviceOff method per device
        /// </summary>
        /// <param name="group">A DeviceGroup object</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> TurnMultipleDevicesOff(DeviceGroup group)
        {
            var tasks = group.Devices.Select(device => TurnDeviceOff(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        /// <summary>
        /// Loops through the groups devices and calls the TurnDeviceOn method per device
        /// </summary>
        /// <param name="group">A DeviceGroup object</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> TurnMultipleDevicesOn(DeviceGroup group)
        {
            var tasks = group.Devices.Select(device => TurnDeviceOn(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        /// <summary>
        /// Loops through the group devices and changes each brightness value
        /// </summary>
        /// <param name="group">DeviceGroup object</param>
        /// <param name="brightness">Integer brightness value</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> SetGroupBrightness(DeviceGroup group, int brightness)
        {
            var tasks = group.Devices.Select(device => SetDeviceBrightness(device, brightness)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        /// <summary>
        /// Loops through the group devices and changes each color value
        /// </summary>
        /// <param name="group">DeviceGroup object</param>
        /// <param name="color">Color value</param>
        /// <returns>A list of HTTP responses, one for each request</returns>
        public async Task<List<HttpResponseMessage>> SetGroupColor(DeviceGroup group, Color color)
        {
            var tasks = group.Devices.Select(device => SetDeviceColor(device, color)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        public void SetApiKey(string newApiKey)
        {
            _goveeClient.SetApiKey(newApiKey);
        }
    }
}
