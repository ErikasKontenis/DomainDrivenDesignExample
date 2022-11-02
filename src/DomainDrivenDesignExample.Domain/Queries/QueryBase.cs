using MediatR;

namespace DomainDrivenDesignExample.Domain.Queries;

public abstract class QueryBase<TResult> : IRequest<TResult>
{
}