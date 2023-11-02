using System.Threading.Tasks;

namespace Test.Raizen.Domain.Base
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
