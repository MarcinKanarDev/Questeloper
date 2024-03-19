using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroClassIncorrectLengthException(string heroClass)
    : CustomException($"Hero class '{heroClass}' has an incorrect length.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}