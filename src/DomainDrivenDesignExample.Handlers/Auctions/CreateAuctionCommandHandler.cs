using DomainDrivenDesignExample.Domain.Aggregates.Auctions;
using DomainDrivenDesignExample.Domain.Commands.Auctions;
using DomainDrivenDesignExample.Domain.Events;
using DomainDrivenDesignExample.Repositories;

namespace DomainDrivenDesignExample.Handlers.Auctions;

public class CreateAuctionCommandHandler : ICommandHandler<CreateAuctionCommand, Guid>
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public CreateAuctionCommandHandler(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }

    public Task<Guid> Handle(CreateAuctionCommand command, CancellationToken cancellationToken)
    {
        var auction = new Auction(new List<EventBase>());
        auction.Create(command);

        _eventStoreRepository.Save(auction);
        return Task.FromResult(auction.Identity.Id);
    }
}