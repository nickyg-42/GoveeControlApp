using GoveeControl.Services;
using Newtonsoft.Json.Linq;
using GoveeControl.Forms;

namespace GoveeControl;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        ApplicationConfiguration.Initialize();

        string apiKey = GetJsonApiKey();

        if (string.IsNullOrEmpty(apiKey))
        {
            GetApiKey getApiKey = new();

            if (getApiKey.ShowDialog() == DialogResult.OK)
            {
                apiKey = getApiKey.GetApiKeyText();
                
                SetApiKey(apiKey);
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

        Application.Run(new Home(goveeService));
    }
    
    /// <summary>
    /// Helper to read the API key from json
    /// </summary>
    /// <returns>A string representation of the json API key</returns>
    private static string GetJsonApiKey()
    {
        string jsonString = File.ReadAllText("../../../Settings.json");
        JObject json = JObject.Parse(jsonString);
        
        return json["ApiKey"]!.ToString();
    }

    /// <summary>
    /// Helper to set the json API key to the desired string
    /// </summary>
    /// <param name="apiKey">The string representation of the new API key value</param>
    private static void SetApiKey(string apiKey)
    {
        string jsonString = File.ReadAllText("../../../Settings.json");
        JObject json = JObject.Parse(jsonString);

        json["ApiKey"] = apiKey;

        File.WriteAllText("../../../Settings.json", json.ToString());
    }
}