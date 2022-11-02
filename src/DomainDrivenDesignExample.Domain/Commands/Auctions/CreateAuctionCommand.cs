namespace DomainDrivenDesignExample.Domain.Commands.Auctions;

public class CreateAuctionCommand : CommandBase<Guid>
{
    public string Number { get; set; }
}