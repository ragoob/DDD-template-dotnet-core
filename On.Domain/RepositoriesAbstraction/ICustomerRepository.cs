using On.Core.Repositories;
using On.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On.Domain.RepositoriesAbstraction
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
    }
}
