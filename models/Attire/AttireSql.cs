using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnaliseSolder.models.Attire
{
    public class AttireSql : ModelSql<AttireM>
    {
        public override void Update(AttireM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update attires set " +
                    "solder_id = " + item.SolderId +
                    ",place_id = " + item.PlaceId +
                    ",descr = '"+ item.Descr +
                    "',date_attire = '"+item.DateAttire.ToString("d") +
                    "',responsible_id = "+item.ResponsibleId+
                    ",is_positive = "+ item.IsPositive+
                    " where attire_id = "+item.AttireId +";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }
        public override int? Create(AttireM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "insert into attires(attire_id, solder_id, place_id, descr, date_attire, responsible_id, is_positive) select "
                    +item.AttireId+","+item.SolderId+","
                    +item.PlaceId+",'"+item.Descr+"','"
                    +item.DateAttire.ToString("dd/MM/yyyy")
                    +"',"+item.ResponsibleId+","
                    +item.IsPositive+";select max(attire_id) from attires",
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

        public override void Delete(AttireM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    "delete from attires " +
                    " where attire_id = "+item.AttireId +";",
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
                var res = new SQLiteDataAdapter(
                    "SELECT attire_id, solder_id, place_id, descr, date_attire, responsible_id, cast(is_positive as int) FROM attires",
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
        
        public SQLiteDataAdapter GetMax()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "SELECT max(attire_id) FROM attires",
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
                    "SELECT attire_id, solder_id, place_id, descr, date_attire, responsible_id, is_positive FROM attires Where attire_id = "+itemId.ToString() ,
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