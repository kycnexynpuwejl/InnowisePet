using AutoMapper;
using InnowisePet.Models.DTO.Storage;
using InnowisePet.Models.Entities;

namespace InnowisePet.Services.Storage.BLL.Profiles;

public class StorageUpdateProfile : Profile
{
    public StorageUpdateProfile()
    {
        CreateMap<StorageUpdateDto, StorageModel>().ReverseMap();
    }
}