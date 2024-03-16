using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroNameIsEmptyException()
    : CustomException($"Hero name cannot be empty.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}