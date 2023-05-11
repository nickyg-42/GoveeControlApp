using GoveeControl.Interfaces;

namespace GoveeControl;

public partial class Home : Form
{
    private readonly IGoveeService _goveeService;
    public Home(IGoveeService goveeService)
    {
        InitializeComponent();
        _goveeService = goveeService;
    }
}
