using AutoMapper;
using InnowisePet.DTO.Order;

namespace InnowisePet.Services.Order.BLL.Profiles;

public class OrderCreateProfile : Profile
{
    public OrderCreateProfile()
    {
        CreateMap<OrderCreateDto, Models.Entities.OrderModel>()
            .ForMember(p => p.Id, opt => opt.MapFrom(p => Guid.NewGuid()));
    }
}