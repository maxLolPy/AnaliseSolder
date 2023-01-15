using System;
using System.Data;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Place
{
    public class PlaceVM : EntityViewModel<PlaceM, PlaceSql>
    {
        public PlaceVM(DataRow row)
        {
            ParseArguments(row);
        }
        public PlaceVM(int? placeId, SaveStatuses status):base(placeId, status)
        {
        }

        public PlaceVM()
        {
        }

        public override void ParseArguments(DataRow row)
        {
            Item.PlaceId = Int32.Parse(row.ItemArray[0].ToString());
            Item.Descr = row.ItemArray[1].ToString();
        }

        #region PlaceId

        public int? PlaceId
        {
            get => Item.PlaceId;
            set
            {
                SetPropertyValue(()=>PlaceId, value, ref Item.PlaceId);
            }
        }
        public override int? ItemId
        {
            get => PlaceId;
            set => PlaceId = value;
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
        
       

        
    }
}