using GoveeControl.Services;

namespace GoveeControl;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        // Create services
        var goveeHttpClient = GoveeHttpClient.Instance;
        var requestService = new RequestService(goveeHttpClient);
        var jsonRespoonseService = new JsonResponseService();
        var goveeClient = new GoveeClient(requestService, jsonRespoonseService);
        var goveeService = new GoveeService(goveeClient);

        ApplicationConfiguration.Initialize();
        Application.Run(new Home(goveeService));
    }    
}