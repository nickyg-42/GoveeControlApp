namespace GoveeControl.Models
{
    public class CustomEventArgs : EventArgs
    {
        public class BrightnessSliderEventArgs : CustomEventArgs
        {
            public int Brightness { get; set; }
            public List<GoveeDevice> Devices { get; set; }
        }

        public class PowerToggleEventArgs : CustomEventArgs
        {
            public int PowerState { get; set; }
            public List<GoveeDevice> Devices { get; set; }
        }

        public class ColorButtonEventArgs : CustomEventArgs
        {
            public Color Color { get; set; }
            public List<GoveeDevice> Devices { get; set; }
        }
    }
}
