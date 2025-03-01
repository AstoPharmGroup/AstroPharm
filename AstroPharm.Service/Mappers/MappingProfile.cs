using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Users;
using AutoMapper;

namespace AstroPharm.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Shu yerda entity bilan DTO larni map qilasizlar
    
        CreateMap<User, UserForResultDto>();
        CreateMap<UserForCreationDto, User>();
        CreateMap<UserForUpdateDto, User>();
    }
}
