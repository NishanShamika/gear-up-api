using System.Collections.Generic;
using System.Threading.Tasks;
using gear_up_api.Models;
using gear_up_api.Repositories;

namespace gear_up_api.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            return await _cartRepository.GetCartByIdAsync(id);
        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
            return await _cartRepository.GetAllCartsAsync();
        }

        public async Task<Cart> AddCartAsync(Cart cart)
        {
            return await _cartRepository.AddCartAsync(cart);
        }

        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            return await _cartRepository.UpdateCartAsync(cart);
        }

        public async Task<bool> DeleteCartAsync(int id)
        {
            return await _cartRepository.DeleteCartAsync(id);
        }
    }
}
