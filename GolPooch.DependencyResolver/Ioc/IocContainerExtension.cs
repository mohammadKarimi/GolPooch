using Elk.Core;
using Elk.Cache;
using GolPooch.SmsGateway;
using GolPooch.DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GolPooch.DependencyResolver.Ioc
{
    public static class IocContainerExtension
    {
        public static IServiceCollection AddTransient(this IServiceCollection serviceCollection, IConfiguration _configuration)
        {
            return serviceCollection;
        }

        public static IServiceCollection AddScoped(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddContext<AppDbContext>(_configuration.GetConnectionString("AppDbContext"));
            services.AddScoped<AppDbContext>();
            
            services.AddScoped<ISmsGatway, SmsGatway>();

            #region Repos
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            #endregion

            return services;
        }

        public static IServiceCollection AddSingleton(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddSingleton<IMemoryCacheProvider, MemoryCacheProvider>();

            return services;
        }

        public static IServiceCollection AddContext<TDbContext>(this IServiceCollection serviceCollection, string conectionString) where TDbContext : DbContext
        {
            serviceCollection.AddDbContext<TDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(conectionString,
                            sqlServerOption =>
                            {
                                sqlServerOption.MaxBatchSize(1000);
                                sqlServerOption.CommandTimeout(null);
                                sqlServerOption.UseRelationalNulls(false);
                            });
            });

            return serviceCollection;
        }
    }
}