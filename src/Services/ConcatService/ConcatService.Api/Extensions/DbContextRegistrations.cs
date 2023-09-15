using ConcatService.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConcatService.Api.Extensions
{
    public static class DbContextRegistrations
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConcatDbContext>(option => option.UseNpgsql(configuration["ConnectionStrings:ConString"]));
            return services;
        }
    }
}
