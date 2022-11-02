using MediatR;

namespace DomainDrivenDesignExample.Domain.Commands;

public abstract class CommandBase<TResult> : IRequest<TResult>
{
}
