namespace ReportService.Api.Core.Domain.Models.Base
{
    public class ApiBaseResponseModel<T> where T : new()
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiBaseResponseModel()
        {
            Success = false;
            StatusCode = 0;
            Message = string.Empty;
            Data = new T();
        }
    }
}
