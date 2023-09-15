namespace ContactService.Api.Core.Domain.Models.Response.ContactInformation
{
    public class ContactInformationReport
    {
        public Guid ReportId { get; set; }

        public ICollection<ContactInformationReportItem> Details { get; set; }
        public ContactInformationReport()
        {
            Details = new List<ContactInformationReportItem>();
        }
    }

    public class ContactInformationReportItem
    {
        public string? Location { get; set; }

        public int PersonCount { get; set; }

        public int PhoneNumberCount { get; set; }
    }
}