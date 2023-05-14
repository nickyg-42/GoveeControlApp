using GoveeControl.Interfaces;
using GoveeControl.Models;
using GoveeControl.Services;

namespace GoveeControl.Forms;

public partial class GoveeDeviceUserControl : UserControl
{
    private readonly IGoveeService _goveeService;
    private GoveeDevice _device;
    private DeviceState _state;

    public GoveeDeviceUserControl(GoveeService goveeService, GoveeDevice device, DeviceState state)
    {
        InitializeComponent();
        _goveeService = goveeService;
        _device = device;
        _state = state;
        deviceName.Text = _device.DeviceName;
        brightnessSlider.Value = _state.Brightness;
    }

    public GoveeDevice Device
    {
        get { return _device; }
        set { _device = value; }
    }

    public DeviceState State
    {
        get { return _state; }
        set { _state = value; }
    }

    private async void PowerBtn_Click(object sender, EventArgs e)
    {
        if (_state.PowerState == 0)
        {
            await _goveeService.TurnDeviceOn(_device);
        }
        else
        {
            await _goveeService.TurnDeviceOff(_device);
        }
    }
}
