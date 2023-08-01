using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemService;

        public CategoryService(ICategoryRepository categoryRepository, IItemRepository itemService)
        {
            _categoryRepository = categoryRepository;
            _itemService = itemService;
        }

        public async Task<IEnumerable<Category>> GetAll() { return await _categoryRepository.GetAll(); }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(x => x.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.Add(category);
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(x => x.Name == category.Name && x.Id != category.Id).Result.Any())
                return null;
            await _categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Delete(Category category)
        {
            var books = await _itemService.GetItemsByCategory(category.Id);
            if (books.Any()) return false;
            await _categoryRepository.Delete(category);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await _categoryRepository.Search(x => x.Name.Contains(categoryName));
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
