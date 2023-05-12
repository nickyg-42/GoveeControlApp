namespace GoveeControl.Interfaces
{
    public interface IResponseService
    {
        Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response);
    }
}
