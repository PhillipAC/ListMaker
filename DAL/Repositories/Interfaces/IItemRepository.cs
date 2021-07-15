using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IItemRepository : IDataEntityRepository<Item>
    {
        IEnumerable<Item> GetAllByListId(int listId);

        Item Create(int listId, string name);

        Item Update(int id, string name, bool? isChecked);
    }
}