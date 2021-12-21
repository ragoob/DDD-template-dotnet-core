
using MediatR;
using System;

namespace On.Application.Commands.Customers
{

    public class CustomerCommand
    {
         public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

    public class AddCustomerCommand : CustomerCommand, IRequest<bool> { }
    

    public class UpdateCustomerCommand : CustomerCommand, IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public record DeleteCustomerCommand(Guid Id) : IRequest;

    public record ActivateCustomerCommand(Guid Id) : IRequest<bool>;


}
