using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NudeSolutions.Data;
using NudeSolutions.Shared;

namespace NudeSolutions.Server.Repositories
{
    public class ItemRepository
    {
        private readonly NudeDbContext _context;

        public ItemRepository(NudeDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task DeleteItem(int itemId)
        {
            var item = _context.Items.First(x => x.ItemId == itemId);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
