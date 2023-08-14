using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using ArtGallery.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Repositories
{
    public class CommentRepository: Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ArtGalleryDbContext context) : base(context) { }

        public async Task<IEnumerable<Comment>> GetCommentsByItem(int itemId)
        {
            return await Search(x => x.ItemId == itemId);
        }
    }
}
