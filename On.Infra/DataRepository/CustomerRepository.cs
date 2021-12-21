using On.Domain.Entites;
using On.Domain.RepositoriesAbstraction;

namespace On.Infra.DataRepository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnContext onContext) : base(onContext)
        {
        }
    }
}
