namespace GoveeControl.Interfaces
{
    public interface IGoveeService
    {
        Task<HttpResponseMessage> GetDevices();
        Task<HttpResponseMessage> GetDeviceState(string deviceId);
        Task<HttpResponseMessage> TurnDeviceOn(string deviceId);
        Task<HttpResponseMessage> TurnDeviceOff(string deviceId);
        Task<HttpResponseMessage> SetDeviceColor(string deviceId, Color color);
        Task<HttpResponseMessage> SetDeviceBrightness(string deviceId, int brightness);
        Task<HttpResponseMessage> TurnAllDevicesOff(List<string> deviceIds);
        Task<HttpResponseMessage> TurnAllDevicesOn(List<string> deviceIds);
    }
}
 