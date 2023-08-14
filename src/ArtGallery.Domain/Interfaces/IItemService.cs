using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Interfaces
{
    public interface IItemService : IDisposable
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetById(int id);
        Task<Item> Add(Item item);
        Task<Item> Update(Item item);
        Task<bool> Delete(Item item);
        Task<IEnumerable<Item>> GetItemsByCategory(int categoryId);
        Task<IEnumerable<Item>> Search(string itemName);
        Task<IEnumerable<Item>> SearchItemWithCategory(string searchedValue);
    }
}
