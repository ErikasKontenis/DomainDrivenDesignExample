using DomainDrivenDesignExample.Domain.Queries;
using MediatR;

namespace DomainDrivenDesignExample.Handlers;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : QueryBase<TResponse>
{ }
