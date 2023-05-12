using GoveeControl.Models;

namespace GoveeControl.Interfaces
{
    public interface IGoveeClient
    {
        Task<HttpResponseMessage> GetDevices();
        Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device);
        Task<HttpResponseMessage> ChangeColor(GoveeDevice device, double r, double g, double b);
        Task<HttpResponseMessage> ChangeBrightness(GoveeDevice device, double brightness);
        Task<HttpResponseMessage> GetDeviceState(GoveeDevice device);
    }
}
