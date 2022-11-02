using DomainDrivenDesignExample.Domain.Aggregates.Auctions;

namespace DomainDrivenDesignExample.Domain.Queries.Auctions;

public class GetAuctionQuery : QueryBase<Auction>
{
    public Guid Id { get; set; }
}