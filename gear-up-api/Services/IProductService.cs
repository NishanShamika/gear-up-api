using gear_up_api.Models;
using gear_up_api.Repositories;

namespace gear_up_api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
