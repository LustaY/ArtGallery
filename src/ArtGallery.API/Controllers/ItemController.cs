using ArtGallery.API.Dtos.Item;
using ArtGallery.Domain.Interfaces;
using ArtGallery.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : MainController
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _itemService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ItemResultDto>>(items));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemService.GetById(id);

            if (item == null) return NotFound();

            return Ok(_mapper.Map<ItemResultDto>(item));
        }

        [HttpGet]
        [Route("get-items-by-category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemsByCategory(int categoryId)
        {
            var items = await _itemService.GetItemsByCategory(categoryId);

            if (!items.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<ItemResultDto>>(items));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(ItemAddDto itemDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var item = _mapper.Map<Item>(itemDto);
            var itemResult = await _itemService.Add(item);

            if (itemResult == null) return BadRequest();

            return Ok(_mapper.Map<ItemResultDto>(itemResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, ItemEditDto itemDto)
        {
            if (id != itemDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _itemService.Update(_mapper.Map<Item>(itemDto));

            return Ok(itemDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemService.GetById(id);
            if (item == null) return NotFound();

            await _itemService.Delete(item);

            return Ok();
        }

        [HttpGet]
        [Route("search/{itemName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Item>>> Search(string itemName)
        {
            var items = _mapper.Map<List<Item>>(await _itemService.Search(itemName));

            if (items == null || items.Count == 0) return NotFound("None item was founded");

            return Ok(items);
        }

        [HttpGet]
        [Route("search-item-with-category/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Item>>> SearchItemkWithCategory(string searchedValue)
        {
            var items = _mapper.Map<List<Item>>(await _itemService.SearchItemWithCategory(searchedValue));

            if (!items.Any()) return NotFound("None item was founded");

            return Ok(_mapper.Map<IEnumerable<ItemResultDto>>(items));
        }
    }
}
