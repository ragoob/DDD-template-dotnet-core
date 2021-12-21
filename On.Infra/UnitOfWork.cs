using On.Core;
using System.Threading.Tasks;

namespace On.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnContext _onContext;

        public UnitOfWork(OnContext onContext)
        {
            _onContext = onContext;
        }
        public async Task CommitAsync()
        {
            await _onContext.SaveChangesAsync();
        }
    }
}
