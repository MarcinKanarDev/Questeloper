using System.Net;

namespace Questeloper.Domain.Exceptions;

public class ValueIsEmptyException(string property)
    : CustomException($"Value of '{property}' cannot be empty.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}