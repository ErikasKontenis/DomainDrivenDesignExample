namespace DomainDrivenDesignExample.Domain.Events;

public class EventStream
{
    public EventStream()
    {
        Events = new List<EventBase>();
    }

    public List<EventBase> Events { get; set; }

    public long Version { get; set; }
}