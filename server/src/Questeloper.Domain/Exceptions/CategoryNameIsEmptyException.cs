using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class CategoryNameIsEmptyException()
    : CustomException($"Category name cannot be empty.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}