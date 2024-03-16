using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroNameIncorrectLengthException(string heroName)
    : CustomException($"Hero name: {heroName} must be between 3 and 250 characters.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}