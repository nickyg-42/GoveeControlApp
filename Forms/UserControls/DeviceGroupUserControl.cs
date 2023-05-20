using GoveeControl.Interfaces;
using GoveeControl.Json;
using GoveeControl.Models;
using static System.Windows.Forms.AxHost;

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
        private bool _on = false;
        public event EventHandler? ButtonClick;

        public DeviceGroupUserControl(IGoveeService goveeService, DeviceGroup group)
        {
            InitializeComponent();
            _goveeService = goveeService;
            _group = group;

            GroupName.Text = _group.GroupName;
            DeviceCount.Text = _group.Devices.Count.ToString() + " devices";
            BrightnessSlider.Value = 50;
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
                int newBrightness = BrightnessSlider.Value;
                await _goveeService.SetGroupBrightness(_group, newBrightness);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BrightnessSlider.Enabled = true;

            // TODO ADD CATCH ONLY WORK IF ALL LIGHTS IN GROUP ON
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
                OnButtonClick();
            }            
        }

        /// <summary>
        /// Passes event handler to parent
        /// </summary>
        protected virtual void OnButtonClick()
        {
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
