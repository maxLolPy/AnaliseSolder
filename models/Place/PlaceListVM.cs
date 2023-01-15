using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Place
{
    public class PlaceListVM:DictionaryViewModel<PlaceVM, PlaceM, PlaceSql>
    {
        public PlaceListVM(WorkspaceViewModel parent):base(parent)
        {
            LoadItems();
        }
        public override void LoadItems()
        {
            try
            {
                var PlaceSql = new PlaceSql();
                SQLiteDataAdapter adapter = PlaceSql.LoadItems();
                DataTable data = new DataTable();
                adapter.Fill(data);
                Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new PlaceVM(row));
                }
            }catch(Exception e)
            {
                MessageBox.Show("err "+e.Message);
            }
        }
        
    }
}