using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    public class ItemListRepository : DataEntityRepository<ItemList>, IItemListRepository
    {
        public ItemList Create(string name, string description)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new Exception("List must include a name");
            }
            ItemList list = new ItemList();
            list.Name = name;
            list.Description = description;
            return Create(list);
        }

        public ItemList Update(int id, string name, string description)
        {
            ItemList list = GetById(id);
            if(!String.IsNullOrEmpty(name))
            {
                list.Name = name;
            }
            if(!String.IsNullOrEmpty(description))
            {
                list.Description = description;
            }
            return Update(list);
        }
    }
}