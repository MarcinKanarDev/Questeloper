using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class EnemyNameIncorrectLengthException(string enemyName)
    : CustomException($"Enemy name: {enemyName} must be between 3 and 250 characters.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}