using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Interfaces
{
    public interface IItemRepository: IRepository<Item>
    {
        new Task<List<Item>> GetAll();
        new Task<Item> GetById(int id);
        Task<IEnumerable<Item>> GetItemsByCategory(int categoryId);
        Task<IEnumerable<Item>> SearchItemWithCategory(string searchedValue);
    }
}
