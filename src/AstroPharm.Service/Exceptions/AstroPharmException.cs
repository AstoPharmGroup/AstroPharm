namespace AstroPharm.Service.Exceptions;

public class AstroPharmException : Exception
{
    public int StatusCode { get; set; }

    public AstroPharmException(int code,string message) : base(message)
    {
        this.StatusCode = code;
    }
}
