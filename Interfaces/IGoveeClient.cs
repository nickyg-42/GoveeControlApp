using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoveeControl.Services;

namespace GoveeControl.Interfaces
{
    public interface IGoveeClient
    {
        Task<HttpResponseMessage> TurnOn(string deviceId);
        Task<HttpResponseMessage> TurnOff(string deviceId);
        Task<HttpResponseMessage> ChangeBrightness(string deviceId, double brightness);
        Task<HttpResponseMessage> ChangeColor(string deviceId, double r, double g, double b);
    }
}
