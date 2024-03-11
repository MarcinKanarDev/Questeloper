using MediatR;

namespace Questeloper.Application.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}