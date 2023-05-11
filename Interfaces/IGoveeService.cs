using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoveeControl.Services;

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
        Task<HttpResponseMessage> SetDevicePowerState(string deviceId, bool isOn);
    }

}
