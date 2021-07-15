using DAL.Models;

namespace DAL.Repositories
{
    public interface IItemListRepository : IDataEntityRepository<ItemList>
    {
        ItemList Create(string name, string description);

        ItemList Update(int id, string name, string description);
    }
}