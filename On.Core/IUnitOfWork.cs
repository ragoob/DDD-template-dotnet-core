using System.Threading.Tasks;

namespace On.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
