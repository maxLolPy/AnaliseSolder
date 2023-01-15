using System;
using System.Data;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Title
{
    public class TitleVM : EntityViewModel<TitleM, TitleSql>
    {
        public TitleVM(DataRow row):base()
        {
            Item = new TitleM();
            ParseArguments(row);
        }
        public TitleVM(int TitleId, SaveStatuses status):base(TitleId, status)
        {
        }

        public TitleVM()
        {
        }

        public override void ParseArguments(DataRow row)
        {
            Item.TitleId = Int32.Parse(row.ItemArray[0].ToString());
            Item.Descr = row.ItemArray[1].ToString();
            Item.ShortDescr = row.ItemArray[2].ToString();
        }

        #region TitleId

        public int? TitleId
        {
            get => Item.TitleId;
            set
            {
                SetPropertyValue(()=>TitleId, value, ref Item.TitleId);
            }
        }
        public override int? ItemId
        {
            get => TitleId;
            set => TitleId = value;
        }
        #endregion
        #region Descr

        public string Descr {
            get => Item.Descr;
            set
            {
                SetPropertyValue(()=>Descr, value, ref Item.Descr);
            }
        }
        #endregion
        
        #region ShortDescr

        public string ShortDescr {
            get => Item.ShortDescr;
            set
            {
                SetPropertyValue(()=>ShortDescr, value, ref Item.ShortDescr);
            }
        }
        #endregion
        

        
    }
}