namespace DomainDrivenDesignExample.Domain.Aggregates;

public class Identity : IIdentity
{
    public Identity(Guid id, string aggregateType)
    {
        Id = id;
        AggregateType = aggregateType;
    }

    public string AggregateType { get; private set; }

    public Guid Id { get; private set; }

    public static Identity Create<TAggregateRoot>(Guid id)
        where TAggregateRoot : IAggregateRoot
    {
        return new Identity(id, typeof(TAggregateRoot).Name);
    }

    public override string ToString()
    {
        return $"{AggregateType}-{Id}";
    }
}
