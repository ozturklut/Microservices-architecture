using ConcatService.Api.Core.Domain.Enum;

namespace ContactService.Api.Core.Domain.Models.Base
{
    public class BaseContactInformationModel
    {
        public InformationType Type { get; set; }
        public string Content { get; set; }
    }
}
