using System;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Interfaces.UoW;
using EGG.Infra.Data.Context;
using EGG.Infra.Data.Repositories;
using EGG.Infra.Data.UoW;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EGG.Api
{
    public static class Setup
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EGG.Api", Version = "v1" });
            });
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("EGG.Domain");
            services.AddMediatR(assembly);
        }

        public static void ConfigureContextIoC(this IServiceCollection services, string connection)
        {
            services.AddDbContext<EGGContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });
        }

        public static void ConfigureRepositoriesIoC(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryEmpresa, RepositoryEmpresa>();
            services.AddTransient<IRepositoryProduto, RepositoryProduto>();
            services.AddTransient<IRepositoryCategoria, RepositoryCategoria>();
            services.AddTransient<IRepositoryPais, RepositoryPais>();
        }
    }
}