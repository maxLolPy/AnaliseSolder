using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using BaseObjectsMVVM;
using System.Data.SQLite;
using System.Linq;
using System.Text.RegularExpressions;
using AnaliseSolder.models.Attire;
using AnaliseSolder.models.Division;
using AnaliseSolder.models.Place;
using AnaliseSolder.models.Solder;
using AnaliseSolder.Views.Division;
using AnaliseSolder.Views.Place;
using AnaliseSolder.Views.Report1;
using AnaliseSolder.Views.Solder;
using AnaliseSolder.Views.Title;
using projectControl;

namespace AnaliseSolder
{
    public class MainPageVM : WorkspaceViewModel
    {
        public MainPageVM(Frame mainPage) : base(mainPage, null)
        {
            MainStaticObject.SqlManager = new SqlManager();
            MainStaticObject.SqlManager.ConnectionString =
                "Data Source=anliseSolders; Version=3; FailIfMissing=False";
            MainStaticObject.SqlManager.Connect();
        }

        private AttireListVM _attireListVM;

        public AttireListVM AttireListVM
        {
            get => _attireListVM ?? (_attireListVM = new AttireListVM(this));
            set
            {
                _attireListVM = value;
                OnPropertyChanged(() => AttireListVM);
            }
        }

        private RelayCommand _createAttireCommand;

        public RelayCommand CreateAttireCommand => _createAttireCommand ?? (_createAttireCommand = new RelayCommand(
            obj => AttireListVM.OpenItem(
                new AttireVM(AttireListVM.getMax() + 1, SaveStatuses.New)
            )
        ));

        private RelayCommand _openSoldersListCommnand;

        public RelayCommand OpenSoldersListCommnand => _openSoldersListCommnand ?? (_openSoldersListCommnand =
                new RelayCommand(obj => Navigate(new SolderListVMPage(MainFrame, this)))
            );

        private RelayCommand _openTitleListCommnand;

        public RelayCommand OpenTitleListCommnand => _openTitleListCommnand ?? (_openTitleListCommnand =
                new RelayCommand(obj => Navigate(new TitleListVMPage(MainFrame, this)))
            );

        private RelayCommand _openPlacesListCommnand;

        public RelayCommand OpenPlacesListCommnand => _openPlacesListCommnand ?? (_openPlacesListCommnand =
                new RelayCommand(obj => Navigate(new PlaceListVMPage(MainFrame, this)))
            );

        private RelayCommand _openDivisionsListCommnand;

        public RelayCommand OpenDivisionsListCommnand => _openDivisionsListCommnand ?? (_openDivisionsListCommnand =
                new RelayCommand(obj => Navigate(new DivisionListVMPage(MainFrame, this)))
            );


        private RelayCommand _report1Command;

        public RelayCommand Report1Command => _report1Command ?? (_report1Command =
                new RelayCommand(obj => Navigate(new Report1ListVMPage(MainFrame, this)))
            );

        private PlaceListVM _placeListVM;

        public PlaceListVM PlaceListVM
        {
            get => _placeListVM ?? (_placeListVM = new PlaceListVM(this));
        }

        public ObservableCollection<PlaceVM> PlaceListVMItemsWithFilter
        {
            get
            {
                if (String.IsNullOrEmpty(PlacesDescrFilter)) return PlaceListVM.Items;
                Regex regex = new Regex((PlacesDescrFilter).ToLower());
                var res = new ObservableCollection<PlaceVM>(PlaceListVM.Items.Where(p =>
                {
                    MatchCollection matches = regex.Matches(p.Descr.ToLower());
                    return matches.Count > 0;
                }));
                foreach (var p in PlaceListVM.Items)
                {
                    MatchCollection matches = regex.Matches(p.Descr.ToLower());
                    if (matches.Count == 0) res.Add(p);
                }

                return res;
            }
        }

        private string _placesDescrFilter;

        public string PlacesDescrFilter
        {
            get { return _placesDescrFilter; }
            set
            {
                _placesDescrFilter = value;
                OnPropertyChanged(() => PlaceListVMItemsWithFilter);
            }
        }

        private SolderListVM _solderListVM;

        public SolderListVM SolderListVM
        {
            get => _solderListVM ?? (_solderListVM = new SolderListVM(SolderModes.solder, this));
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

        public override void UpdateViewModel()
        {
            AttireListVM.UpdateCommand.Execute(null);
        }
    }
}