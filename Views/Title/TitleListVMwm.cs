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

namespace AnaliseSolder.Views.Title
{
    public class TitleListVMwm : WorkspaceViewModel
    {
        public TitleListVMwm(Frame mainFrame, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
        }

        private TitleListVM _titleListVM;

        public TitleListVM TitleListVM
        {
            get => _titleListVM ?? (_titleListVM = new TitleListVM(this));
            // set
            // {
            //     _solderListVM = value;
            //     OnPropertyChanged(()=>SolderListVM);
            // }
        }

        public override void UpdateViewModel()
        {
            TitleListVM.UpdateCommand.Execute(null);
        }
    }
}