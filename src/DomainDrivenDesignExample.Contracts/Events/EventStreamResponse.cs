namespace DomainDrivenDesignExample.Contracts.Events;

public record EventStreamResponse
{
    public List<EventResponse> Events { get; set; }

    public long Version { get; set; }
}
