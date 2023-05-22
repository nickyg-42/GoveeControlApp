using GoveeControl.Json;

namespace GoveeControl.Models
{
    public class DeviceGroup
    {
        private int _id;
        private string _groupName;
        private List<GoveeDevice> _devices;
        private readonly JsonHandler _jsonHandler = new();

        public DeviceGroup(string groupName, List<GoveeDevice> devices)
        {
            _id = _jsonHandler.ReadValue<int>("CurrentId");
            _jsonHandler.WriteValue("CurrentId", _id+1);
            _groupName = groupName;
            _devices = devices;
        }

        public DeviceGroup()
        {
            _id = -1;
            _groupName = string.Empty;
            _devices = new List<GoveeDevice>();
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public List<GoveeDevice> Devices
        {
            get { return _devices; }
            set { _devices = value; }
        }
    }
}
