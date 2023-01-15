using System;
using System.Data;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Division
{
    public class DivisionVM : EntityViewModel<DivisionM, DivisionSql>
    {
        public DivisionVM(DataRow row)
        {
            Item = new DivisionM();
            ParseArguments(row);
        }
        
        public DivisionVM(int divisionId, SaveStatuses status):base(divisionId, status)
        {
        }
        public DivisionVM():base()
        {
        }
        

        public override void ParseArguments(DataRow row)
        {
            Item.IdDivision = Int32.Parse(row.ItemArray[0].ToString());
            Item.Name = row.ItemArray[1].ToString();
        }

        #region Name

        public string Name {
            get => Item.Name;
            set
            {
                SetPropertyValue(()=>Name, value, ref Item.Name);
            }
        }
        #endregion
        
        #region IdDivision

        public int? IdDivision
        {
            get => Item.IdDivision;
            set
            {
                SetPropertyValue(()=>IdDivision, value, ref Item.IdDivision);
            }
        }

        public override int? ItemId
        {
            get => IdDivision;
            set => IdDivision = value;
        }

        #endregion


    }
}