namespace esluzba.Exceptions;

public class Conflict : Exception
{
    public override string Message { get; }
    int StatusCode { get; set; }
    
    public Conflict(string message, int code) : base(message)
    {
        Message = message;
        StatusCode = code;
    }
}