using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RESTate.Datos;
using RESTate.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTate.Servicios
{
    public static class Extensiones
    {
        public static IServiceCollection AddCapaServicios(this IServiceCollection servicios, IConfiguration configuration)
        {
            servicios.AddCapaDatos(configuration);

            servicios.AddTransient<IInmuebleService, InmuebleService>();
            servicios.AddTransient<IContactoService, ContactoService>();

            return servicios;
        }
    }
}
