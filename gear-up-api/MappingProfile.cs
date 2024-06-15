using AutoMapper;
using gear_up_api.Models;
using gear_up_api.DTOs;

namespace gear_up_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderDto>();
            // Additional mappings as needed
        }
    }
}
