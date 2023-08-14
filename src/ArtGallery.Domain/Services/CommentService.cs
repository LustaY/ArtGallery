using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _commentRepository.GetAll();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _commentRepository.GetById(id);
        }

        public async Task<Comment> Add(Comment comment)
        {
            await _commentRepository.Add(comment);
            return comment;
        }

        public async Task<Comment> Update(Comment comment)
        {
            await _commentRepository.Update(comment);
            return comment;
        }

        public async Task<bool> Delete(Comment comment)
        {
            await _commentRepository.Delete(comment);
            return true;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByItem(int itemId)
        {
            return await _commentRepository.GetCommentsByItem(itemId);
        }

        public async Task<IEnumerable<Comment>> Search(string commentValue)
        {
            return await _commentRepository.Search(x => x.CommentValue.Contains(commentValue));
        }

        public void Dispose()
        {
            _commentRepository?.Dispose();
        }
    }
}
