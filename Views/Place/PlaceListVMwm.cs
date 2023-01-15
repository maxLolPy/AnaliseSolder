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

namespace AnaliseSolder.Views.Place
{
    public class PlaceListVMwm : WorkspaceViewModel
    {
        public PlaceListVMwm(Frame mainFrame, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
        }

        private PlaceListVM _placeListVM;

        public PlaceListVM PlaceListVM
        {
            get => _placeListVM ?? (_placeListVM = new PlaceListVM(this));
        }

        public override void UpdateViewModel()
        {
            PlaceListVM.UpdateCommand.Execute(null);
        }
    }
}