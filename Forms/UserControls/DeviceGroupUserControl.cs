using GoveeControl.Interfaces;
using GoveeControl.Json;
using GoveeControl.Models;

namespace GoveeControl.Forms.UserControls
{
    /// <summary>
    /// Custom UserControl to represent a Govee device
    /// </summary>
    public partial class DeviceGroupUserControl : UserControl
    {
        private readonly JsonHandler _jsonHandler = new();
        private readonly IGoveeService _goveeService;
        private DeviceGroup _group;
        private bool _on;

        public delegate void BrightnessSliderAdjustEventHandler(object sender, CustomEventArgs.BrightnessSliderEventArgs e);
        public delegate void PowerButtonToggleEventHandler(object sender, CustomEventArgs.PowerToggleEventArgs e);
        public delegate void ColorButtonClickEventHandler(object sender, CustomEventArgs.ColorButtonEventArgs e);

        public event EventHandler? TrashButtonClick;
        public event BrightnessSliderAdjustEventHandler? BrightnessSliderAdjust;
        public event PowerButtonToggleEventHandler? PowerButtonToggle;
        public event ColorButtonClickEventHandler? ColorButtonChange;

        public DeviceGroupUserControl(IGoveeService goveeService, DeviceGroup group, List<DeviceState> states)
        {
            InitializeComponent();
            _goveeService = goveeService;
            _group = group;

            GroupName.Text = _group.GroupName;
            DeviceCount.Text = _group.Devices.Count.ToString() + " devices";
            BrightnessSlider.Value = 50;

            _on = states.Count > 0 && states.All(state => state.PowerState == 1);
        }

        /// <summary>
        /// Event handler for button to adjust the color for all devices in group
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void ColorBtn_Click(object sender, EventArgs e)
        {
            ColorBtn.Enabled = false;

            try
            {
                ColorDialog colorDialog = new();
                colorDialog.FullOpen = true;
                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
                    await _goveeService.SetGroupColor(_group, color);
                    OnColorChange(color, _group.Devices);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ColorBtn.Enabled = true;
        }

        /// <summary>
        /// Event handler for button to toggle all device power states
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void PowerBtn_Click_1(object sender, EventArgs e)
        {
            PowerBtn.Enabled = false;

            try
            {
                if (_on)
                {
                    await _goveeService.TurnGroupOff(_group);
                }
                else
                {
                    await _goveeService.TurnGroupOn(_group);
                }

                OnPowerToggle(_on ? 0 : 1, _group.Devices);
                _on = !_on;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PowerBtn.Enabled = true;
        }

        /// <summary>
        /// Event handler for button to adjust brightness value of all devices
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void BrightnessSlider_MouseUp(object sender, EventArgs e)
        {
            BrightnessSlider.Enabled = false;

            try
            {
                if (_on)
                {
                    int newBrightness = BrightnessSlider.Value;
                    await _goveeService.SetGroupBrightness(_group, newBrightness);
                    OnBrightnessAdjust(newBrightness, _group.Devices);
                }
                else
                {
                    MessageBox.Show("Please turn all lights in group on to adjust brightness", "Error");
                    BrightnessSlider.Value = 50;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BrightnessSlider.Enabled = true;
        }

        /// <summary>
        /// Event handler to delete group
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void TrashBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _jsonHandler.DeleteGroup(_group.Id);
                OnTrashButtonClick();
            }
        }

        /// <summary>
        /// Passes event handler to parent
        /// </summary>
        protected virtual void OnTrashButtonClick()
        {
            TrashButtonClick?.Invoke(this, EventArgs.Empty);
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
