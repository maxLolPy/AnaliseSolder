using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Solder
{
    public class SolderListVM:DictionaryViewModel<SolderVM, SolderM, SolderSql>
    {
        public SolderListVM(SolderModes mode, WorkspaceViewModel parent): base(parent)
        {
            _mode = mode;
            LoadItems();
        }

        private SolderModes _mode;
        public override void LoadItems()
        {
            try
            {
                var SolderSql = new SolderSql();
                SQLiteDataAdapter adapter;
                if (_mode == SolderModes.solder)
                    adapter = SolderSql.LoadSolders();
                else if (_mode == SolderModes.oficer)
                    adapter = SolderSql.LoadOficers();
                else
                    adapter = SolderSql.LoadItems();
                DataTable data = new DataTable();
                adapter.Fill(data);
                Items.Clear();
                foreach (DataRow row in data.Rows)
                {
                    Items.Add(new SolderVM(row));
                }
            }catch(Exception e)
            {
                MessageBox.Show("err "+e.Message);
            }
        }

        
    }
}