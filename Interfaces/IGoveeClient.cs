namespace GoveeControl.Interfaces
{
    public interface IGoveeClient
    {
        Task<HttpResponseMessage> GetDevices();
        Task<HttpResponseMessage> TurnDeviceOff(string deviceId, string model);
        Task<HttpResponseMessage> TurnDeviceOn(string deviceId, string model);
        Task<HttpResponseMessage> ChangeColor(string deviceId, string model, double r, double g, double b);
        Task<HttpResponseMessage> ChangeBrightness(string deviceId, string model, double brightness);
        Task<HttpResponseMessage> GetDeviceState(string deviceId, string model);
    }
}
