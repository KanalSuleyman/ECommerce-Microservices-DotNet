using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest<Unit>
{
}