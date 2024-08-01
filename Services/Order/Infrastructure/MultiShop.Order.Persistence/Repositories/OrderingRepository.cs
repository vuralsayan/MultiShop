using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;

        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<Ordering>> GetOrderingsByUserIdAsync(string id)
        {
            var values = await _context.Orderings.Where(x => x.UserID == id).ToListAsync();
            return values;
        }
    }
}
