using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Interfaces
{
    public interface IRatingService : IDisposable
    {
        Task<IEnumerable<Rating>> GetAll();
        Task<Rating> GetById(int id);
        Task<Rating> Add(Rating rating);
        Task<Rating> Update(Rating rating);
        Task<bool> Delete(Rating rating);
        Task<IEnumerable<Rating>> Search(int ratingValue);
        Task<IEnumerable<Rating>> GetRatingsByItem(int itemId);
    }
}
