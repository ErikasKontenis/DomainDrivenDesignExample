namespace DomainDrivenDesignExample.Domain.Aggregates;

public interface IIdentity
{
    string AggregateType { get; }

    Guid Id { get; }
}
