using ConcatService.Api.Core.Domain.Entities.Base;
using ConcatService.Api.Core.Domain.Enum;

namespace ConcatService.Api.Core.Domain.Entities
{
    public class ContactInformation : BaseEntity
    {
        public InformationType Type { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}