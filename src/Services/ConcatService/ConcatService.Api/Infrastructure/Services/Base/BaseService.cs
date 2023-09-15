using ConcatService.Api.Infrastructure.Context;

namespace ContactService.Api.Infrastructure.Services.Base
{
    public class BaseService
    {
        public readonly ConcatDbContext context;

        public BaseService(ConcatDbContext context)
        {
            this.context = context;
        }
    }
}
