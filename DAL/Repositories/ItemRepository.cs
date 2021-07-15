using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    public class ItemRepository : DataEntityRepository<Item>, IItemRepository
    {
        public IEnumerable<Item> GetAllByListId(int listId)
        {
            return _collection.Where(c => c.ItemListId == listId);
        }

        public Item Create(int listId, string name)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new Exception("Item must include a name");
            }
            Item item = new Item();
            item.Name = name;
            item.ItemListId = listId;
            
            var lastOrder = 0;
            var lastItem = GetAllByListId(listId).OrderByDescending(i => i.Order).FirstOrDefault();
            if(lastItem != null)
            {
                lastOrder = lastItem.Order + 1;
            }

            item.Order = lastOrder;
            item.IsChecked = false;

            return Create(item);
        }

        public Item Update(int id, string name, bool? isChecked)
        {
            Item item = GetById(id);
            if(!String.IsNullOrEmpty(name))
            {
                item.Name = name;
            }
            if(isChecked.HasValue)
            {
                item.IsChecked = isChecked.Value;
            }
            return Update(item);
        }
    }
}