namespace GoveeControl.Models
{
    /// <summary>
    /// Model representing the state of a device
    /// </summary>
    public class DeviceState
    {
        private bool _online;
        private int _powerState;
        private int _brightness;
        private Color _color;

        public DeviceState(bool online, int powerState, int brightness, Color color)
        {
            _online = online;
            _powerState = powerState;
            _brightness = brightness;
            _color = color;
        }

        public DeviceState()
        {
            _online = false;
            _powerState = 0;
            _brightness = 0;
            _color = Color.White;
        }

        public bool Online
        {
            get { return _online; }
            set { _online = value; }
        }

        public int PowerState
        {
            get { return _powerState; }
            set { _powerState = value; }
        }

        public int Brightness
        { 
            get { return _brightness; }
            set { _brightness = value; }
        }

        public Color Color
        { 
            get { return _color; }
            set { _color = value; }
        }
    }
}
