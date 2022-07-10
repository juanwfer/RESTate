﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RESTate.Datos.Entities;
using System.IO;

namespace RESTate.Datos
{
    public class RESTateContext : DbContext
    {
        public RESTateContext() : base() { }
        public RESTateContext(DbContextOptions<RESTateContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("RESTateDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Inmueble> Inmuebles => Set<Inmueble>();
    }
}