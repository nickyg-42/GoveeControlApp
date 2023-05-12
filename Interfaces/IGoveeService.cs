namespace GoveeControl.Interfaces
{
    public interface IGoveeService
    {
        Task<HttpResponseMessage> GetDevices();
        Task<HttpResponseMessage> GetDeviceState(string deviceId, string model);
        Task<HttpResponseMessage> TurnDeviceOn(string deviceId, string model);
        Task<HttpResponseMessage> TurnDeviceOff(string deviceId, string model);
        Task<HttpResponseMessage> SetDeviceColor(string deviceId, double r, double g, double b, string model);
        Task<HttpResponseMessage> SetDeviceBrightness(string deviceId, int brightness, string model);
        Task<HttpResponseMessage> TurnAllDevicesOff(Dictionary<string, string> deviceIdAndModelPairs);
        Task<HttpResponseMessage> TurnAllDevicesOn(Dictionary<string, string> deviceIdAndModelPairs);
    }
}
 