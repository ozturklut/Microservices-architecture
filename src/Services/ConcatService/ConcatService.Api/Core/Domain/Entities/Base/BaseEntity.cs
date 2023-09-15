namespace ConcatService.Api.Core.Domain.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
