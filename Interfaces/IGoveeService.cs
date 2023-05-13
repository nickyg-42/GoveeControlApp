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
        Task<List<HttpResponseMessage>> TurnAllDevicesOff(List<GoveeDevice> devices);
        Task<List<HttpResponseMessage>> TurnAllDevicesOn(List<GoveeDevice> devices);
    }
}
 