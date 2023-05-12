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

        public Task<HttpResponseMessage> GetDevices()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetDeviceState(string deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnDeviceOn(string deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnDeviceOff(string deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SetDeviceColor(string deviceId, Color color)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> SetDeviceBrightness(string deviceId, int brightness)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnAllDevicesOff(List<string> deviceIds)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnAllDevicesOn(List<string> deviceIds)
        {
            throw new NotImplementedException();
        }
    }
}
