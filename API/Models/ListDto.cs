using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace API.Models
{
    public class ListDto : SimpleListDto
    {
        public List<SimpleItemDto> Items {get; set;}

        public ListDto(ItemList list, List<Item> items) : base(list)
        {
            Items = items.Select(item => new SimpleItemDto(item)).ToList();
        }
    }
}