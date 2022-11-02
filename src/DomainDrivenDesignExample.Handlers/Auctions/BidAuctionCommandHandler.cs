using DomainDrivenDesignExample.Domain.Aggregates;
using DomainDrivenDesignExample.Domain.Aggregates.Auctions;
using DomainDrivenDesignExample.Domain.Commands.Auctions;
using DomainDrivenDesignExample.Repositories;
using MediatR;

namespace DomainDrivenDesignExample.Handlers.Auctions;

public class BidAuctionCommandHandler : ICommandHandler<BidAuctionCommand, Unit>
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public BidAuctionCommandHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public Task<Unit> Handle(BidAuctionCommand command, CancellationToken cancellationToken)
    {
        var stream = _eventStoreRepository.Get(Identity.Create<Auction>(command.Id));
        var auction = new Auction(stream.Events);
        auction.Bid(command);

        _eventStoreRepository.Save(auction);
        return Task.FromResult(Unit.Value);
    }
}
