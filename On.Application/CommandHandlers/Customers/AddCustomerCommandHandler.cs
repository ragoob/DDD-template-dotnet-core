using MediatR;
using On.Application.Commands.Customers;
using On.Core;
using On.Domain.Entites;
using On.Domain.RepositoriesAbstraction;
using System.Threading;
using System.Threading.Tasks;

namespace On.Application.CommandHandlers.Customers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand,bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name);
            customer.ModifyAddress(new CustomerAddress(request.Street, request.City, request.State, 
                request.Country, request.ZipCode));
            request.Photoes.ForEach(p => customer.RemoveCustomerPhoto(customer.Id));
            request.Photoes.ForEach(p => customer.AddCustomerPhoto(p.pathUrl, p.alt));
            
            _customerRepository.Add(customer);
           await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
