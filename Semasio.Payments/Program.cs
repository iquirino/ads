using MassTransit;
using Semasio.Payments.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Semasio.Payments.Services;
using Semasio.Payments.DataAccess;

namespace Semasio.Payments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
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
            });

            builder.Services.AddDbContext<PaymentDbContext>(options =>
            {
                options.UseSqlite("Data Source=payment.db");
            });

            builder.Services.AddScoped<PaymentRepository>();
            builder.Services.AddScoped<PaymentService>();

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