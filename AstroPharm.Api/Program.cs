using AstroPharm.Api.Extensions;
using AstroPharm.Data.DbContexts;
using AstroPharm.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AstroPharm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ozingizni data bazangizni ulang !!
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Servicelarni royxatdan o'tkazish
            builder.Services.AddCustomService();

            // Mapper ni royxatdan otkazish
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowGetPost", builder =>
                {
                    builder.AllowAnyOrigin()
                           .WithMethods(HttpMethod.Get.ToString(), HttpMethod.Post.ToString())
                           .AllowAnyHeader()
                           .DisallowCredentials();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowGetPost");
            // Rasm lar yoki va hakazo yoki Loglarni yozish uchun Static Fayldan Foydalanish
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
