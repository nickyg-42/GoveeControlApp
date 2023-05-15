using GoveeControl.Forms.UserControls;
using GoveeControl.Interfaces;
using GoveeControl.Models;

namespace GoveeControl.Forms.WindowsForms
{
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
            foreach (var device in _devices)
            {
                try
                {
                    // Get current device state
                    DeviceState currState = await _goveeService.GetDeviceState(device);

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
    }
}
