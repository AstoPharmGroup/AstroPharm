using AstroPharm.Api.Extensions;
using AstroPharm.Api.Middlewares;
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
            #region
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
               .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #endregion
            // Add : CORS
            #region
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader());
            });
            #endregion
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
            #region
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "DELETE")
                {
                    context.Response.StatusCode = 405;
                    await context.Response.WriteAsync("This method is not allowed");
                    return;
                }
                ;
                await next();
            });
            #endregion
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Static Middleware
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseMiddleware<LoggingMiddleware>();
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