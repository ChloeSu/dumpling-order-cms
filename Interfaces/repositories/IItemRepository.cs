using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dumplingsOrderBackend.Models;

namespace dumplingsOrderBackend.Interfaces
{
    public interface IItemRepository: IBaseRepository<ItemDto, Item>
    {
        
    }
}