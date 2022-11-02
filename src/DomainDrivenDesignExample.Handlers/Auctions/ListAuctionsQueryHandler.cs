using DomainDrivenDesignExample.Domain.Aggregates.Auctions;
using DomainDrivenDesignExample.Domain.Queries.Auctions;
using DomainDrivenDesignExample.Repositories;

namespace DomainDrivenDesignExample.Handlers.Auctions;

public class ListAuctionsQueryHandler : IQueryHandler<ListAuctionsQuery, List<Auction>>
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public ListAuctionsQueryHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public Task<List<Auction>> Handle(ListAuctionsQuery query, CancellationToken cancellationToken)
    {
        var streams = _eventStoreRepository.List(typeof(Auction).Name);
        var auctions = streams.Select(o => new Auction(o.Events)).ToList();
        return Task.FromResult(auctions);
    }
}
