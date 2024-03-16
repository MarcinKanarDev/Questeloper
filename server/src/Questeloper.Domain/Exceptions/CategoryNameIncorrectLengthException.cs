using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class CategoryNameIncorrectLengthException(string categoryName)
    : CustomException($"Category name: {categoryName} must be between 3 and 250 characters.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}