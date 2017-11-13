using Greenfinch.Business.Interface.Repositories;
using Greenfinch.Business.Interface.Services;
using Greenfinch.Business.Services;
using Greenfinch.Data.Context;
using Greenfinch.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Greenfinch.Ioc
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddScoped<DbContext, ApplicationContext>();

            services.AddScoped<INewsletterRegistrationService, NewsletterRegistrationService>();
            services.AddScoped<IHeardAboutUsOptionService, HeardAboutUsOptionService>();

            services.AddScoped<INewsletterRegistrationRepository, NewsletterRegistrationRepository>();
            services.AddScoped<IHeardAboutUsOptionRepository, HeardAboutUsOptionRepository>();

            return services;
        }
    }
}