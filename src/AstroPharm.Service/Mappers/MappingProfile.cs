﻿using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.Users;
using AutoMapper;

namespace AstroPharm.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User DTOs
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<UserForCreationDto, User>().ReverseMap();
        CreateMap<UserForUpdateDto, User>().ReverseMap();

        //Medication DTOs
        CreateMap<Medication, MedicationForResultDto>().ReverseMap();
        CreateMap<MedicationForCreationDto, Medication>().ReverseMap();
        CreateMap<MedicationForUpdateDto, Medication>().ReverseMap();
        
        //Catalog DTOs
        CreateMap<Catalog, CatalogForResultDto>().ReverseMap();
        CreateMap<CatalogForCreationDto, Catalog>().ReverseMap();
        CreateMap<CatalogForUpdateDto, Catalog>().ReverseMap();

        //Category DTOs
        CreateMap<Category, CategoryForResultDto>().ReverseMap();
        CreateMap<CategoryForCreationDto, Category>().ReverseMap();
        CreateMap<CategoryForUpdateDto, Category>().ReverseMap();

        //Order DTOs
        CreateMap<Order, OrderForCreationDto>().ReverseMap();
        CreateMap<Order, OrderForResultDto>().ReverseMap();
        CreateMap<Order, OrderForUpdateDto>().ReverseMap();
    }
}
