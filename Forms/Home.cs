using GoveeControl.Interfaces;
using GoveeControl.Models;

namespace GoveeControl;

public partial class Home : Form
{
    private readonly IGoveeService _goveeService;

    public Home(IGoveeService goveeService)
    {
        InitializeComponent();
        _goveeService = goveeService;
    }

    private async void Button1_Click_1(object sender, EventArgs e)
    {
        GoveeDevice device = new("3A:9D:C3:34:38:39:16:76", "H6056", true, true, new List<string> { string.Empty });
        var result = await _goveeService.TurnDeviceOn(device);
        MessageBox.Show(result.ToString());
    }

    private async void Button2_Click(object sender, EventArgs e)
    {
        GoveeDevice device2 = new("3A:9D:C3:34:38:39:16:76", "H6056", true, true, new List<string> { string.Empty });
        var result2 = await _goveeService.TurnDeviceOff(device2);
        MessageBox.Show(result2.ToString());
    }
}
