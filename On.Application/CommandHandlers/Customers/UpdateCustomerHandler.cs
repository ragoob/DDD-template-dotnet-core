using MediatR;
using On.Application.Commands.Customers;
using System.Threading;
using System.Threading.Tasks;
using On.Domain.Entites;
using On.Domain.RepositoriesAbstraction;
using On.Core;

namespace On.Application.CommandHandlers.Customers
{
    public class UpdateCustomerHandler: IRequestHandler<UpdateCustomerCommand,bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
           
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.Id);
            customer.updateCustomer(request.Name);
            customer.ModifyAddress(new CustomerAddress(request.Street, request.City, request.State, request.Country, request.ZipCode));
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
