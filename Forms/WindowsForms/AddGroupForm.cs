using System.Data;
using GoveeControl.Json;
using GoveeControl.Models;

namespace GoveeControl.Forms.WindowsForms
{
    public partial class AddGroupForm : Form
    {
        private readonly JsonHandler _jsonHandler = new();
        private readonly List<GoveeDevice> _devices;

        public AddGroupForm(List<GoveeDevice> devices)
        {
            InitializeComponent();
            _devices = devices;

            // dynamically display devices
            foreach (GoveeDevice device in _devices)
            {
                CheckBox tempBox = new()
                {
                    Text = device.DeviceName,
                    Name = device.DeviceId,
                    ForeColor = SystemColors.AppWorkspace,
                    AutoSize = true,
                };

                CheckBoxPanel.Controls.Add(tempBox);
            }
        }

        /// <summary>
        /// Event handler for add group button, validates input
        /// </summary>
        /// <param name="sender">Default</param>
        /// <param name="e">Default</param>
        private void AddGroupBtn_Click(object sender, EventArgs e)
        {
            bool isAtLeastOneChecked = false;
            List<GoveeDevice> groupDevices = new();

            // logic to check if fields filled out
            if (GroupNameText.Text.Trim().Length > 0)
            {
                // add devices to group
                foreach (Control control in CheckBoxPanel.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        isAtLeastOneChecked = true;

                        groupDevices.Add(_devices.Where(dev => dev.DeviceId == checkBox.Name).Single());
                    }
                }

                if (!isAtLeastOneChecked) MessageBox.Show("Please select 1 or more devices");
                else
                {
                    DeviceGroup newGroup = new(GroupNameText.Text, groupDevices);
                    _jsonHandler.WriteGroup(newGroup);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a name", "Error");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
