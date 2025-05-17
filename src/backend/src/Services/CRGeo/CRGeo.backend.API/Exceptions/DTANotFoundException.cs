namespace CRGeo.backend.API.Exceptions;

public class DTANotFoundException : NotFoundException
{
    public DTANotFoundException(object key) : base("DTA", key)
    {
    }
}