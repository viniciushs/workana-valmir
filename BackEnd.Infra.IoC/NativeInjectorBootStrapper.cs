namespace BackEnd.Infra.IoC
{
    using BackEnd.Application.AutoMapper;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.Services;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;
    using BackEnd.Infra.Data.Repositories;
    using BackEnd.Infra.Data.UoW;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(
            IServiceCollection services,
            IConfiguration configuration)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Application

            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());

            services.AddScoped<ICargoAppService, CargoAppService>();
            services.AddScoped<IFormaPagamentoAppService, FormaPagamentoAppService>();
            services.AddScoped<IFranqueadoAppService, FranqueadoAppService>();
            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<ISituacaoAppService, SituacaoAppService>();

            #endregion Application

            #region Infra - Data

            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IFranqueadoRepository, FranqueadoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<ISituacaoRepository, SituacaoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<BackEndContext>();

            #endregion Infra - Data


        }
    }
}
