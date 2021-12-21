using On.Core;
using System;

namespace On.Domain.Events.Customers
{
    public class CustomerActivated: IDomainEvent
    {
        public Guid Id { get; set; }
    }
}
