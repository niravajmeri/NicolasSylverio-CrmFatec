using AutoMapper;
using Crm.Application.Interface;
using Crm.Application.Services;
using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Services;
using Crm.Infra.CrossCutting.Identity;
using Crm.Infra.CrossCutting.Identity.Interfaces;
using Crm.Infra.CrossCutting.Identity.Models;
using Crm.Infra.Data.Contexto;
using Crm.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPermissionAppService, PermissionAppService>();

            // Infra - Data
            services.AddDbContext<CrmContext>();
            services.AddEntityFrameworkSqlServer();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Domain
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IPermissionService, PermissionService>();

            // Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
        }
    }
}