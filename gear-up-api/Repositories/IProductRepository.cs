using gear_up_api.Models;

namespace gear_up_api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
