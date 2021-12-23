using On.Core.Repositories;
using On.Domain.Entites;
using System;
namespace On.Domain.RepositoriesAbstraction
{
    public interface ICustomerRepository: IBaseRepository<Customer,Guid>
    {
    }
}
