using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Domain.Queries.Auctions;

public class GetAuctionEventStreamQuery : QueryBase<EventStream>
{
    public Guid Id { get; set; }
}
