using DAL.Models;

namespace API.Models
{
    public class SimpleListDto : EntityDto
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int ItemCount {get; set;}

        public SimpleListDto(ItemList list, int itemCount)
        {
            Id = list.Id;
            Name = list.Name;
            Description = list.Description;
            ItemCount = itemCount;
        }
    }
}