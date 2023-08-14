using ArtGallery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Author)
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Price);


            builder.Property(x => x.Location);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);

            builder.HasMany(x => x.Ratings)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId);

            builder.Property(x => x.CategoryId)
                .IsRequired();
        }
    }
}
