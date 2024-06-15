using System.Collections.Generic;
using System.Threading.Tasks;
using gear_up_api.Models;

namespace gear_up_api.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAsync(int id);
        Task<IEnumerable<Cart>> GetAllCartsAsync();
        Task<Cart> AddCartAsync(Cart cart);
        Task<Cart> UpdateCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(int id);
    }
}
