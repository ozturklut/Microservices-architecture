namespace ReportService.Api.Core.Domain.Models.Response
{
    public class ContactInformationReport
    {
        public Guid ReportId { get; set; }

        public ICollection<ContactInformationReportItem> Details { get; set; }
    }

    public class ContactInformationReportItem
    {
        public string? Location { get; set; }

        public int PersonCount { get; set; }

        public int PhoneNumberCount { get; set; }
    }
}
