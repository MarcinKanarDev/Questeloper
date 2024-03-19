using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroClassIsEmptyException()
    : CustomException($"Enemy name cannot be empty.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}