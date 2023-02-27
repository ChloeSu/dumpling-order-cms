using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dumplingsOrderBackend.Interfaces
{
    public interface IBaseHandler<T>
    {
        public Task<T> GetByIdAsync(string key);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task AddAsync(T item);
        public Task UpdateAsync(T item);
        public Task DeleteAsync(string key);
    }
}