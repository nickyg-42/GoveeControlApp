using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GoveeControl.Interfaces;
using Newtonsoft.Json;

namespace GoveeControl.Services
{
    public class JsonResponseService : IResponseService
    {
        public async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            string resData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resData)!;
        }
    }
}
