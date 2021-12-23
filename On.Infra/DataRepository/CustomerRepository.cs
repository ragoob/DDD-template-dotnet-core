using On.Domain.Entites;
using On.Domain.RepositoriesAbstraction;
using System;

namespace On.Infra.DataRepository
{
    public class CustomerRepository : BaseRepository<Customer,Guid>, ICustomerRepository
    {
        public CustomerRepository(OnContext onContext) : base(onContext)
        {
        }
    }
}
