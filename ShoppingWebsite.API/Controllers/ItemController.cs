﻿using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Item>>> GetAllItems()
        {
            var items = await _itemService.GetItemsAsync();
            return Ok(items);
        }

        [HttpGet("find/{id}")]
        public async Task<ActionResult<Item>> GetItemById(Guid id)
        {
            var item = await _itemService.GetItemAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateItem(ItemDto itemDto)
        {
            await _itemService.CreateItemAsync(itemDto);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateItem(ItemDto itemDto)
        {
            var updated = await _itemService.UpdateItemAsync(itemDto);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var deleted = await _itemService.DeleteItemAsync(id);
            return deleted ? Ok() : NotFound();
        }
    }
}
