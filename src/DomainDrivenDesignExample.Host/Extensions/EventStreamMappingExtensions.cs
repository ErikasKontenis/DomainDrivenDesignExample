using DomainDrivenDesignExample.Contracts.Events;
using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Host.Extensions;

public static class EventStreamMappingExtensions
{
    public static EventStreamResponse Map(this EventStream source)
    {
        return new EventStreamResponse
        {
            Version = source.Version,
            Events = source.Events.Select(o => new EventResponse
            {
                Event = o
            }).ToList()
        };
    }
}