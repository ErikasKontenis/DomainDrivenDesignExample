namespace DomainDrivenDesignExample.Domain.Events;

public abstract class EventBase
{
    public DateTime EventDateUtc { get; set; }

    public Guid Id { get; set; }
}
