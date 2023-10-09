using ArtGallery.Domain.Interfaces;
using ArtGallery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ArtGallery.Domain.Models;

namespace ArtGallery.Infrastructure.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ArtGalleryDbContext context) : base(context) { }

        public override async Task<List<Item>> GetAll()
        {
            //var x = await Db.Items.AsNoTracking().Include(x => x.Category)
            //    .OrderBy(x => x.Name)
            //    .ToListAsync();

            return await Db.Items.AsNoTracking().Include(x => x.Category)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<Item> GetById(int id)
        {
            return await Db.Items.AsNoTracking().Include(x => x.Category)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
         }

        public async Task<IEnumerable<Item>> GetItemsByCategory(int categoryId)
        {
            //return await Search(x => x.CategoryId == categoryId);
            return await Db.Items.AsNoTracking()
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByPage(int categoryId, int page , int size)
        {
            //var position = 20;
            //var nextPage = context.Posts
            //    .OrderBy(b => b.PostId)
            //    .Skip(position)
            //    .Take(10)
            //    .ToList();
            //return await Search(x => x.CategoryId == categoryId);
            var position = (page-1) * size;
            return await Db.Items.AsNoTracking()
                //.Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .Skip(position)
                .Take(size)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> SearchItemWithCategory(string searchedValue)
        {
            return await Db.Items.AsNoTracking()
                //.Include(x => x.Category)
                .Where(x => x.Name.Contains(searchedValue) ||
                            x.Price.Value.ToString().Contains(searchedValue)
                            //x.Description.Contains(searchedValue)
                            //|| x.Category.Name.Contains(searchedValue)
                            )

                .ToListAsync();
        }
    }
}
