#region
using AstroPharm.Data.IRepositories;

using AstroPharm.Data.Repositories;
using AstroPharm.Service.Interfaces.Banners;
using AstroPharm.Service.Interfaces.CartItems;
using AstroPharm.Service.Interfaces.Catalogs;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Emails;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Order;
using AstroPharm.Service.Interfaces.OrderDetails;
using AstroPharm.Service.Interfaces.Payments;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Interfaces.Wishlists;
using AstroPharm.Service.Services.Banners;
using AstroPharm.Service.Services.CartItems;
using AstroPharm.Service.Services.Catalogs;
using AstroPharm.Service.Services.Categories;
using AstroPharm.Service.Services.Emails;
using AstroPharm.Service.Services.Medications;
using AstroPharm.Service.Services.Payments;
using AstroPharm.Service.Services.Token;
using AstroPharm.Service.Services.Users;
using AstroPharm.Service.Services.WishLists;
#endregion
namespace AstroPharm.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Shu yerda Repository lar va Service , Interface lar royxatdan otkazasiz
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // FOlder Name : User

        services.AddScoped<IUserInterface, UserService>();
        // Folder Name : Medication
        services.AddScoped<IMedicationInterface, MedicationService>();

        // Folder Name : Catalog
        services.AddScoped<ICatalogInterface, CatalogService>();

        // Fodler Name : Category
        services.AddScoped<ICategoryInterface, CategoryService>();

        // Folder Name : Banner
        services.AddScoped<IBannerInterface, BannerService>();

        // Fodler Name : Order
        services.AddScoped<IOrderInterface, OrderService>();

        services.AddScoped<IOrderDetailInterface, OrderDetailService>();

        // Fodler Name : Cart Item
        services.AddScoped<ICartItemInterface, CartItemService>();
        // Payment
        services.AddScoped<IPaymentInterface, PaymentService>();
        // Authorization
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IWishlistInterface, WishListService>();
        // Token
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<ILanguageInterface, LanguageService>();

        services.AddScoped<IEmailService, EmailService>();

    }

}
