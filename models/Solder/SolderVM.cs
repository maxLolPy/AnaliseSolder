using System;
using System.Data;
using AnaliseSolder.models.Division;
using AnaliseSolder.models.Title;
using BaseObjectsMVVM;
using BaseObjectsMVVM.WpfControls;

namespace AnaliseSolder.models.Solder
{
    public class SolderVM : EntityViewModel<SolderM, SolderSql>, ICanUseFinderTextBox
    {
        public SolderVM(DataRow row):base()
        {
            ParseArguments(row);
        }

        public SolderVM(int? SolderId, SaveStatuses status):base(SolderId, status)
        {
        }

        public override void ParseArguments(DataRow row)
        {
            Item.SolderId = Int32.Parse(row.ItemArray[0].ToString());
            Item.Name = row.ItemArray[1].ToString();
            Item.SecondName = row.ItemArray[2].ToString();
            Item.FatherName = row.ItemArray[3].ToString();
            Int32.TryParse(row.ItemArray[4].ToString(), out int id);
            Item.DivisionId = id;
            Item.IsOficer = Int32.Parse(row.ItemArray[5].ToString()) !=0;
            Item.TitleId = Int32.Parse(row.ItemArray[6].ToString());
        }
        #region SolderId

        public int? SolderId
        {
            get => Item.SolderId;
            set
            {
                SetPropertyValue(()=>SolderId, value, ref Item.SolderId);
            }
        }
        public override int? ItemId
        {
            get => SolderId;
            set => SolderId = value;
        }
        #endregion
        #region Name

        public string Name {
            get => Item.Name;
            set
            {
                SetPropertyValue(()=>Name, value, ref Item.Name);
            }
        }
        #endregion
        #region SecondName

        public string SecondName {
            get => Item.SecondName;
            set
            {
                SetPropertyValue(()=>SecondName, value, ref Item.SecondName);
            }
        }
        #endregion
        #region FatherName

        public string FatherName {
            get => Item.FatherName;
            set
            {
                SetPropertyValue(()=>FatherName, value, ref Item.FatherName);
            }
        }
        #endregion
        #region Fio

        public string Fio
        {
            get => SecondName + " " + Name + FatherName;
        }
        #endregion
        #region Division
        private DivisionVM _divisionVM;

        public DivisionVM DivisionVM
        {
            get => _divisionVM ?? (_divisionVM = new DivisionVM(DivisionId, SaveStatuses.Unchanged));
            set
            {
                _divisionVM = value;
                OnPropertyChanged(()=>DivisionVM);
            }
        }
        public int DivisionId
        {
            get => Item.DivisionId;
            set
            {
                SetPropertyValue(()=>DivisionId, value, ref Item.DivisionId);
            }
        }
        #endregion
        #region IsOficer
        public bool IsOficer
        {
            get => Item.IsOficer;
            set
            {
                SetPropertyValue(()=>IsOficer, value, ref Item.IsOficer);
            }
        }
        #endregion
        #region TitleId
        private TitleVM _titleVM;

        public SolderVM()
        {
        }

        public TitleVM TitleVM
        {
            get => _titleVM ?? (_titleVM = new TitleVM(TitleId, SaveStatuses.Unchanged));
            set
            {
                _titleVM = value;
                OnPropertyChanged(()=>TitleVM);
            }
        }
        public int TitleId
        {
            get => Item.TitleId;
            set
            {
                SetPropertyValue(()=>TitleId, value, ref Item.TitleId);
            }
        }
        
        #endregion


        public string DescrForFind
        {
            get => SolderInfo;
        }
        public string SolderInfo
        {
            get => TitleVM.Descr +" "+ SecondName+" " + Name + FatherName + " " +DivisionVM.Name;
        }
        
    }
}