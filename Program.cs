using GoveeControl.Services;
using GoveeControl.Forms.WindowsForms;
using GoveeControl.Json;

namespace GoveeControl;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        // Create JSON Handler object
        JsonHandler jsonHandler = new();

        // Initialize App
        ApplicationConfiguration.Initialize();

        string apiKey = jsonHandler.ReadValue<string>("ApiKey");

        // Check if API key exists
        if (string.IsNullOrEmpty(apiKey))
        {
            // If it does not, prompt user for key
            GetApiKey getApiKey = new();

            if (getApiKey.ShowDialog() == DialogResult.OK)
            {
                apiKey = getApiKey.GetApiKeyText();

                // Write key to json
                jsonHandler.WriteValue("ApiKey", apiKey);
            }
            else
            {
                Application.Exit();
                return;
            }
        }

        // Create services
        var goveeHttpClient = GoveeHttpClient.Instance;
        var requestService = new RequestService(goveeHttpClient);
        var jsonResponseService = new JsonResponseService();
        var goveeClient = new GoveeClient(requestService, jsonResponseService, apiKey);
        var goveeService = new GoveeService(goveeClient);

        // Start main app
        Home home = new(goveeService);
        Application.Run(home);
    }
}