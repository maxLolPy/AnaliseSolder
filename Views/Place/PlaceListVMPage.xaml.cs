using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using AnaliseSolder.Views.Title;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views.Place
{
    public partial class PlaceListVMPage : Page
    {
        public PlaceListVMPage(Frame mainFrame, WorkspaceViewModel parent)
        {
            DataContext = new PlaceListVMwm(mainFrame, parent);
            InitializeComponent();
        }
    }
}