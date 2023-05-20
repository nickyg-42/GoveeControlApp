using GoveeControl.Interfaces;
using GoveeControl.Models;

namespace GoveeControl.Forms.UserControls
{
    /// <summary>
    /// Custom UserControl to represent a Govee device
    /// </summary>
    public partial class AddGroupUserControl : UserControl
    {
        private readonly IGoveeService _goveeService;

        public AddGroupUserControl(IGoveeService goveeService)
        {
            InitializeComponent();
            _goveeService = goveeService;
        }

        public void AddBtn_Click(object sender, EventArgs e)
        {
            // Create popup with checkboxes to select devices
            // then add devices to group object
            // then add group to appropriate display
        }
    }
}
