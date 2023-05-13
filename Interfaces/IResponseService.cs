using GoveeControl.Models;

namespace GoveeControl.Interfaces
{
    public interface IResponseService
    {
        Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response);
        Task<List<GoveeDevice>> DeserializeIntoDeviceList(HttpResponseMessage response);
        Task<DeviceState> DeserializeIntoDeviceState(HttpResponseMessage response);
    }
}
