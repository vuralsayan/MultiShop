using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        Task<List<Ordering>> GetOrderingsByUserIdAsync(string id);
    }
}
