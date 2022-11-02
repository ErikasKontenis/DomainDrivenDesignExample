using DomainDrivenDesignExample.Domain.Aggregates;
using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Repositories;

public interface IEventStoreRepository
{
    EventStream Get(IIdentity identity);

    List<EventStream> List(string aggregateType);

    void Save(IAggregateRoot aggregateRoot);
}
