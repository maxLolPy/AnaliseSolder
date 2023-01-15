using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views
{
    public partial class AttireVMPage : Page
    {
        public AttireVMPage(Frame mainFrame, int? itemId, WorkspaceViewModel parent)
        {
            DataContext = new AttireVMwm(mainFrame, itemId, parent);
            InitializeComponent();
        }

        public AttireVMPage(Frame mainFrame, AttireVM Item, WorkspaceViewModel parent)
        {
            DataContext = new AttireVMwm(mainFrame, Item, parent);
            InitializeComponent();
        }
    }
}