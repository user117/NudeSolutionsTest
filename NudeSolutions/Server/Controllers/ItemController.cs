using NudeSolutions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NudeSolutions.Server.Repositories;

namespace NudeSolutions.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository _itemRepo;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ItemController> logger;

        public ItemController(ILogger<ItemController> logger, ItemRepository itemRepo)
        {
            this.logger = logger;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var items = await _itemRepo.GetAllItems();
            return items.OrderBy(x=>x.CategoryName);
        }

        [HttpPost]
        public async Task Add(Item item)
        {
            var rng = item;
            await _itemRepo.AddItem(item);

        }

        [HttpDelete("{itemId}")]
        public async Task Delete(int itemId)
        {
            await _itemRepo.DeleteItem(itemId);

        }
    }
}
