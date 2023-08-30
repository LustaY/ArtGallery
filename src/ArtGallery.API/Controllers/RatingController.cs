using ArtGallery.API.Dtos.Category;
using ArtGallery.API.Dtos.Comment;
using ArtGallery.API.Dtos.Rating;
using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using ArtGallery.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : MainController
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService, IMapper mapper)
        {
            _mapper = mapper;
            _ratingService = ratingService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await _ratingService.GetAll();
            return Ok(_mapper.Map<IEnumerable<RatingResultDto>>(ratings));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _ratingService.GetById(id);
            if (rating == null) return NotFound();
            return Ok(_mapper.Map<RatingResultDto>(rating));
        }

        [HttpGet]
        [Route("get-ratings-by-item/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Rating>>> GetRatingsByItem(int itemId)
        {
            var ratings = _mapper.Map<List<Rating>>(await _ratingService.GetRatingsByItem(itemId));
            if (ratings == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<RatingResultDto>>(ratings));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(RatingAddDto ratingDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var rating = _mapper.Map<Rating>(ratingDto);
            var ratingResult = await _ratingService.Add(rating);
            if (ratingResult == null) return BadRequest();
            return Ok(_mapper.Map<RatingResultDto>(ratingResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, RatingEditDto ratingDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _ratingService.Update(_mapper.Map<Rating>(ratingDto));
            return Ok(ratingDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var rating = await _ratingService.GetById(id);
            if (rating == null) return NotFound();
            var result = await _ratingService.Delete(rating);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
