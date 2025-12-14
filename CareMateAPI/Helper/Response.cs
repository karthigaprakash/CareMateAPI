namespace CareMateAPI.Helper;

public class Response<T>
{
    public HttpStatusCode Status { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    private Response(HttpStatusCode status, string? message, T? data = default)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    public static Response<T> Success(T data)
    {
        return new Response<T>(HttpStatusCode.OK, null, data);
    }

    public static Response<T> Success(string message)
    {
        return new Response<T>(HttpStatusCode.OK, message, default);
    }

    public static Response<T> Success(T data, string message)
    {
        return new Response<T>(HttpStatusCode.OK, message, data);
    }

    public static Response<T> Error(string message)
    {
        return new Response<T>(HttpStatusCode.BadRequest, message);
    }
}