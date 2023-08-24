using ArtGallery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ArtGallery.Infrastructure.Context
{
    public class ArtGalleryDbContext : DbContext
    {
        public ArtGalleryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtGalleryDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Entity<Item>()
            .Property(e => e.UpdateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Item>()
            .Property(e => e.CreateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Category>()
            .Property(e => e.UpdateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Category>()
            .Property(e => e.CreateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Rating>()
            .Property(e => e.UpdateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Rating>()
            .Property(e => e.CreateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Comment>()
            .Property(e => e.UpdateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Comment>()
            .Property(e => e.CreateDate)
            .HasDefaultValueSql("GETUTCDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
