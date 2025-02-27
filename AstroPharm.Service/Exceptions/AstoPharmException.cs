namespace AstroPharm.Service.Exceptions;

public class AstoPharmException : Exception
{
    public int StatusCode { get; set; }

    public AstoPharmException(int code,string message) : base(message)
    {
        this.StatusCode = code;
    }
}
