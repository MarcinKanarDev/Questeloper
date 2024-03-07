using MediatR;

namespace Questeloper.Api.Abstractions;

public abstract class ApiEndpointBase(ISender sender)
{
    protected abstract string EndpointRoute { get; }
}