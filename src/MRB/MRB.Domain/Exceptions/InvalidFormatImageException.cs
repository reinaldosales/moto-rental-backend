namespace MRB.Domain.Exceptions;

public class InvalidFormatImageException : Exception
{
    public InvalidFormatImageException()
    {
    }

    public InvalidFormatImageException(string message)
        : base(message)
    {
    }
    
    public InvalidFormatImageException(string message, Exception inner)
        : base(message, inner)
    {
    }
}