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

namespace AnaliseSolder.Views.Solder
{
    public class SolderListVMwm : WorkspaceViewModel
    {
        public SolderListVMwm(Frame mainFrame, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
        }

        private SolderListVM _solderListVM;

        public SolderListVM SolderListVM
        {
            get => _solderListVM ?? (_solderListVM = new SolderListVM(SolderModes.all, this));
            // set
            // {
            //     _solderListVM = value;
            //     OnPropertyChanged(()=>SolderListVM);
            // }
        }

        private DivisionListVM _divisionListVM;

        public DivisionListVM DivisionListVM
        {
            get => _divisionListVM ?? (_divisionListVM = new DivisionListVM(this));
            // set
            // {
            //     _solderListVM = value;
            //     OnPropertyChanged(()=>SolderListVM);
            // }
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


        private SolderVM _solderVM1;

        public SolderVM SolderVM1
        {
            get { return _solderVM1; }
            set
            {
                _solderVM1 = value;
                OnPropertyChanged(() => SolderVM1);
                OnPropertyChanged(() => Solder1DescrFilter);
            }
        }

        private bool _isOpenSolder1Box;

        public bool IsOpenSolder1Box
        {
            get { return _isOpenSolder1Box; }
            set
            {
                _isOpenSolder1Box = value;
                OnPropertyChanged(() => IsOpenSolder1Box);
            }
        }

        private string _solder1DescrFilter = "";

        public string Solder1DescrFilter
        {
            get
            {
                return String.IsNullOrEmpty(_solder1DescrFilter)
                    ? _solder1DescrFilter = ""
                    : _solder1DescrFilter;
            }
            set
            {
                _solder1DescrFilter = value;
                OnPropertyChanged(() => Solder1DescrFilter);
                OnPropertyChanged(() => Solder1ListVMItems);
                IsOpenSolder1Box = !String.IsNullOrEmpty(Solder1DescrFilter);
            }
        }

        public ObservableCollection<SolderVM> Solder1ListVMItems
        {
            get
            {
                if (String.IsNullOrEmpty(Solder1DescrFilter)) return SolderListVM.Items;
                Regex regex = new Regex((Solder1DescrFilter).ToLower());
                return new ObservableCollection<SolderVM>(SolderListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    return matches.Count > 0;
                }));
            }
        }


        private SolderVM _solderVM2;

        public SolderVM SolderVM2
        {
            get { return _solderVM2; }
            set
            {
                _solderVM2 = value;
                OnPropertyChanged(() => SolderVM2);
                OnPropertyChanged(() => Solder2DescrFilter);
            }
        }

        private bool _isOpenSolder2Box;

        public bool IsOpenSolder2Box
        {
            get { return _isOpenSolder2Box; }
            set
            {
                _isOpenSolder2Box = value;
                OnPropertyChanged(() => IsOpenSolder2Box);
            }
        }

        private string _solder2DescrFilter = "";

        public string Solder2DescrFilter
        {
            get
            {
                return String.IsNullOrEmpty(_solder2DescrFilter)
                    ? _solder2DescrFilter = ""
                    : _solder2DescrFilter;
            }
            set
            {
                _solder2DescrFilter = value;
                OnPropertyChanged(() => Solder2DescrFilter);
                OnPropertyChanged(() => Solder2ListVMItems);
                IsOpenSolder2Box = !String.IsNullOrEmpty(Solder2DescrFilter);
            }
        }

        public ObservableCollection<SolderVM> Solder2ListVMItems
        {
            get
            {
                if (String.IsNullOrEmpty(Solder2DescrFilter)) return SolderListVM.Items;
                Regex regex = new Regex((Solder2DescrFilter).ToLower());
                return new ObservableCollection<SolderVM>(SolderListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    return matches.Count > 0;
                }));
            }
        }

        // public override void GroupItems()
        // {
        //     SolderListVM.GroupItems((int) SolderVM1.SolderId, (int) SolderVM2.SolderId);
        // }
        public override void UpdateViewModel()
        {
            SolderListVM.UpdateCommand.Execute(null);
        }
    }
}