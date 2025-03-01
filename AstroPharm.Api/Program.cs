
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Rasm lar yoki va hakazo yoki Loglarni yozish uchun Static Fayldan Foydalanish
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
