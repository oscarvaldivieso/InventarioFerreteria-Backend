﻿using Ferreteria.BussinessLogic.Services;
using Ferreteria.DataAccess;
using Ferreteria.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<DepartamentoRepository>();
            services.AddScoped<EstadoCivilRepository>();
            services.AddScoped<MunicipioRepository>();
            services.AddScoped<ClienteRepository>();
            services.AddScoped<CargoRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<MarcaRepository>();
            services.AddScoped<MedidaRepository>();

            FerreteriaContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralServices>();
            services.AddScoped<FerreteriaServices>();
            services.AddScoped<ProductoServices>();
        }
    }
}