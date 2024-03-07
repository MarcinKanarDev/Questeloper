using System.Net;

namespace Questeloper.Domain.Exceptions;

public abstract class CustomException(string message) : Exception(message)
{
    public abstract HttpStatusCode StatusCode { get; }
}