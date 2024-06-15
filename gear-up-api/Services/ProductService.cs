using gear_up_api.Models;
using gear_up_api.Repositories;

namespace gear_up_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }
    }
}
