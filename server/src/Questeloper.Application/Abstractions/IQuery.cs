using MediatR;

namespace Questeloper.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}