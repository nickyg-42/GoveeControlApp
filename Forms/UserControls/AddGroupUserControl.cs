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
        private GoveeDevice _device;
        private DeviceState _state;

        public AddGroupUserControl(IGoveeService goveeService, GoveeDevice device, DeviceState state)
        {
            InitializeComponent();
            _goveeService = goveeService;
            _device = device;
            _state = state;
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

        public void AddBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
