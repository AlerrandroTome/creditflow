using creditflow.services.creditcard.application.Services.Implementations;
using creditflow.services.creditcard.application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.creditcard.application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICartaoService, CartaoService>();

            return services;
        }
    }
}
