using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using AnaliseSolder.models.Attire;
using AnaliseSolder.models.Place;
using AnaliseSolder.models.Solder;
using BaseObjectsMVVM;
using BaseObjectsMVVM.WpfControls;
using projectControl;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnaliseSolder.Views
{
    public class AttireVMwm : WorkspaceViewModel
    {
        public AttireVMwm(Frame mainFrame, int? itemId, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
            _attireId = itemId;
        }

        public AttireVMwm(Frame mainFrame, AttireVM item, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
            _attireVM = item;
            SolderListVM.SelectedItem = new SolderVM(AttireVM.SolderId, SaveStatuses.Unchanged);
        }

        public override SaveStatuses Status
        {
            get { return AttireVM.Status; }
            set
            {
                AttireVM.Status = value;
                OnPropertyChanged(() => Status);
            }
        }

        private int? _attireId;
        private AttireVM _attireVM;

        public AttireVM AttireVM
        {
            get { return _attireVM ?? (_attireVM = new AttireVM(_attireId, SaveStatuses.Unchanged)); }
            set
            {
                _attireVM = value;
                OnPropertyChanged(() => AttireVM);
            }
        }

        #region Responsible

        private SolderVM _responsibleVM;

        public SolderVM ResponsibleVM
        {
            set
            {
                OficerListVM.SelectedItem = value;
                AttireVM.ResponsibleId = value?.SolderId;
                OnPropertyChanged(() => ResponsibleVM);
            }
            get
            {
                return OficerListVM.SelectedItem ?? (OficerListVM.SelectedItem =
                    new SolderVM(AttireVM.ResponsibleId, SaveStatuses.Unchanged));
            }
        }

        private SolderListVM _oficerListVM;

        public SolderListVM OficerListVM
        {
            get { return _oficerListVM ?? (_oficerListVM = new SolderListVM(SolderModes.oficer, this)); }
            set
            {
                _oficerListVM = value;
                OnPropertyChanged(() => OficerListVM);
            }
        }

        public ObservableCollection<SolderVM> SolderListVMItemsWithFilter
        {
            get
            {
                if (String.IsNullOrEmpty(SoldersDescrFilter)) return SolderListVM.Items;
                Regex regex = new Regex((SoldersDescrFilter).ToLower());
                var res = new ObservableCollection<SolderVM>(SolderListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    return matches.Count > 0;
                }));
                foreach (var p in SolderListVM.Items)
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    if (matches.Count == 0) res.Add(p);
                }

                return res;
            }
        }

        private string _soldersDescrFilter;

        public string SoldersDescrFilter
        {
            get { return _soldersDescrFilter; }
            set
            {
                _soldersDescrFilter = value;
                OnPropertyChanged(() => SolderListVMItemsWithFilter);
            }
        }
        private string _oficerDescrFilter;
        public string OficerDescrFilter
        {
            get => _oficerDescrFilter;
            set
            {
                _oficerDescrFilter = value;
                OnPropertyChanged(()=>OficerDescrFilter);
                OnPropertyChanged(()=>OficerListVMItems);
            }
        }
        public ObservableCollection<SolderVM> OficerListVMItems
        {
            get
            {
                //return OficerListVM.Items;
                if (String.IsNullOrEmpty(OficerDescrFilter)) return OficerListVM.Items;
                Regex regex = new Regex((OficerDescrFilter).ToLower());
                return new ObservableCollection<SolderVM>(OficerListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    return matches.Count > 0;
                }));
            }
        }

        #endregion

        #region Place

        private PlaceVM _placeVM;

        public PlaceVM PlaceVM
        {
            set
            {
                PlaceListVM.SelectedItem = value;
                AttireVM.PlaceId = value?.PlaceId;
                OnPropertyChanged(() => PlaceVM);
            }
            get
            {
                return PlaceListVM.SelectedItem ??
                       (PlaceListVM.SelectedItem = new PlaceVM(AttireVM.PlaceId, SaveStatuses.Unchanged));
            }
        }

        private PlaceListVM _placeListVM;

        public PlaceListVM PlaceListVM
        {
            get { return _placeListVM ?? (_placeListVM = new PlaceListVM(this)); }
            set
            {
                _placeListVM = value;
                OnPropertyChanged(() => PlaceListVM);
            }
        }

        private string _placeDescrFilter;
        public string PlaceDescrFilter
        {
            get => _placeDescrFilter;
            set
            {
                _placeDescrFilter = value;
                OnPropertyChanged(()=>PlaceDescrFilter);
                OnPropertyChanged(()=>PlaceListVMItems);
            }
        }
        public ObservableCollection<PlaceVM> PlaceListVMItems
        {
            get
            {
                //return PlaceListVM.Items;
                if (String.IsNullOrEmpty(PlaceDescrFilter)) return PlaceListVM.Items;
                Regex regex = new Regex((PlaceDescrFilter).ToLower());
                return new ObservableCollection<PlaceVM>(PlaceListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.Descr.ToLower());
                    return matches.Count > 0;
                }));
            }
        }

        #endregion

        #region SolderVM

        public SolderVM SolderVM
        {
            get
            {
                return SolderListVM.SelectedItem ?? (SolderListVM.SelectedItem =
                    new SolderVM(AttireVM.SolderId, SaveStatuses.Unchanged));
            }
            set
            {
                SolderListVM.SelectedItem = value;
                AttireVM.SolderId = value?.SolderId;
                OnPropertyChanged(() => SolderVM);
            }
        }

        private SolderListVM _solderListVM;

        public SolderListVM SolderListVM
        {
            get { return _solderListVM ?? (_solderListVM = new SolderListVM(SolderModes.all, this)); }
            set
            {
                _solderListVM = value;
                OnPropertyChanged(() => SolderListVM);
            }
        }
        private string _solderDescrFilter;
        public string SolderDescrFilter
        {
            get => _solderDescrFilter;
            set
            {
                _solderDescrFilter = value;
                OnPropertyChanged(()=>SolderDescrFilter);
                OnPropertyChanged(()=>SolderListVMItems);
            }
        }
        public ObservableCollection<SolderVM> SolderListVMItems
        {
            get
            {
                if (String.IsNullOrEmpty(SolderDescrFilter)) return SolderListVM.Items;
                Regex regex = new Regex((SolderDescrFilter).ToLower());
                return new ObservableCollection<SolderVM>(SolderListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.DescrForFind.ToLower());
                    return matches.Count > 0;
                }));
            }
        }

        #endregion


        #region Properties

        #region IsOpenPlaceBox

        private bool _isOpenPlaceBox;

        public bool IsOpenPlaceBox
        {
            get { return _isOpenPlaceBox; }
            set
            {
                _isOpenPlaceBox = value;
                OnPropertyChanged(() => IsOpenPlaceBox);
            }
        }

        #endregion

        #region IsOpenSolderBox

        private bool _isOpenSolderBox;

        public bool IsOpenSolderBox
        {
            get { return _isOpenSolderBox; }
            set
            {
                _isOpenSolderBox = value;
                OnPropertyChanged(() => IsOpenSolderBox);
            }
        }

        #endregion

        #region IsOpenOficerBox

        private bool _isOpenOficerBox;

        public bool IsOpenOficerBox
        {
            get { return _isOpenOficerBox; }
            set
            {
                _isOpenOficerBox = value;
                OnPropertyChanged(() => IsOpenOficerBox);
            }
        }

        #endregion

        #endregion


        // private string _placeDescrFilter;
        //
        // public string PlaceDescrFilter
        // {
        //     get
        //     {
        //         return String.IsNullOrEmpty(_placeDescrFilter) && Status == SaveStatuses.Unchanged
        //             ? _placeDescrFilter = PlaceVM.Descr
        //             : _placeDescrFilter;
        //     }
        //     set
        //     {
        //         _placeDescrFilter = value;
        //         _placeVM = null;
        //         OnPropertyChanged(() => PlaceDescrFilter);
        //         OnPropertyChanged(() => PlaceListVMItems);
        //         IsOpenPlaceBox = !String.IsNullOrEmpty(_placeDescrFilter);
        //     }
        // }
        //
        //
        // private string _solderDescrFilter;
        //
        // public string SolderDescrFilter
        // {
        //     get
        //     {
        //         return String.IsNullOrEmpty(_solderDescrFilter) && Status == SaveStatuses.Unchanged
        //             ? _solderDescrFilter = SolderVM.DescrForFind
        //             : _solderDescrFilter;
        //     }
        //     set
        //     {
        //         _solderDescrFilter = value;
        //         _solderVM = null;
        //         OnPropertyChanged(() => SolderDescrFilter);
        //         OnPropertyChanged(() => SolderListVMItems);
        //         IsOpenSolderBox = !String.IsNullOrEmpty(SolderDescrFilter);
        //     }
        // }
        //
        // private string _oficerDescrFilter;
        //
        // public string OficerDescrFilter
        // {
        //     get
        //     {
        //         return String.IsNullOrEmpty(_oficerDescrFilter) && Status == SaveStatuses.Unchanged
        //             ? _oficerDescrFilter = ResponsibleVM.DescrForFind
        //             : _oficerDescrFilter;
        //     }
        //     set
        //     {
        //         _oficerDescrFilter = value;
        //         _responsibleVM = null;
        //         OnPropertyChanged(() => OficerDescrFilter);
        //         OnPropertyChanged(() => OficerListVMItems);
        //         IsOpenOficerBox = !String.IsNullOrEmpty(value);
        //     }
        // }


        public void Save()
        {
            AttireVM.SaveItem();
        }

        public override void UpdateViewModel()
        {
            AttireVM.UpdateItemCommand.Execute(null);
        }
    }
}