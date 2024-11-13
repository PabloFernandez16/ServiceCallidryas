namespace WebApi_Callidryas.Models.Response;

public class Response{
    public int Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public Response()
    {
        Success = 0;
    }
}