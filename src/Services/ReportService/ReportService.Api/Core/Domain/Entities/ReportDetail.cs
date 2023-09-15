using ReportService.Api.Core.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ReportService.Api.Core.Domain.Entities
{
    public class ReportDetail : BaseEntity
    {
        public string? Location { get; set; }

        public int PersonCount { get; set; }

        public int PhoneNumberCount { get; set; }
        
        public Guid ReportId { get; set; }

        public Report? Report { get; set; }
    }
}
