using System.Threading.Tasks;
using System.Collections.Generic;

namespace dumplingsOrderBackend.Interfaces
{
    public interface IBaseRepository<TDto,TCloudStore>
    {
        public Task DeleteAsync(string key);
        public Task UpdateAsync(TDto item);
        public Task AddAsync(TDto item);
        public Task<IEnumerable<TDto>> GetAllAsync();
        public Task<TDto> GetByIdAsync(string key);
        public Task<string> GetSeedId();
    }
}