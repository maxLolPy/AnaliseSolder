using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views.Division
{
    public partial class DivisionListVMPage : Page
    {
        public DivisionListVMPage(Frame mainFrame, WorkspaceViewModel parent)
        {
            DataContext = new DivisionListVMwm(mainFrame, parent);
            InitializeComponent();
        }
    }
}