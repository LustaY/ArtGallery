using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using ArtGallery.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ArtGalleryDbContext context) : base(context) { }
    }
}
