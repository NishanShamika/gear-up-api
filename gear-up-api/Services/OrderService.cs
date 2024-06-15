using System;
using System.Threading.Tasks;
using AutoMapper;
using gear_up_api.Models;
using gear_up_api.DTOs;
using Microsoft.AspNetCore.Http;
using gear_up_api.Repositories;
using Org.BouncyCastle.Crypto;
using gear_up_api.Exceptions;

namespace gear_up_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OrderDto> CreateOrderAsync(int cartId, OrderCreateDto orderDto)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                throw new NotFoundException("Cart not found or empty.");
            }

            var order = _mapper.Map<Order>(orderDto);
            order.CartId = cartId;
            order.OrderDate = DateTime.UtcNow;

            await _orderRepository.AddOrderAsync(order);

            return _mapper.Map<OrderDto>(order);
        }


        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new NotFoundException("Order not found.");
            }

            return _mapper.Map<OrderDto>(order);
        }
    }
}
