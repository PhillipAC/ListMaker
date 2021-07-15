namespace DAL.Models
{
    public class Item : DataEntity
    {
        public string Name {get; set;}
        public int ItemListId {get; set;}
        public int Order {get; set;}
        public bool IsChecked {get; set;}
    }
}