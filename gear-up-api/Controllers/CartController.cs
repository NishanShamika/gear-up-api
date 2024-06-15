using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using gear_up_api.Models;
using gear_up_api.Services;
using gear_up_api.DTOs;
using System.ComponentModel.DataAnnotations;

namespace gear_up_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            try
            {
                var carts = await _cartService.GetAllCartsAsync();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the carts. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            try
            {
                var cart = await _cartService.GetCartByIdAsync(id);
                if (cart == null)
                {
                    return NotFound("Cart not found.");
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the cart. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart(CreateCartRequest request)
        {
            if (request.UserId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            if (request.CartItems == null || request.CartItems.Count == 0)
            {
                return BadRequest("Cart must contain at least one cart item.");
            }

            var cart = new Cart
            {
                UserId = request.UserId,
                CartItems = request.CartItems.Select(ci => new CartItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            var newCart = await _cartService.AddCartAsync(cart);
            return CreatedAtAction(nameof(GetCart), new { id = newCart.Id }, newCart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, UpdateCartRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Cart ID mismatch.");
            }

            if (request.CartItems == null || request.CartItems.Count == 0)
            {
                return BadRequest("Cart must contain at least one cart item.");
            }

            var cart = new Cart
            {
                Id = request.Id,
                UserId = request.UserId,
                CartItems = request.CartItems.Select(ci => new CartItem
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            try
            {
                await _cartService.UpdateCartAsync(cart);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the cart. Please try again later.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            try
            {
                var success = await _cartService.DeleteCartAsync(id);
                if (!success)
                {
                    return NotFound("Cart not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the cart. Please try again later.");
            }
        }
    }
}

namespace gear_up_api.DTOs
{
    public class CreateCartRequest
    {
        public int UserId { get; set; }
        public List<CreateCartItemRequest> CartItems { get; set; }
    }

    public class CreateCartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateCartRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<UpdateCartItemRequest> CartItems { get; set; }
    }

    public class UpdateCartItemRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}

