using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Services;
using ArtGallery.Infrastructure.Context;
using ArtGallery.Infrastructure.Repositories;

namespace ArtGallery.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ArtGalleryDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();

            return services;
        }
    }
}
