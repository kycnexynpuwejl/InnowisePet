using AutoMapper;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class StorageGetProfile : Profile
{
    public StorageGetProfile()
    {
        CreateMap<StorageModel, StorageGetDto>().ReverseMap();
        CreateMap<StorageModel, StorageGetDtoList>().ReverseMap();
    }
}