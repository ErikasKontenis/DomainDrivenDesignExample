using DomainDrivenDesignExample.Domain.Events;

namespace DomainDrivenDesignExample.Domain.Aggregates
{
    public abstract class AggregateRootBase<TState> : IAggregateRoot
        where TState : IAggregateState
    {
        public readonly TState State;

        protected AggregateRootBase(TState state)
        {
            State = state;
            Version = state.EventCount;
        }

        private readonly List<EventBase> _uncommittedEvents = new List<EventBase>();

        public Identity Identity => new Identity(State.Id, GetType().Name);

        public long Version { get; protected set; }

        public void Apply(EventBase @event)
        {
            State.Mutate(@event);

            _uncommittedEvents.Add(@event);

            Version += 1;
        }

        public IEnumerable<EventBase> GetUncommittedEvents() => _uncommittedEvents;
    }
}
