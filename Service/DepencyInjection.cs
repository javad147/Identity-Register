﻿using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;  


namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IAccountService, AccountService>();
      
            return services;
        }
    }
}
