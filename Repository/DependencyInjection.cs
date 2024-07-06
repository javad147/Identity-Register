using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Repository.Repository.Interfaces;
using Repository.Repository;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            return services;

        }
    }
}
