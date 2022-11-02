using MediatR;

namespace DomainDrivenDesignExample.Domain.Commands.Auctions;

public class BidAuctionCommand : CommandBase<Unit>
{
    public Guid Id { get; set; }

    public decimal Value { get; set; }
}
