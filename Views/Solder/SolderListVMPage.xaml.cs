using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views.Solder
{
    public partial class SolderListVMPage : Page
    {
        public SolderListVMPage(Frame mainFrame, WorkspaceViewModel parent)
        {
            DataContext = new SolderListVMwm(mainFrame, parent);
            InitializeComponent();
        }
    }
}