namespace ContactService.Api.Core.Domain.Models.Base
{
    public class ApiBaseResponseModel<T> where T : new()
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiBaseResponseModel()
        {
            Success = false;
            Message = string.Empty;
            Data = new T();
        }
    }
}
