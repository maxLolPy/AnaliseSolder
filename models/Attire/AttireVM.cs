using System;
using System.Data;
using AnaliseSolder.models.Place;
using AnaliseSolder.models.Solder;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Attire
{
    public class AttireVM : EntityViewModel<AttireM, AttireSql>
    {
        public AttireVM(DataRow row)
        {
            ParseArguments(row);
        }

        public override bool CanSave
        {
            get =>
                base.CanSave
                && SolderId != null
                && PlaceId != null
                && ResponsibleId != null
            ;
        }

        public AttireVM(int? itemId, SaveStatuses status) : base(itemId, status)
        {
            Item.AttireId = itemId;
        }


        public override void ParseArguments(DataRow row)
        {
            Item.AttireId = Int32.Parse(row.ItemArray[0].ToString());
            Item.SolderId = Int32.Parse(row.ItemArray[1].ToString());
            Item.PlaceId = Int32.Parse(row.ItemArray[2].ToString());
            Item.Descr = row.ItemArray[3].ToString();
            Item.DateAttire = DateTime.ParseExact(row.ItemArray[4].ToString(), "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture);
            Item.ResponsibleId = Int32.Parse(row.ItemArray[5].ToString());
            Item.IsPositive = Int32.Parse(row.ItemArray[6].ToString()) != 0;
        }

        #region AttireId

        public int? AttireId
        {
            get => Item.AttireId;
            set
            {
                Item.AttireId = value;
                SetPropertyValue(() => AttireId, value, ref Item.AttireId);
            }
        }

        #endregion

        #region Solder

        public int? SolderId
        {
            get => Item.SolderId;
            set { SetPropertyValue(() => SolderId, value, ref Item.SolderId); }
        }

        #endregion

        public int? PlaceId
        {
            get => Item.PlaceId;
            set { SetPropertyValue(() => PlaceId, value, ref Item.PlaceId); }
        }

        #region Descr

        public string Descr
        {
            get => Item.Descr;
            set { SetPropertyValue(() => Descr, value, ref Item.Descr); }
        }

        public string DescrForCopy => Descr + '\t' + (IsPositive ? "+" : "-");
        #endregion

        #region DateAttire

        public DateTime DateAttire
        {
            get => Item.DateAttire;
            set { SetPropertyValue(() => DateAttire, value, ref Item.DateAttire); }
        }

        #endregion


        public int? ResponsibleId
        {
            get => Item.ResponsibleId;
            set { SetPropertyValue(() => ResponsibleId, value, ref Item.ResponsibleId); }
        }

        #region IsPositive

        public bool IsPositive
        {
            get => Item.IsPositive;
            set { SetPropertyValue(() => IsPositive, value, ref Item.IsPositive); }
        }

        #endregion

        private SolderVM _solderVM;

        public SolderVM SolderVM
        {
            get => _solderVM ?? (_solderVM = new SolderVM(SolderId, SaveStatuses.Unchanged));
        }

        private SolderVM _responsibleVM;

        public SolderVM ResponsibleVM
        {
            get => _responsibleVM ?? (_responsibleVM = new SolderVM(ResponsibleId, SaveStatuses.Unchanged));
        }

        private PlaceVM _placeVM;

        public AttireVM()
        {
        }

        public PlaceVM PlaceVM
        {
            get => _placeVM ?? (_placeVM = new PlaceVM(PlaceId, SaveStatuses.Unchanged));
        }
    }
}