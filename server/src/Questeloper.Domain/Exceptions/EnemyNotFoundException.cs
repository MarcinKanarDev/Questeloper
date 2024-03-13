using System.Net;

namespace Questeloper.Domain.Exceptions;

public class EnemyNotFoundException(int id) 
    : CustomException($"Enemy with id: {id} not found.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}