using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views.Title
{
    public partial class TitleListVMPage : Page
    {
        public TitleListVMPage(Frame mainFrame, WorkspaceViewModel parent)
        {
            DataContext = new TitleListVMwm(mainFrame, parent);
            InitializeComponent();
        }
    }
}