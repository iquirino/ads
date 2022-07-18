using MassTransit;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Semasio.Ads.Consumers;
using Semasio.Ads.DataAccess;
using Semasio.Ads.DataAccess.Repositories;
using Semasio.Ads.Domain.Repositories;
using Semasio.Ads.Services;

namespace Semasio.Ads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });

                config.AddConsumer<PaymentConfirmedConsumer>();
            });

            builder.Services.AddDbContext<AdsDbContext>(options =>
            {
                options.UseSqlite("Data Source=ads.db");
            });

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
            builder.Services.AddScoped<IStrategyRepository, StrategyRepository>();

            builder.Services.AddScoped<CampaignService>();
            builder.Services.AddScoped<StrategyService>();

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