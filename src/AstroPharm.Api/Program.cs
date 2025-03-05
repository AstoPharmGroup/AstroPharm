using AstroPharm.Api.Extensions;
using AstroPharm.Data.DbContexts;
using AstroPharm.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Connect Database
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

            // Add : CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .WithMethods("GET", "POST")
                          .AllowAnyHeader();
                });
            });
            // Add : Controller
            builder.Services.AddControllers();  
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Servicelarni royxatdan o'tkazish
            builder.Services.AddCustomService();

            // Mapper ni royxatdan otkazish
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Use Middleware For Delete Method
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "DELETE")
                {
                    context.Response.StatusCode = 405;
                    await context.Response.WriteAsync("This method is not allowed");
                    return;
                };
                await next();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            // Rasm lar yoki va hakazo yoki Loglarni yozish uchun Static Fayldan Foydalanish
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
