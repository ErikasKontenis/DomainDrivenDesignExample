using DomainDrivenDesignExample.Domain.Aggregates;
using DomainDrivenDesignExample.Domain.Aggregates.Auctions;
using DomainDrivenDesignExample.Domain.Queries.Auctions;
using DomainDrivenDesignExample.Repositories;

namespace DomainDrivenDesignExample.Handlers.Auctions;

public class GetAuctionQueryHandler : IQueryHandler<GetAuctionQuery, Auction>
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public GetAuctionQueryHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public Task<Auction> Handle(GetAuctionQuery query, CancellationToken cancellationToken)
    {
        var stream = _eventStoreRepository.Get(Identity.Create<Auction>(query.Id));
        var auction = new Auction(stream.Events);
        return Task.FromResult(auction);
    }
}
