using MediatR;
using On.Domain.Events.Customers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace On.Application.EventHandlers.Customers
{
    public class CustomerActivatedEventHandler : INotificationHandler<CustomerActivated>
    {
        public Task Handle(CustomerActivated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"User with Id {notification.Id} has beeen activated");
            return Task.CompletedTask;
        }
    }
}
