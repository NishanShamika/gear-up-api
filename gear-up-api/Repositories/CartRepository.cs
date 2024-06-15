using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gear_up_api.Context;
using gear_up_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gear_up_api.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly GearUpDbContext _context;

        public CartRepository(GearUpDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            try
            {
                return await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the cart.", ex);
            }
        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            try
            {
                return await _context.Carts.Include(c => c.CartItems).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the carts.", ex);
            }
        }

        public async Task<Cart> AddCartAsync(Cart cart)
        {
            try
            {
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while adding the cart.", ex);
            }
        }

        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            try
            {
                _context.Carts.Update(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("An error occurred while updating the cart. It might have been modified or deleted by another process.", ex);
            }
        }

        public async Task<bool> DeleteCartAsync(int id)
        {
            try
            {
                var cart = await _context.Carts.FindAsync(id);
                if (cart == null)
                {
                    return false;
                }

                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("An error occurred while deleting the cart.", ex);
            }
        }
    }
}
