using AutoMapper;
using LibraCoffee.Entities.Models;
using LibraCoffee.Entities.Dtos;

namespace LibraCoffee.Core.AutoMapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Coffee, CoffeeDto>();
            CreateMap<CoffeeDto, Coffee>()
                .ForMember(c => c.CoffeeId, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.CustomerId, opt => opt.Ignore());

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>()
                .ForMember(o => o.OrderId, opt => opt.Ignore());

            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>()
                .ForMember(o => o.OrderId, opt => opt.Ignore());
        }
    }
}