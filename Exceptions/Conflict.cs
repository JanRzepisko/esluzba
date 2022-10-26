namespace esluzba.Exceptions;

public class Conflict : Exception
{
    public override string Message { get; }
    public const int StatusCode = 409;
    
    public Conflict(string message) : base(message)
    {
        Message = message;
    }
}