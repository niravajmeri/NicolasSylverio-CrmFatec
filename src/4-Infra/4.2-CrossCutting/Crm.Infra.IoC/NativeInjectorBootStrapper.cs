using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.Services;
using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Services;
using Crm.Infra.Data.Contexto;
using Crm.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void ResgistrarServicos(IServiceCollection services)
        {
            RegisterServices(services);
        }

        protected static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddAutoMapper();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // Infra - Data
            services.AddDbContext<CrmContext>();
            services.AddEntityFrameworkSqlServer();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Domain
            services.AddScoped<ICriptografiaService, CriptografiaService>();
        }
    }
}