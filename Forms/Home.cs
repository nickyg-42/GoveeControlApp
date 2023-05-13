using System.Net;
using GoveeControl.Interfaces;
using GoveeControl.Models;
using Newtonsoft.Json.Linq;

namespace GoveeControl;

public partial class Home : Form
{
    private readonly IGoveeService _goveeService;
    private List<GoveeDevice> _devices = new();

    public Home(IGoveeService goveeService)
    {
        InitializeComponent();
        _goveeService = goveeService;
    }

    /// <summary>
    /// Method to setup data on form load
    /// </summary>
    /// <param name="sender">Default</param>
    /// <param name="e">Default</param>
    private async void Home_Load(object sender, EventArgs e)
    {
        // Get devices
        try
        {
            _devices = await GetDevices();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        // Display devices
        // TODO
    }

    /// <summary>
    /// Gets all devices for the user
    /// </summary>
    /// <returns>A list of type GoveeDevice representing all returned devices</returns>
    /// <exception cref="Exception">Throws an exception if the request fails</exception>
    private async Task<List<GoveeDevice>> GetDevices()
    {
        var devices = new List<GoveeDevice>();
        var res = await _goveeService.GetDevices();

        if (res.IsSuccessStatusCode) 
        { 
            string jsonString = await res.Content.ReadAsStringAsync();

            var jsonObject = JObject.Parse(jsonString);

            var parsedDevices = jsonObject["data"]!["devices"]!.ToArray();

            foreach (var device in parsedDevices)
            {
                string deviceModel = device["model"]?.ToString() ?? "";
                string deviceAddress = device["device"]?.ToString() ?? "";
                bool controllable = device["controllable"]?.ToObject<bool>() ?? false;
                bool retrievable = device["retrievable"]?.ToObject<bool>() ?? false;
                List<string> supportCmds = ((device["supportCmds"] as JArray)?.Select(s => s?.ToString()).ToList() ?? new List<string>()!)!;
                string deviceName = device["deviceName"]?.ToString() ?? "";

                devices.Add(new GoveeDevice(
                    deviceAddress,
                    deviceModel,
                    controllable,
                    retrievable,
                    supportCmds,
                    deviceName
                ));
            }

            return devices;
        }
        else
        {
            throw new Exception(HandleHttpError(res.StatusCode));
        }
    }

    /// <summary>
    /// Helper method to generate a string based on the HTTP error code
    /// </summary>
    /// <param name="code">HTTP error code</param>
    /// <returns>A string specific to the error code</returns>
    private static string HandleHttpError(HttpStatusCode code)
    {
        string exceptionText = "Unknown error occured";

        switch ((int)code)
        {
            case 403:
                exceptionText = "403: Invalid API key. Please verify your API key is accurate in the settings.";
                break;
            case 500:
                exceptionText = "500: Internal server error. Please try again later.";
                break;
            case 400:
                exceptionText = "400: Invalid parameter detected.";
                break;
            case 401:
                exceptionText = "401: Invalid API key. Please verify your API key is accurate in the settings.";
                break;
            default:
                break;
        }

        return exceptionText;
    }
}
