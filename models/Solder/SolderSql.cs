using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Solder
{
    public class SolderSql : ModelSql<SolderM>
    {
        public override void Update(SolderM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update solders set " +
                    "name = '" + item.Name +
                    "',second_name = '" + item.SecondName +
                    "',father_name = '"+ item.FatherName +
                    "',division_id = "+item.DivisionId +
                    ",is_oficer = "+item.IsOficer+
                    ",title_id = "+ item.TitleId+
                    " where solder_id = "+item.SolderId +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
            
        }
        public override int? Create(SolderM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "insert into solders(solder_id, name, second_name, father_name, division_id, is_oficer, title_id) select "
                    +item.SolderId+",'"+item.Name+"','"+item.SecondName+"','"+item.FatherName+"',"+item.DivisionId+","+item.IsOficer+","+item.TitleId+"; select max(solder_id) from solders",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                DataTable data = new DataTable();
                res.Fill(data);
                
                if (data.Rows.Count > 0)
                {
                    return Int32.Parse(data.Rows[0][0].ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            return null;
        }
        public override void GroupItems(int id1, int id2)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update attires set solder_id = "+id1 +
                    " where solder_id = " + id2+
                    "; delete from solders where solder_id = " + id2,
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public override void Delete(SolderM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    "delete from solders " +
                    " where solder_id = "+item.SolderId +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Нельзя удалить солдата. Есть записи с его участием в списке АСВ.");
            }
        }
        public override SQLiteDataAdapter LoadItems()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT solder_id, name, second_name, father_name, division_id, cast(is_oficer as int), title_id " +
                                                "FROM solders " +
                                                "order by second_name",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            return null;
        }
        public SQLiteDataAdapter LoadSolders()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT solder_id, name, second_name, father_name, division_id, cast(is_oficer as int), title_id " +
                                                "FROM solders " +
                                                "where cast(is_oficer as int) = 0 " +
                                                "order by second_name",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            return null;
        }
        public SQLiteDataAdapter LoadOficers()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT solder_id, name, second_name, father_name, division_id, cast(is_oficer as int), title_id " +
                                                "FROM solders " +
                                                "where cast(is_oficer as int)=1 " +
                                                "order by second_name",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            return null;
        }


        public override SQLiteDataAdapter LoadItem(int itemId)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(@"SELECT solder_id, name, second_name, father_name, division_id, cast(is_oficer as int), title_id FROM solders where solder_id  = "+ itemId.ToString(),
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }

            return null;
        }
    }
}