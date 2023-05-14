using GoveeControl.Interfaces;
using GoveeControl.Models;

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
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Failed to get devices");
            return;
        }

        // Display devices
        // TODO
    }
}
