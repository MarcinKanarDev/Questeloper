using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class EmailAddressInvalidException(string message) : CustomException(message)
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}