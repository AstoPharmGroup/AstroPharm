﻿using AstroPharm.Data.IRepositories;
using AstroPharm.Data.Repositories;
using AstroPharm.Service.Interfaces.Catalogs;
using AstroPharm.Service.Interfaces.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Services.Catalogs;
using AstroPharm.Service.Services.Categories;
using AstroPharm.Service.Interfaces.Medications;
using AstroPharm.Service.Interfaces.Users;
using AstroPharm.Service.Services.Medications;
using AstroPharm.Service.Services.Users;
using System.Runtime.CompilerServices;
using AstroPharm.Service.Interfaces.Order;

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

        // Fodler Name : Order
        services.AddScoped<IOrderInterface, OrderService>();
    }
}
