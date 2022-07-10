using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RESTate.Datos.Repositorios;

namespace RESTate.Datos
{
    public static class Extensiones
    {
        public static IServiceCollection AddCapaDatos(this IServiceCollection servicios, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("RESTateDb");

            servicios.AddDbContext<RESTateContext>(options => options.UseSqlServer("name=ConnectionStrings:RESTateDb"));

            servicios.AddTransient<IInmuebleRepository, InmuebleRepository>();

            return servicios;
        }
    }
}
