# DomainDrivenDesignExample
The solution contains personal implementation of basic DDD + CQRS + ES realization.

Solution is split into 5 layers:
* DomainDrivenDesignExample.Host - here we have our controllers and application host configurations.
* DomainDrivenDesignExample.Contracts - here we have our presentation layer contracts. 
* DomainDrivenDesignExample.Handlers - here we have our command & query handlers which are separating and bridging the communication between domain, repositories and presentation layers.
* DomainDrivenDesignExample.Repositories - here is the place for DAL implementation.
* DomainDrivenDesignExample.Domain - here we have our domain logic and domain contracts. The place where our events, commands, queries and aggregates are placed.

This is a one click run & go solution. For example purposes we use in-memory self implementation of event store database.
