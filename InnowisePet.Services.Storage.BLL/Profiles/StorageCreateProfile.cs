using AutoMapper;
using InnowisePet.Models.DTO.Storage;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class StorageCreateProfile : Profile
{
    public StorageCreateProfile()
    {
        CreateMap<StorageCreateDto, Models.Entities.StorageModel>().ReverseMap();
    }
}