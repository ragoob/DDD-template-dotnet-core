using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using On.Core;
using On.Core.Entites;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace On.Infra
{
    public class DomainEventDispatcher : SaveChangesInterceptor
    {
        public readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEventAsync(eventData.Context.ChangeTracker);
            return result;
        }

        private async Task DispatchDomainEventAsync(ChangeTracker changeTracker)
        {
            var eventPublishTasks = changeTracker.Entries<IDomainEventEntity>()
                .Select(x => x.Entity)
                .Where(x => x.DomainEvents.Any())
                .SelectMany(e => e.DomainEvents)
                .Select(e => _mediator.Publish(e));

            changeTracker.Entries<IDomainEventEntity>()
            .Select(x => x.Entity).ToList()
            .ForEach(e => e.ClearDomainEvents());

            // publish all events
            await Task.WhenAll(eventPublishTasks);

           
          
           
                
        }
    }
}
