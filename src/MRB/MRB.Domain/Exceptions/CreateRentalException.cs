namespace MRB.Domain.Exceptions;

public class CreateRentalException : Exception
{
    public CreateRentalException()
    {
    }

    public CreateRentalException(string message)
        : base(message)
    {
    }
    
    public CreateRentalException(string message, Exception inner)
        : base(message, inner)
    {
    }
}