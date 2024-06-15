using System.Threading.Tasks;
using gear_up_api.Models;

namespace gear_up_api.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
    }
}
