using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Service.DTOs.Banners;
using AstroPharm.Service.DTOs.CartItems;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Couriers;
using AstroPharm.Service.DTOs.Deliveries;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.PharmacyBranchs;
using AstroPharm.Service.DTOs.PharmacyStocks;
using AstroPharm.Service.DTOs.Users;
using AstroPharm.Service.DTOs.WhishLists;
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


        CreateMap<WishList, WishListForCreationDto>().ReverseMap();
        CreateMap<WishList, WishListForResultDto>().ReverseMap();
        CreateMap<WishList, WishListForUpdateDto>().ReverseMap();


        CreateMap<Banner, BannerForResultDto>().ReverseMap();
        CreateMap<BannerForCreationDto, Banner>().ReverseMap();
        CreateMap<BannerForUpdateDto, Banner>().ReverseMap();

        CreateMap<CartItem, CartItemForResultDto>().ReverseMap();
        CreateMap<CartItemForCreationDto, CartItem>().ReverseMap();
        CreateMap<CartItemForUpdateDto, CartItem>().ReverseMap();

        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();

        CreateMap<Courier, CourierForResultDto>().ReverseMap();
        CreateMap<CourierForCreationDto, Courier>().ReverseMap();
        CreateMap<CourierForUpdateDto, Courier>().ReverseMap();

        CreateMap<Delivery, DeliveryForResultDto>().ReverseMap();
        CreateMap<DeliveryForCreationDto, Delivery>().ReverseMap();
        CreateMap<DeliveryForUpdateDto, Delivery>().ReverseMap();

        CreateMap<PharmacyStock, PharmacyStockForCreationDto>().ReverseMap();
        CreateMap<PharmacyStock, PharmacyStockForUpdateDto>().ReverseMap();
        CreateMap<PharmacyStock, PharmacyStockForResult>().ReverseMap();

        CreateMap<PharmacyBranch, PharmacyBranchForCreationDto>().ReverseMap();
        CreateMap<PharmacyBranchForResultDto, PharmacyBranch>().ReverseMap();
        CreateMap<PharmacyBranchForResultDto, PharmacyBranch>().ReverseMap();


    }
}
