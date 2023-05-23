using GoveeControl.Forms.UserControls;
using GoveeControl.Interfaces;
using GoveeControl.Json;
using GoveeControl.Models;

namespace GoveeControl.Forms.WindowsForms
{
    public partial class Home : Form
    {
        private readonly IGoveeService _goveeService;
        private List<GoveeDevice> _devices = new();
        private List<DeviceGroup> _groups = new();
        private readonly JsonHandler _jsonHandler = new();
        private Dictionary<string, DeviceState> _deviceStatePairs = new();

        public Home(IGoveeService goveeService)
        {
            InitializeComponent();
            _goveeService = goveeService;
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            // start out with devices selected
            DevicesLabel.Text = "\u2022 Devices";
            DevicesLabel.Font = new Font(DevicesLabel.Font, FontStyle.Bold);
            LocationLabel.Text = "Devices";

            GroupControlPanel.Visible = false;
            DevicesPanel.Visible = true;

            await LoadDevices();
            LoadGroups();
        }

        /// <summary>
        /// Event handler to handle button press in user control
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void AddGroupUserControl_ButtonClick(object sender, EventArgs e)
        {
            // Prompt user to create group
            AddGroupForm addPopup = new(_devices);
            addPopup.StartPosition = FormStartPosition.CenterParent;
            addPopup.ShowDialog();

            // Refresh groups after
            LoadGroups();
        }

        /// <summary>
        /// Helper to refresh parent window upon deletion of group
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void DeviceGroupUserControl_TrashButtonClick(object sender, EventArgs e)
        {
            LoadGroups();
        }

        /// <summary>
        /// Event handler to adjust brightness state
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void DeviceGroupUserControl_BrightnessSliderAdjust(object sender, CustomEventArgs.BrightnessSliderEventArgs e)
        {
            var devices = GetDeviceStates(e.Group.Devices);

            foreach (string deviceId in devices)
            {
                _deviceStatePairs[deviceId].Brightness = e.Brightness;
            }
        }

        /// <summary>
        /// Event handler to adjust power state
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void DeviceGroupUserControl_PowerButtonToggle(object sender, CustomEventArgs.PowerToggleEventArgs e)
        {
            var devices = GetDeviceStates(e.Group.Devices);

            foreach (string deviceId in devices)
            {
                _deviceStatePairs[deviceId].PowerState = e.PowerState;
            }
        }

        /// <summary>
        /// Event handler to adjust color state
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void DeviceGroupUserControl_ColorButtonChange(object sender, CustomEventArgs.ColorButtonEventArgs e)
        {
            var devices = GetDeviceStates(e.Group.Devices);

            foreach (string deviceId in devices)
            {
                _deviceStatePairs[deviceId].Color = e.Color;
            }
        }

        /// <summary>
        /// Helper to reduce repetition
        /// </summary>
        /// <param name="devices">Default</param>
        /// <returns>Default</returns>
        private List<string> GetDeviceStates(List<GoveeDevice> devices)
        {
            return devices
                .Select(dev => dev.DeviceId)
                .Where(_deviceStatePairs.ContainsKey)
                .ToList();
        }

        /// <summary>
        /// Helper to load devices, extracted for reusability
        /// </summary>
        private async Task LoadDevices()
        {
            DevicesPanel.Controls.Clear();

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
            foreach (var device in _devices)
            {
                try
                {
                    // Get current device state
                    DeviceState currState = await _goveeService.GetDeviceState(device);

                    // Add device and its state to dictionary (if not duplicate)
                    _deviceStatePairs.TryAdd(device.DeviceId, currState);

                    // Create UI element
                    GoveeDeviceUserControl deviceUserControl = new(_goveeService, device, currState);
                    deviceUserControl.Margin = new Padding(0, 10, 20, 10);

                    DevicesPanel.Controls.Add(deviceUserControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to get device state");
                    return;
                }
            }
        }

        /// <summary>
        /// Helper to load groups, reusable
        /// </summary>
        private void LoadGroups()
        {
            GroupControlPanel.Controls.Clear();

            AddGroupUserControl addOption = new();
            addOption.ButtonClick += AddGroupUserControl_ButtonClick!;
            addOption.Margin = new Padding(0, 10, 20, 10);

            // Get groups
            _groups = _jsonHandler.ReadGroups();

            // Display groups (if any)
            if (_groups != null && _groups.Count > 0)
            {
                foreach (var group in _groups)
                {
                    List<string> deviceIds = group.Devices.Select(dev => dev.DeviceId).ToList();

                    List<DeviceState> states = _deviceStatePairs
                        .Where(devPair => deviceIds.Contains(devPair.Key))
                        .Select(devPair => devPair.Value)
                        .ToList();

                    DeviceGroupUserControl deviceGroup = new(_goveeService, group, states);
                    deviceGroup.Margin = new Padding(0, 10, 20, 10);
                    deviceGroup.TrashButtonClick += DeviceGroupUserControl_TrashButtonClick!;
                    deviceGroup.PowerButtonToggle += DeviceGroupUserControl_PowerButtonToggle;
                    deviceGroup.BrightnessSliderAdjust += DeviceGroupUserControl_BrightnessSliderAdjust;
                    deviceGroup.ColorButtonChange += DeviceGroupUserControl_ColorButtonChange;

                    GroupControlPanel.Controls.Add(deviceGroup);
                }
            }

            GroupControlPanel.Controls.Add(addOption);
            return;
        }

        /// <summary>
        /// Redirects to the settings Form and hides current Form
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            Settings settingsPage = new(_goveeService);
            settingsPage.StartPosition = FormStartPosition.Manual;
            settingsPage.Location = new Point(this.Location.X + (this.Width - settingsPage.Width) / 2, this.Location.Y + (this.Height - settingsPage.Height) / 2);
            settingsPage.Show();
            this.Hide();
        }

        /// <summary>
        /// Method to stop app upon form closure
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Helper to load devices and update GUI
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void DevicesLabel_Click(object sender, EventArgs e)
        {
            GroupControlPanel.Visible = false;
            DevicesPanel.Visible = true;
            LocationLabel.Text = "Devices";

            DevicesLabel.Text = "\u2022 Devices";
            DevicesLabel.Font = new Font(DevicesLabel.Font, FontStyle.Bold);

            GroupsLabel.Text = "   Groups";
            GroupsLabel.Font = new Font(GroupsLabel.Font, FontStyle.Regular);
        }

        /// <summary>
        /// Helper to load groups and update GUI
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void GroupsLabel_Click(object sender, EventArgs e)
        {
            DevicesPanel.Visible = false;
            GroupControlPanel.Visible = true;
            LocationLabel.Text = "Groups";

            GroupsLabel.Text = "\u2022 Groups";
            GroupsLabel.Font = new Font(GroupsLabel.Font, FontStyle.Bold);

            DevicesLabel.Text = "   Devices";
            DevicesLabel.Font = new Font(DevicesLabel.Font, FontStyle.Regular);
        }

        /// <summary>
        /// Button to reload devices, states, and groups
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshBtn.Enabled = false;

            await LoadDevices();
            LoadGroups();

            RefreshBtn.Enabled = true;
        }
    }
}
