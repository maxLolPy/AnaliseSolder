using BaseObjectsMVVM;

namespace AnaliseSolder.models.Solder
{
    public class SolderM : EntityModel
    {
        public int? SolderId; 
        
        public string Name;
        public string SecondName;
        public string FatherName;

        public int DivisionId;
        
        public bool IsOficer;
        
        public int TitleId; 
        
    }
}