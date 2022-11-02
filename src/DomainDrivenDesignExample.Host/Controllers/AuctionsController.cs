using DomainDrivenDesignExample.Contracts.Auctions;
using DomainDrivenDesignExample.Domain.Commands.Auctions;
using DomainDrivenDesignExample.Domain.Queries.Auctions;
using DomainDrivenDesignExample.Host.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesignExample.Controllers;

[ApiController]
[Route("v1/auctions")]
public class AuctionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuctionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuctionRequest create)
    {
        var auctionId = await _mediator.Send(new CreateAuctionCommand
        {
            Number = create.Number
        });

        return CreatedAtAction(nameof(GetAuction), new { id = auctionId }, new AuctionCreatedResponse
        {
            Id = auctionId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Bid(Guid id, [FromBody] BidAuctionRequest bid)
    {
        await _mediator.Send(new BidAuctionCommand
        {
            Id = id,
            Value = bid.Value
        });

        return NoContent();
    }

    [HttpGet("{id}/events")]
    public async Task<IActionResult> ListEvents(Guid id)
    {
        var stream = await _mediator.Send(new GetAuctionEventStreamQuery
        {
            Id = id
        });

        return Ok(stream.Map());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuction(Guid id)
    {
        var auction = await _mediator.Send(new GetAuctionQuery
        {
            Id = id
        });

        return Ok(auction.Map());
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var auctions = await _mediator.Send(new ListAuctionsQuery());

        return Ok(auctions.Select(o => o.Map()));
    }
}
