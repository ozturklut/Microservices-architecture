using ContactService.Api.Infrastructure.Services.Abstarct;
using ContactService.Api.Infrastructure.Services;
using System.Reflection;

namespace ContactService.Api.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IContactInformationService, ContactInformationService>();

            return services;
        }
    }
}
