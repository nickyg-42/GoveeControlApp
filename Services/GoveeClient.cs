using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoveeControl.Interfaces;

namespace GoveeControl.Services
{
    public class GoveeClient : IGoveeClient
    {
        private readonly IRequestService _requestService;
        private readonly IResponseService _responseService;

        public GoveeClient(IRequestService requestService, IResponseService responseService) 
        { 
            _requestService = requestService;
            _responseService = responseService;
        }

        public Task<HttpResponseMessage> ChangeBrightness(string deviceId, double brightness)
        {
            // make request to govee api
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ChangeColor(string deviceId, double r, double g, double b)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnOff(string deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> TurnOn(string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
