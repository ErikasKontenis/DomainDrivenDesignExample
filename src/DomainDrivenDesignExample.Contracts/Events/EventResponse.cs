namespace DomainDrivenDesignExample.Contracts.Events;

public record EventResponse
{
    public string Type => Event.GetType().Name;

    public object Event { get; init; }
}
