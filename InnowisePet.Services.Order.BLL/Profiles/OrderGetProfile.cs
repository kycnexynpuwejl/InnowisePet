using AutoMapper;
using InnowisePet.Models.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Profiles;

public class OrderGetProfile : Profile
{
    public OrderGetProfile()
    {
        CreateMap<Models.Entities.OrderModel, OrderGetDto>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(p => p.Firstname, opt => opt.MapFrom(p => p.Firstname))
            .ForMember(p => p.Lastname, opt => opt.MapFrom(p => p.Lastname))
            .ForMember(p => p.Address, opt => opt.MapFrom(p => p.Address))
            .ForMember(p => p.City, opt => opt.MapFrom(p => p.City))
            .ForMember(p => p.Country, opt => opt.MapFrom(p => p.Country));
    }
}