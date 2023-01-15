using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Division
{
    public class DivisionSql : ModelSql<DivisionM>
    {
        public override void Update(DivisionM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update divisions set " +
                    "descr = '"+ item.Name +
                    "' where division_id = "+item.IdDivision +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public override int? Create(DivisionM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "insert into divisions(division_id, descr) select "
                    +item.IdDivision+",'"+item.Name+"'; select max(division_id) from divisions",
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

        public override void Delete(DivisionM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    "delete from divisions " +
                    " where division_id = "+item.IdDivision +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Перед удалением подразделения, необходимо перевести из него всех военнослужащих.");
            }
        }

        public override SQLiteDataAdapter LoadItems()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT division_id, descr FROM divisions",
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
                var res = new SQLiteDataAdapter(
                    "SELECT division_id, descr FROM divisions where division_id = " + itemId.ToString(),
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