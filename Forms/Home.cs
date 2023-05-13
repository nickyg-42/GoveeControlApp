using System.Net;
using GoveeControl.Interfaces;
using GoveeControl.Models;
using Newtonsoft.Json.Linq;
using System.Drawing;

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
            _devices = await _goveeService.GetDevices();
            int x = 5;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        // Display devices
        // TODO
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
