using System.Threading.Tasks;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestDbContext context;

        public UnitOfWork(TestDbContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
