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
    }
}
