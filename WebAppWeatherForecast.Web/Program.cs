
using AutoMapper;
using WebAppWeatherForecast.Web.DomainServices;
using WebAppWeatherForecast.Web.DomainServices.Base;

namespace WebAppWeatherForecast.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ISynopticDataAccessService, SynopticDataAccessService>();
            builder.Services.AddScoped<ISynopticDataService, SynopticDataService>();
            builder.Services.AddScoped<ITranslatorService, TranslatorService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
