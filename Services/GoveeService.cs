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

        public async Task<HttpResponseMessage> GetDevices()
        {
            return await _goveeClient.GetDevices();
        }

        public async Task<HttpResponseMessage> GetDeviceState(GoveeDevice device)
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

        public async Task<HttpResponseMessage> SetDeviceColor(GoveeDevice device, double r, double g, double b)
        {
            return await _goveeClient.ChangeColor(device, r, g, b);
        }

        public async Task<HttpResponseMessage> SetDeviceBrightness(GoveeDevice device, double brightness)
        {
            return await _goveeClient.ChangeBrightness(device, brightness);
        }

        public async Task<List<HttpResponseMessage>> TurnAllDevicesOff(List<GoveeDevice> devices)
        {
            var tasks = devices.Select(device => _goveeClient.TurnDeviceOff(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }

        public async Task<List<HttpResponseMessage>> TurnAllDevicesOn(List<GoveeDevice> devices)
        {
            var tasks = devices.Select(device => _goveeClient.TurnDeviceOn(device)).ToList();
            await Task.WhenAll(tasks);
            return tasks.Select(task => task.Result).ToList();
        }
    }
}
