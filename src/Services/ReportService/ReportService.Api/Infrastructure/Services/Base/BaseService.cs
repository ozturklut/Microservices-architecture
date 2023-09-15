using ReportService.Api.Infrastructure.Context;

namespace ReportService.Api.Infrastructure.Services.Base
{
    public class BaseService
    {
        public readonly ReportDbContext context;

        public BaseService(ReportDbContext context)
        {
            this.context = context;
        }
    }
}