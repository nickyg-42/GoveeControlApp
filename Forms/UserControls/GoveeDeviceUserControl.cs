using System.Drawing;
using GoveeControl.Interfaces;
using GoveeControl.Models;

namespace GoveeControl.Forms.UserControls
{
    /// <summary>
    /// Custom UserControl to represent a Govee device
    /// </summary>
    public partial class GoveeDeviceUserControl : UserControl
    {
        private readonly IGoveeService _goveeService;
        private GoveeDevice _device;
        private DeviceState _state;

        public delegate void BrightnessSliderAdjustEventHandler(object sender, CustomEventArgs.BrightnessSliderEventArgs e);
        public delegate void PowerButtonToggleEventHandler(object sender, CustomEventArgs.PowerToggleEventArgs e);
        public delegate void ColorButtonClickEventHandler(object sender, CustomEventArgs.ColorButtonEventArgs e);

        public event BrightnessSliderAdjustEventHandler? BrightnessSliderAdjust;
        public event PowerButtonToggleEventHandler? PowerButtonToggle;
        public event ColorButtonClickEventHandler? ColorButtonChange;

        public GoveeDeviceUserControl(IGoveeService goveeService, GoveeDevice device, DeviceState state)
        {
            InitializeComponent();
            _goveeService = goveeService;
            _device = device;
            _state = state;
            deviceName.Text = _device.DeviceName;
            BrightnessSlider.Value = _state.Brightness;
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

        /// <summary>
        /// Changes the color of the selected device
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void ColorBtn_Click(object sender, EventArgs e)
        {
            ColorBtn.Enabled = false;

            if (_state.PowerState == 0)
            {
                MessageBox.Show("Please turn the device on first");
            }
            else
            {
                try
                {
                    ColorDialog colorDialog = new();
                    colorDialog.FullOpen = true;
                    DialogResult result = colorDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Color color = colorDialog.Color;
                        await _goveeService.SetDeviceColor(_device, color);
                        _state.Color = color;
                        OnColorChange(color, new List<GoveeDevice>() { _device });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ColorBtn.Enabled = true;
        }

        /// <summary>
        /// Toggles the device power state
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void PowerBtn_Click_1(object sender, EventArgs e)
        {
            PowerBtn.Enabled = false;

            if (_state.Online == false)
            {
                MessageBox.Show("Your device is offline, please enable LAN control");
            }
            else
            {
                try
                {
                    if (_state.PowerState == 0)
                    {
                        await _goveeService.TurnDeviceOn(_device);
                        _state.PowerState = 1;
                    }
                    else
                    {
                        await _goveeService.TurnDeviceOff(_device);
                        _state.PowerState = 0;
                    }

                    OnPowerToggle(_state.PowerState, new List<GoveeDevice>() { _device });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            PowerBtn.Enabled = true;
        }

        /// <summary>
        /// Adjusts the brightness of selected light
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void BrightnessSlider_MouseUp(object sender, EventArgs e)
        {
            BrightnessSlider.Enabled = false;

            if (_state.PowerState == 0)
            {
                MessageBox.Show("Please turn the device on first");
                BrightnessSlider.Value = _state.Brightness;
            }
            else
            {
                try
                {
                    int newBrightness = BrightnessSlider.Value;
                    await _goveeService.SetDeviceBrightness(_device, newBrightness);
                    _state.Brightness = newBrightness;
                    OnBrightnessAdjust(newBrightness, new List<GoveeDevice>() { _device });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            BrightnessSlider.Enabled = true;
        }

        /// <summary>
        /// Passes event handler to parent
        /// </summary>
        protected virtual void OnBrightnessAdjust(int brightness, List<GoveeDevice> devices)
        {
            CustomEventArgs.BrightnessSliderEventArgs args = new()
            {
                Brightness = brightness,
                Devices = devices
            };

            BrightnessSliderAdjust?.Invoke(this, args);
        }

        /// <summary>
        /// Passes event handler to parent
        /// </summary>
        protected virtual void OnColorChange(Color color, List<GoveeDevice> devices)
        {
            CustomEventArgs.ColorButtonEventArgs args = new()
            {
                Color = color,
                Devices = devices
            };

            ColorButtonChange?.Invoke(this, args);
        }

        /// <summary>
        /// Passes event handler to parent
        /// </summary>
        protected virtual void OnPowerToggle(int powerState, List<GoveeDevice> devices)
        {
            CustomEventArgs.PowerToggleEventArgs args = new()
            {
                PowerState = powerState,
                Devices = devices
            };

            PowerButtonToggle?.Invoke(this, args);
        }
    }
}
