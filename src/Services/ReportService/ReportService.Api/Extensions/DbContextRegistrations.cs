using Microsoft.EntityFrameworkCore;
using ReportService.Api.Infrastructure.Context;

namespace ReportService.Api.Extensions
{
    public static class DbContextRegistrations
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReportDbContext>(option => option.UseNpgsql(configuration["ConnectionStrings:ConString"]));
            return services;
        }
    }
}
