using AutoMapper;
using InnowisePet.Models.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Profiles;

public class OrderUpdateProfile : Profile
{
    public OrderUpdateProfile()
    {
        CreateMap<OrderUpdateDto, Models.Entities.OrderModel>()
            .ForMember(p => p.Quantity, opt => opt.MapFrom(p => p.Quantity))
            .ForMember(p => p.OrderStatus, opt => opt.MapFrom(p => p.OrderStatus))
            .ForMember(p => p.ProductId, opt => opt.MapFrom(p => p.ProductId))
            .ForMember(p => p.Firstname, opt => opt.MapFrom(p => p.Firstname))
            .ForMember(p => p.Lastname, opt => opt.MapFrom(p => p.Lastname))
            .ForMember(p => p.Address, opt => opt.MapFrom(p => p.Address))
            .ForMember(p => p.City, opt => opt.MapFrom(p => p.City))
            .ForMember(p => p.Country, opt => opt.MapFrom(p => p.Country));
    }
}