using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using AnaliseSolder.models.Division;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Place
{
    public class PlaceSql : ModelSql<PlaceM>
    {
        public override void Update(PlaceM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update places set " +
                    "descr = '"+ item.Descr +
                    "' where place_id = "+item.PlaceId +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public override int? Create(PlaceM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "insert into places(place_id, descr) select "
                    +item.PlaceId+",'"+item.Descr+"'; select max(place_id) from places",
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

        public override void Delete(PlaceM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    "delete from places " +
                    " where place_id = "+item.PlaceId +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно удалить место несения службы. Данное место используется в списках АСВ." + e.Message);
            }
        }
        public override void GroupItems(int id1, int id2)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update attires set place_id = "+id1 +
                    " where place_id = " + id2+
                    "; delete from places where place_id = " + id2,
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public override SQLiteDataAdapter LoadItems()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT place_id, descr FROM places",
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
                var res = new SQLiteDataAdapter("SELECT place_id, descr FROM places where place_id = " + itemId.ToString(),
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