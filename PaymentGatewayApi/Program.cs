
using Core.Models.GlobalModels;
using PaymentService;
using Core.Middlewares.Middlewares;

namespace PaymentGatewayApi
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

            // Inject internal service
            builder.Services.AddPaymentServices(builder.Configuration);
            builder.Services.AddScoped<RequestContextData>();

            var app = builder.Build();

            // Inject middlewares
            app.UseRequestContext();

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
