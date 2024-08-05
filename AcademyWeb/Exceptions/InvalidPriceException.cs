namespace AcademyWeb.Exceptions;

public class InvalidPriceException : Exception
{
    public InvalidPriceException() : base() { }
    public InvalidPriceException(string message) : base(message) { }
    public InvalidPriceException(string message, Exception innerException) : base(message, innerException) { }
}
