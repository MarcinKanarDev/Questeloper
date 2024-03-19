using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class ValueIncorrectLengthException(string property, int minLength, int maxLength)
    : CustomException($"Value of '{property}' must be between {minLength} and {maxLength} characters.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}