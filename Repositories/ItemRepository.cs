using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using dumplingsOrderBackend.Interfaces;
using dumplingsOrderBackend.Models;

namespace dumplingsOrderBackend.Repositories
{
    public class ItemRepository: BaseRepository<ItemDto, Item>, IItemRepository
    {
        public ItemRepository(IMapper mapper): base(mapper)
        {
            collectionName = Constants.ITEMS;
        }

        public async Task DeleteAsync(string key)
        {
            await _db.Collection(collectionName)
                    .Document(key)
                    .UpdateAsync(new Dictionary<string, object>
                        {
                            { "isDelete", true }
                        });
        }
    }
}