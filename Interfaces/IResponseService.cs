using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoveeControl.Interfaces
{
    public interface IResponseService
    {
        Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response);
    }
}
