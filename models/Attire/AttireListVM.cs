using BaseObjectsMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using AnaliseSolder.models.Place;
using AnaliseSolder.Views;

namespace AnaliseSolder.models.Attire
{
    public class AttireListVM : DictionaryViewModel<AttireVM, AttireM, AttireSql>
    {
        public AttireListVM(WorkspaceViewModel parent) : base(parent)
        {
            LoadItems();
        }

        private DateTime _startDateFilter = DateTime.Now.AddMonths(-1);

        public DateTime StartDateFilter
        {
            get => _startDateFilter;
            set
            {
                _startDateFilter = value;
                OnPropertyChanged(() => StartDateFilter);
            }
        }

        private DateTime _endDateFilter = DateTime.Now;

        public DateTime EndDateFilter
        {
            get => _endDateFilter;
            set
            {
                _endDateFilter = value;
                OnPropertyChanged(() => EndDateFilter);
            }
        }

        public string PlacesFilter { get; set; } = "";

        public string SoldersFilter { get; set; } = "";

        public override void LoadItems()
        {
            try
            {
                var AttireSql = new AttireSql();
                SQLiteDataAdapter adapter = AttireSql.LoadItems();
                DataTable data = new DataTable();
                adapter.Fill(data);
                Items.Clear();
                List<int> placesFilterList = new List<int>();
                List<int> soldersFilterList = new List<int>();
                try
                {
                    placesFilterList = PlacesFilter.Split(',').ToList().Select(x => Int32.Parse(x)).ToList();
                }
                catch (Exception e)
                {
                }

                try
                {
                    soldersFilterList = SoldersFilter.Split(',').ToList().Select(x => Int32.Parse(x)).ToList();
                }
                catch (Exception e)
                {
                }

                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new AttireVM(row));
                    if (Items.Last().DateAttire < StartDateFilter
                        || Items.Last().DateAttire > EndDateFilter
                        || (placesFilterList.Count != 0 &&
                            placesFilterList.FirstOrDefault(i => i == Items.Last().PlaceId) == 0)
                        || (soldersFilterList.Count != 0 &&
                            soldersFilterList.FirstOrDefault(i => i == Items.Last().SolderId) == 0)
                       )
                        Items.Remove(Items.Last());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public int getMax()
        {
            var AttireSql = new AttireSql();
            SQLiteDataAdapter adapter = AttireSql.GetMax();
            DataTable data = new DataTable();
            adapter.Fill(data);
            var row = data.Rows[0];
            return Int32.Parse(row.ItemArray[0].ToString());
        }
        public override void OpenItem(AttireVM opendItemId)
        {
            Parent.MainFrame.Navigate(new AttireVMPage(Parent.MainFrame, opendItemId, Parent));
        }
    }
}