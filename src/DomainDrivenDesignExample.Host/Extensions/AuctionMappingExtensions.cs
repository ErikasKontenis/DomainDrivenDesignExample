using DomainDrivenDesignExample.Contracts.Auctions;
using DomainDrivenDesignExample.Domain.Aggregates.Auctions;

namespace DomainDrivenDesignExample.Host.Extensions;

public static class AuctionMappingExtensions
{
    public static AuctionResponse Map(this Auction source)
    {
        return new AuctionResponse
        {
            CreatedUtc = source.State.CreatedUtc,
            Id = source.State.Id,
            Number = source.State.Number,
            Value = source.State.Value
        };
    }
}
