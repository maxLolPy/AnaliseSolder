using System.Windows.Controls;

namespace AnaliseSolder
{
    public partial class mainPage: Page
    {
    public mainPage(Frame mainFrame)
    {
        DataContext = new MainPageVM(mainFrame);
        InitializeComponent();
    }
    }
}