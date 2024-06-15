using Microsoft.EntityFrameworkCore;
using gear_up_api.Context;
using gear_up_api.Models;

namespace gear_up_api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GearUpDbContext _context;

        public ProductRepository(GearUpDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
