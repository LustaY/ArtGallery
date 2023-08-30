using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }   

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _itemRepository.GetAll();
        }

        public async Task<Item> GetById(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public async Task<Item> Add(Item item)
        {
            if (_itemRepository.Search(x => x.Name == item.Name).Result.Any())
                return null;

            await _itemRepository.Add(item);
            return item;
        }
        public async Task<Item> Update(Item item)
        {
            if (_itemRepository.Search(x => x.Name == item.Name && x.Id != item.Id).Result.Any())
                return null;

            await _itemRepository.Update(item);
            return item;
        }

        public async Task<bool> Delete(Item item)
        {
            await _itemRepository.Delete(item);
            return true;
        }

        public async Task<IEnumerable<Item>> GetItemsByCategory(int categoryId)
        {
            return await _itemRepository.GetItemsByCategory(categoryId);
        }
        public async Task<IEnumerable<Item>> GetItemsByPage(int categoryId, int page, int size) 
        {
            return await _itemRepository.GetItemsByPage(categoryId,page, size );
        }

        public async Task<IEnumerable<Item>> Search(string itemName)
        {
            return await _itemRepository.Search(x => x.Name.Contains(itemName));
        }

        public async Task<IEnumerable<Item>> SearchItemWithCategory(string searchedValue)
        {
            return await _itemRepository.SearchItemWithCategory(searchedValue);
        }

        public void Dispose() 
        { 
            _itemRepository.Dispose();
        }
    }
}
