namespace GoveeControl.Models
{
    public class GoveeDevice
    {
        private string _deviceId;
        private string _model;
        private bool _controllable;
        private bool _retrievable;
        private List<string> _supportCmds;
        private string _deviceName;

        public GoveeDevice(string deviceId, string model, bool controllable, bool retrievable, List<string> supportCmds, string deviceName)
        {
            _deviceId = deviceId;
            _model = model;
            _controllable = controllable;
            _retrievable = retrievable;
            _supportCmds = supportCmds;
            _deviceName = deviceName;
        }

        public GoveeDevice() 
        {
            _deviceId = string.Empty;
            _model = string.Empty;
            _controllable = false;
            _retrievable = false;
            _supportCmds = new();
            _deviceName = string.Empty;
        }

        public string DeviceId 
        { 
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public string Model
        { 
            get { return _model; } 
            set {  _model = value; } 
        }

        public bool Controllable
        { 
            get { return _controllable; } 
            set { _controllable = value; } 
        }

        public bool Retrievable
        {
            get { return _retrievable; }
            set { _retrievable = value; }
        }

        public List<string> SupportCmd
        { 
            get { return _supportCmds; }
            set { _supportCmds = value; } 
        }

        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }
    }
}
