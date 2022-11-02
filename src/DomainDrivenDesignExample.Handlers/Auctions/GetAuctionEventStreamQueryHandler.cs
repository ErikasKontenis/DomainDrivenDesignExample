using DomainDrivenDesignExample.Domain.Aggregates;
using DomainDrivenDesignExample.Domain.Aggregates.Auctions;
using DomainDrivenDesignExample.Domain.Events;
using DomainDrivenDesignExample.Domain.Queries.Auctions;
using DomainDrivenDesignExample.Repositories;

namespace DomainDrivenDesignExample.Handlers.Auctions;

public class GetAuctionEventStreamQueryHandler : IQueryHandler<GetAuctionEventStreamQuery, EventStream>
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public GetAuctionEventStreamQueryHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public Task<EventStream> Handle(GetAuctionEventStreamQuery query, CancellationToken cancellationToken)
    {
        var stream = _eventStoreRepository.Get(Identity.Create<Auction>(query.Id));
        return Task.FromResult(stream);
    }
}
