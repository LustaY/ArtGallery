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
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CommentValue)
                .IsRequired();

            builder.Property(x => x.CommentAuthor)
                .IsRequired();

            builder.Property(x => x.ItemId)
                .IsRequired();

            builder.ToTable("Comment");

        }
    }
}
