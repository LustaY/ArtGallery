using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Interfaces
{
    public interface ICommentService : IDisposable
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(int id);
        Task<Comment> Add(Comment comment);
        Task<Comment> Update(Comment comment);
        Task<bool> Delete(Comment comment);
        Task<IEnumerable<Comment>> Search(string commentValue);
        Task<IEnumerable<Comment>> GetCommentsByItem(int itemId);
    }
}
