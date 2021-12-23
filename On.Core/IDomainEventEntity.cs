using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On.Core
{
    public interface IDomainEventEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

         void ClearDomainEvents();


    }
}
