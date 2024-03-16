using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class EnemyNameIsEmptyException()
    : CustomException($"Enemy name cannot be empty.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}