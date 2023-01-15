using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Title
{
    public class TitleSql : ModelSql<TitleM>
    {
        public override void Update(TitleM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    " update titles set " +
                    "descr = '" + item.Descr +
                    "',short_descr = '" + item.ShortDescr +
                    "' where title_id = " + item.TitleId + ";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("err " + e.Message);
            }
        }

        public override int? Create(TitleM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "insert into titles(title_id, descr, short_descr) select "
                    + item.TitleId + ",'" + item.Descr + "','" + item.ShortDescr +
                    "'; select max(title_id) from titles",
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

        public override void Delete(TitleM item)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteCommand(
                    "delete from titles " +
                    " where title_id = " + item.TitleId + ";",
                    MainStaticObject.SqlManager.Connection);
                res.ExecuteNonQuery();
                MainStaticObject.SqlManager.Connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Нельзя удалить звание. Есть солдаты с этим званием.");
            }
        }

        public override SQLiteDataAdapter LoadItems()
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter("SELECT title_id, descr, short_descr FROM titles",
                    MainStaticObject.SqlManager.Connection);
                MainStaticObject.SqlManager.Connection.Close();
                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Нельзя удалить звание. Есть солдаты обладающие этим званием.");
            }

            return null;
        }

        public override SQLiteDataAdapter LoadItem(int itemId)
        {
            try
            {
                MainStaticObject.SqlManager.Connection.Open();
                var res = new SQLiteDataAdapter(
                    "SELECT title_id, descr, short_descr FROM titles where title_id = " + itemId.ToString(),
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