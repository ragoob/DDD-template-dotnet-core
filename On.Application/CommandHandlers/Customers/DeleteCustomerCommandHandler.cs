using MediatR;
using On.Application.Commands.Customers;
using On.Core;
using On.Domain.RepositoriesAbstraction;
using System.Threading;
using System.Threading.Tasks;

namespace On.Application.CommandHandlers.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            _customerRepository.Delete(request.Id);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
