using DomainDrivenDesignExample.Domain.Commands;
using MediatR;

namespace DomainDrivenDesignExample.Handlers;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : CommandBase<TResponse>
{ }