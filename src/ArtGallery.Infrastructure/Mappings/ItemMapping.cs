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
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Author)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();
        }
    }
}
