namespace ReportService.Api.Core.Domain.Entities.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
