using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RESTate.Servicios;
using Serilog;

namespace RESTate.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ILogger logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt")
                .CreateLogger();

            Log.Logger = logger;

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSingleton(logger);

            builder.Services.AddSwaggerGen();

            builder.Services.AddCapaServicios(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Extensiones).Assembly);

            builder.Logging.AddSerilog(logger);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}