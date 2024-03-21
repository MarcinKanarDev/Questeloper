using System.Net;

namespace Questeloper.Domain.Exceptions;

public class UserNotFoundException(int id)
    : CustomException($"User with id {id} not found.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}