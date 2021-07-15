using DAL.Models;

namespace API.Models
{
    public class SimpleItemDto : EntityDto
    {
        public SimpleItemDto(Item item)
        {
            Name = item.Name;
            Id = item.Id;
            ItemListId = item.ItemListId;
            Order = item.Order;
            IsChecked = item.IsChecked;
        }

        public string Name {get; set;}
        public int ItemListId {get; set;}
        public int Order {get; set;}
        public bool IsChecked {get; set;}
    }
}