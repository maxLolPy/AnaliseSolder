using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Division
{
    public class DivisionListVM:DictionaryViewModel<DivisionVM, DivisionM, DivisionSql>
    {
        public DivisionListVM(WorkspaceViewModel parent): base(parent)
        {
            LoadItems();
        }
        public override void LoadItems()
        {
            try
            {
                var DivisionSql = new DivisionSql();
                SQLiteDataAdapter adapter = DivisionSql.LoadItems();
                DataTable data = new DataTable();
                adapter.Fill(data);
                Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new DivisionVM(row));
                }
            }catch(Exception e)
            {
                MessageBox.Show("err "+e.Message);
            }
        }
    }
}