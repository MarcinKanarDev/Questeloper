using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class ResourceNotFoundException(string propertyName, int id) 
    : CustomException($"{propertyName} with id: {id} not found.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}