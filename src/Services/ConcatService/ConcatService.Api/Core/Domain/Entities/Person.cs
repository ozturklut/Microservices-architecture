using ConcatService.Api.Core.Domain.Entities.Base;

namespace ConcatService.Api.Core.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
