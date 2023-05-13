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
        // Path to Settings.json
        string settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");

        // Initialize App
        ApplicationConfiguration.Initialize();

        string apiKey = GetJsonApiKey(settingsPath);

        // Check if API key exists
        if (string.IsNullOrEmpty(apiKey))
        {
            // If it does not, prompt user for key
            GetApiKey getApiKey = new();

            if (getApiKey.ShowDialog() == DialogResult.OK)
            {
                apiKey = getApiKey.GetApiKeyText();
                
                // Write key to json
                SetApiKey(apiKey, settingsPath);
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
        Application.Run(new Home(goveeService));
    }
    
    /// <summary>
    /// Helper to read the API key from json
    /// </summary>
    /// <returns>A string representation of the json API key</returns>
    private static string GetJsonApiKey(string path)
    {
        string jsonString = File.ReadAllText(path);
        JObject json = JObject.Parse(jsonString);
        
        return json["ApiKey"]!.ToString();
    }

    /// <summary>
    /// Helper to set the json API key to the desired string
    /// </summary>
    /// <param name="apiKey">The string representation of the new API key value</param>
    private static void SetApiKey(string apiKey, string path)
    {
        string jsonString = File.ReadAllText(path);
        JObject json = JObject.Parse(jsonString);

        json["ApiKey"] = apiKey;

        File.WriteAllText(path, json.ToString());
    }
}