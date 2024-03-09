using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroNameAlreadyExistsException(string name)
    : CustomException($"Hero with name: {name} already exists.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}