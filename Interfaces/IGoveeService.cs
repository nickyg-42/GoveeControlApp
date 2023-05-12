using GoveeControl.Models;

namespace GoveeControl.Interfaces
{
    public interface IGoveeService
    {
        Task<HttpResponseMessage> GetDevices();
        Task<HttpResponseMessage> GetDeviceState(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device);
        Task<HttpResponseMessage> SetDeviceColor(GoveeDevice device, double r, double g, double b);
        Task<HttpResponseMessage> SetDeviceBrightness(GoveeDevice device, double brightness);
        Task<List<HttpResponseMessage>> TurnAllDevicesOff(List<GoveeDevice> devices);
        Task<List<HttpResponseMessage>> TurnAllDevicesOn(List<GoveeDevice> devices);
    }
}
 