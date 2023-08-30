using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using ArtGallery.Domain.Services;
using ArtGallery.Infrastructure.Context;
using ArtGallery.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ArtGallery.API.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ArtGalleryDbContext>();

            ////Type type = typeof(Entity);
            //Type type = typeof(Entity);
            //string models = type.Namespace;// "ArtGallery.Domain.Models";
            //string inf = "ArtGallery.Infrastructure";
            //string dom = "ArtGallery.Domain";
            //Module[] moduleArray = type.Assembly.GetModules(true);
            //Module myModule = moduleArray[0];
            //Type[] tArray = myModule.FindTypes(Module.FilterTypeName, "*");
            //List<string> ll = new List<string>();
            //foreach (Type t in tArray.Where(t => t.FullName.Contains(models) && t.Name != type.Name))
            //{
            //    Type x = Type.GetType(dom + ".Interfaces.I" + t.Name + "Repository, " + dom);
            //    Type y = Type.GetType(inf + ".Repositories." + t.Name + "Repository, " + inf);

            //    ;
            //    //Type xx = Type.GetType(dom + ".Interfaces.I" + t.Name + "Service, " + dom);
            //    //Type yy = Type.GetType(dom + ".Services." + t.Name + "Service, " + dom);
            //    var s = 1;
            //    //services.AddScoped<>();
            //}



            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IRatingService, RatingService>();

            return services;
        }

        
              
        
    }
}
