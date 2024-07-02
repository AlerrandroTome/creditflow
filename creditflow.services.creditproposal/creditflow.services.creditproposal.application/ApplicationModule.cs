using creditflow.services.creditproposal.application.Services.Implementations;
using creditflow.services.creditproposal.application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.creditproposal.application
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
            services.AddScoped<IPropostaService, PropostaService>();

            return services;
        }
    }
}
