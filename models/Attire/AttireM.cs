using System;
using BaseObjectsMVVM;

namespace AnaliseSolder.models.Attire
{
    public class AttireM : EntityModel
    {
        public override int? ItemId
        {
            get => AttireId;
            set => AttireId = value;
        }

        public int? AttireId;

        public int? SolderId;

        public int? PlaceId;

        public string Descr;

        public DateTime DateAttire = DateTime.Today;

        public int? ResponsibleId;

        public bool IsPositive;
    }
}