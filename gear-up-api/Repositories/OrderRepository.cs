using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gear_up_api.Models;
using gear_up_api.Context;

namespace gear_up_api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GearUpDbContext _dbContext;

        public OrderRepository(GearUpDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.Cart)
                    .ThenInclude(c => c.CartItems)
                        .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}