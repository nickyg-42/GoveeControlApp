using GoveeControl.Models;

namespace GoveeControl.Interfaces
{
    public interface IGoveeClient
    {
        Task<List<GoveeDevice>> GetDevices();
        Task<HttpResponseMessage> TurnDeviceOff(GoveeDevice device);
        Task<HttpResponseMessage> TurnDeviceOn(GoveeDevice device);
        Task<HttpResponseMessage> ChangeColor(GoveeDevice device, Color color);
        Task<HttpResponseMessage> ChangeBrightness(GoveeDevice device, int brightness);
        Task<DeviceState> GetDeviceState(GoveeDevice device);
        void SetApiKey(string newApiKey);
    }
}
