using System;
using System.Collections.Generic;

namespace On.Core.Entites
{
    public abstract class BaseEntity<TIdentity>
    {
      public TIdentity Id { get; set; }

      private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
      public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
       protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        protected void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}
