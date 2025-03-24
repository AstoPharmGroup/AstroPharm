﻿using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Products;
using AstroPharm.Domain.Entities.SubCategories;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.DTOs.CartItems;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.DTOs.Wishlists;
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

        // Wishlist
        CreateMap<WishList,WishlistForCreationDto>().ReverseMap();
        CreateMap<WishList,WishlistForResultDto>().ReverseMap();

        // Banner
        CreateMap<Banner, BannerForResultDto>().ReverseMap();
        CreateMap<BannerForCreationDto, Banner>().ReverseMap();
        CreateMap<BannerForUpdateDto, Banner>().ReverseMap();

        // CartItem
        CreateMap<CartItem, CartItemForResultDto>().ReverseMap();
        CreateMap<CartItemForCreationDto, CartItem>().ReverseMap();
        CreateMap<CartItemForUpdateDto, CartItem>().ReverseMap();

        // Payment
        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();
    }
}
