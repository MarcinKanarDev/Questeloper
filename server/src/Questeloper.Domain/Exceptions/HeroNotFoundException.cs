using System.Net;

namespace Questeloper.Domain.Exceptions;

public sealed class HeroNotFoundException(int id) 
    : CustomException($"Hero with id: {id} not found.")
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}