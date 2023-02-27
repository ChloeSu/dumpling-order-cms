using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dumplingsOrderBackend.Interfaces;
using dumplingsOrderBackend.Models;

namespace dumplingsOrderBackend.Handlers
{
    public class ItemHandler: IItemHandler
    {
        private readonly IItemRepository _repo;
        
        public ItemHandler(IItemRepository repo)
        {
            _repo = repo;   
        }

        public async Task<ItemDto> GetByIdAsync(string key) 
        {
            return await _repo.GetByIdAsync(key);
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync() 
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddAsync(ItemDto itemDto) 
        {
            await _repo.AddAsync(itemDto);
        }

        public async Task UpdateAsync(ItemDto itemDto) 
        {
            await _repo.UpdateAsync(itemDto);
        }

        public async Task DeleteAsync(string key) 
        {
            await _repo.DeleteAsync(key);
        }
    }
}