using System.Windows.Controls;
using AnaliseSolder.models.Attire;
using BaseObjectsMVVM;

namespace AnaliseSolder.Views.Report1
{
    public partial class Report1ListVMPage : Page
    {
        public Report1ListVMPage(Frame mainFrame, WorkspaceViewModel parent)
        {
            DataContext = new Report1ListVMwm(mainFrame, parent);
            InitializeComponent();
        }
    }
}