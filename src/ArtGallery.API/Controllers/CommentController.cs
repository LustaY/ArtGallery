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
    public class CommentController : MainController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommentResultDto>>(comments));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null) return NotFound();
            return Ok(_mapper.Map<CommentResultDto>(comment));
        }

        [HttpGet]
        [Route("search/{itemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCommentsByItem(int itemId)
        {
            var comments = await _commentService.GetCommentsByItem(itemId);
            if (comments == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<CommentResultDto>>(comments));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(CommentAddDto commentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var comment = _mapper.Map<Comment>(commentDto);
            var commentResult = await _commentService.Add(comment);
            if (commentResult == null) return BadRequest();
            return Ok(_mapper.Map<CommentResultDto>(commentResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, CommentEditDto commentDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _commentService.Update(_mapper.Map<Comment>(commentDto));
            return Ok(commentDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentService.GetById(id);
            if (comment == null) return NotFound();
            var result = await _commentService.Delete(comment);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
