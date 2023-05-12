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
        // TODO: Get API KEY from user
        string apiKey = "86a3523d-fb06-4d9e-b0c0-2ffb77d1f749";

        // Create services
        var goveeHttpClient = GoveeHttpClient.Instance;
        var requestService = new RequestService(goveeHttpClient);
        var jsonResponseService = new JsonResponseService();
        var goveeClient = new GoveeClient(requestService, jsonResponseService, apiKey);
        var goveeService = new GoveeService(goveeClient);

        ApplicationConfiguration.Initialize();
        Application.Run(new Home(goveeService));
    }    
}