using DAL.Models;

namespace API.Models
{
    public class SimpleListDto : EntityDto
    {
        public string Name {get; set;}
        public string Description {get; set;}

        public SimpleListDto(ItemList list)
        {
            Id = list.Id;
            Name = list.Name;
            Description = list.Description;
        }
    }
}