using Application.Features.OrdersFeatures.Commands.CreateOrder;
using Application.Features.OrdersFeatures.Queries.GetAllOrders;
using Application.Features.OrdersFeatures.Queries.GetByIdOrder;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Orders, GetAllOrdersDto>()
                .ForMember(dest => dest.StatusString, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Orders, GetByIdOrderDto>()
                .ForMember(dest => dest.StatusString, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}