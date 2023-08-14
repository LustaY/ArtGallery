using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Domain.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<Rating>> GetAll()
        {
            return await _ratingRepository.GetAll();
        }

        public async Task<Rating> GetById(int id)
        {
            return await _ratingRepository.GetById(id);
        }

        public async Task<Rating> Add(Rating rating)
        {
            await _ratingRepository.Add(rating);
            return rating;
        }

        public async Task<Rating> Update(Rating rating)
        {
            await _ratingRepository.Update(rating);
            return rating;
        }

        public async Task<bool> Delete(Rating rating)
        {
            await _ratingRepository.Delete(rating);
            return true;
        }

        public async Task<IEnumerable<Rating>> GetRatingsByItem(int itemId)
        {
            return await _ratingRepository.GetRatingsByItem(itemId);
        }

        public async Task<IEnumerable<Rating>> Search(int ratingValue)
        {
            return await _ratingRepository.Search(x => x.RatingValue == ratingValue);
        }

        public void Dispose()
        {
            _ratingRepository?.Dispose();
        }
    }
}
