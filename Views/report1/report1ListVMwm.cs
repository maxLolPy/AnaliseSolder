using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
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

namespace AnaliseSolder.Views.Report1
{
    public class Report1ListVMwm : WorkspaceViewModel
    {
        public Report1ListVMwm(Frame mainFrame, WorkspaceViewModel parent) : base(mainFrame, parent)
        {
        }

        // private Report1ListVM _report1ListVM;
        //
        // public Report1ListVM Report1ListVM
        // {
        //     get => _report1ListVM??(_report1ListVM = new Report1ListVM(this));
        //     // set
        //     // {
        //     //     _solderListVM = value;
        //     //     OnPropertyChanged(()=>SolderListVM);
        //     // }
        // }
        public ObservableCollection<Report1M> Items { get; set; }

        public void LoadItems()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "SELECT solders.second_name, solders.solder_id" +
                    ",(select count(sldr1.solder_id) from solders sldr1 inner join attires on sldr1.solder_id = attires.solder_id and attires.is_positive = true where sldr1.solder_id = solders.solder_id group by sldr1.solder_id) " +
                    ",(select count(sldr1.solder_id) from solders sldr1 inner join attires on sldr1.solder_id = attires.solder_id and attires.is_positive = false where sldr1.solder_id = solders.solder_id group by sldr1.solder_id) " +
                    "FROM solders " +
                    "inner join attires a on solders.solder_id = a.solder_id " +
                    "where (563 is null or solders.solder_id = 563) " +
                    "and (1 is null or a.place_id = 1) " +
                    "group by solders.solder_id " +
                    "order by solders.second_name; ",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                DataTable data = new DataTable();
                res.Fill(data);
                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new Report1M(row));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            //return null;
        }

        public override void UpdateViewModel()
        {
            throw new NotImplementedException();
        }
    }

    public class Report1M
    {
        public Report1M(DataRow row)
        {
            SolderId = Int32.Parse(row.ItemArray[0].ToString());
            PlaceId = Int32.Parse(row.ItemArray[1].ToString());
            CountPos = Int32.Parse(row.ItemArray[2].ToString());
            CountNeg = Int32.Parse(row.ItemArray[3].ToString());
        }

        public int SolderId;
        public string Name;
        public string SecondName;
        public string FatherName;
        public int TitleId;
        public int PlaceId;
        public int CountPos;
        public int CountNeg;
    }
}