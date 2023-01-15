using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using AnaliseSolder.models.Attire;
using AnaliseSolder.models.Division;
using AnaliseSolder.models.Place;
using AnaliseSolder.models.Solder;
using AnaliseSolder.models.Title;
using BaseObjectsMVVM;
using BaseObjectsMVVM.WpfControls;
using projectControl;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnaliseSolder.Views.Division
{
    public class DivisionListVMwm : WorkspaceViewModel
    {
        public DivisionListVMwm(Frame mainFrame, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
        }

        private DivisionListVM _divisionListVM;

        public DivisionListVM DivisionListVM
        {
            get => _divisionListVM ?? (_divisionListVM = new DivisionListVM(this));
        }

        public override void UpdateViewModel()
        {
            DivisionListVM.UpdateCommand.Execute(null);
        }
    }
}