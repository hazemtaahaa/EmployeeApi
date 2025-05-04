namespace EmployeeApi.Models
{
    public class GeneralResponse<T>
    {
        public string Message { get; set; }
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }

        public GeneralResponse(string message, T? data = default, bool success = true, string? error = null)
        {
            Message = message;
            Data = data;
            Success = success;
            Error = error;
        }
    }
}
