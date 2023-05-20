using GoveeControl.Models;

namespace GoveeControl.Interfaces
{
    public interface IGoveeService
    {
        Task<List<GoveeDevice>> GetDevices();
        Task<DeviceState> GetDeviceState(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device);
        Task<HttpResponseMessage> SetDeviceColor(GoveeDevice device, Color color);
        Task<HttpResponseMessage> SetDeviceBrightness(GoveeDevice device, int brightness);
        Task<List<HttpResponseMessage>> TurnGroupOff(DeviceGroup group);
        Task<List<HttpResponseMessage>> TurnGroupOn(DeviceGroup group);
        Task<List<HttpResponseMessage>> SetGroupBrightness(DeviceGroup group, int brightness);
        Task<List<HttpResponseMessage>> SetGroupColor(DeviceGroup group, Color color);
        void SetApiKey(string newApiKey);
    }
}
 