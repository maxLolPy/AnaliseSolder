using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Title
{
    public class TitleListVM:DictionaryViewModel<TitleVM, TitleM, TitleSql>
    {
        public TitleListVM(WorkspaceViewModel parent):base(parent)
        {
            LoadItems();
        }
        public override void LoadItems()
        {
            try
            {
                var TitleSql = new TitleSql();
                SQLiteDataAdapter adapter = TitleSql.LoadItems();
                DataTable data = new DataTable();
                adapter.Fill(data);
                Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new TitleVM(row));
                }
            }catch(Exception e)
            {
                MessageBox.Show("err "+e.Message);
            }
        }
    }
}