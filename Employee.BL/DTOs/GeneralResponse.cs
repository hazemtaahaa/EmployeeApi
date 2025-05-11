

namespace Employee.BL;
public class GeneralResult
{
    public GeneralResult(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetMessageFromStatusCode(statusCode);
    }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; } = 200;

    private string GetMessageFromStatusCode(int statusCode)
    {
        return statusCode switch
        {
            200 => "Success",
            201 => "Created",
            204 => "No Content",
            400 => "Bad Request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not Found",
            500 => "Internal Server Error",
            _ => "Unknown Status Code"
        };
    }
}
public class GeneralResult<T> : GeneralResult
{
    public T? Data { get; set; }
    public GeneralResult(int statusCode, T data, string message) : base(statusCode, message)
    {
        Data = data;
    }

}