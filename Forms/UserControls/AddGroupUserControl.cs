namespace GoveeControl.Forms.UserControls
{
    /// <summary>
    /// Custom UserControl to represent a Govee device
    /// </summary>
    public partial class AddGroupUserControl : UserControl
    {
        public event EventHandler? ButtonClick;

        public AddGroupUserControl()
        {
            InitializeComponent();
        }

        public void AddBtn_Click(object sender, EventArgs e)
        {
            OnButtonClick();
        }

        protected virtual void OnButtonClick()
        {
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
