using MediatR;
using On.Application.Commands.Customers;
using On.Core;
using On.Domain.RepositoriesAbstraction;
using System.Threading;
using System.Threading.Tasks;

namespace On.Application.CommandHandlers.Customers
{
    public class ActivateCustomerCommandHanlder : IRequestHandler<ActivateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateCustomerCommandHanlder(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.Id);
            customer.Activate();
           await _unitOfWork.CommitAsync();
            return true;
        }

       
    }
}
