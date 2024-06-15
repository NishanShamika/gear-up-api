using System.Threading.Tasks;
using gear_up_api.Models;
using gear_up_api.DTOs;

namespace gear_up_api.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(int cartId, OrderCreateDto orderDto);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
    }
}
