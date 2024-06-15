using gear_up_api.Models;
using gear_up_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gear_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var Products = await _service.GetAllProducts();
            return Ok(Products);
        }

    }
}
