using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dumplingsOrderBackend.Repositories;
using dumplingsOrderBackend.Interfaces;
using dumplingsOrderBackend.Models;

namespace dumplingsOrderBackend.Controllers
{
    //[ApiController]
    [Route(Constants.ITEMS)]
    public class ItemController : ControllerBase
    {
        private readonly IItemHandler _handler;

        public ItemController(IItemHandler handler)
        {
            _handler = handler;       
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync() 
        {
            return Ok(await _handler.GetAllAsync());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id) 
        {
            return Ok(await _handler.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(
            [FromBody] ItemDto item) 
        {
            await _handler.AddAsync(item);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateByIdAsync(
            [FromBody] ItemDto item) 
        {
            await _handler.UpdateAsync(item);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteIdAsync(string id) 
        {
            await _handler.DeleteAsync(id);
            return Ok();
        }

    }


}