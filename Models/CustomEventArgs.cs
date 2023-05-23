namespace GoveeControl.Models
{
    public class CustomEventArgs : EventArgs
    {
        public class BrightnessSliderEventArgs : CustomEventArgs
        {
            public int Brightness { get; set; }
            public DeviceGroup Group { get; set; }
        }

        public class PowerToggleEventArgs : CustomEventArgs
        {
            public int PowerState { get; set; }
            public DeviceGroup Group { get; set; }
        }

        public class ColorButtonEventArgs : CustomEventArgs
        {
            public Color Color { get; set; }
            public DeviceGroup Group { get; set; }
        }
    }
}
