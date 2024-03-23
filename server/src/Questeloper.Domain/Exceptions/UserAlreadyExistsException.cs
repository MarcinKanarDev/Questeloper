using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class UserAlreadyExistsException()
    : CustomException("User with provided email or nick name already exists.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}