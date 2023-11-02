using System.Linq;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Domain.AggregatesModel.ValueAggreate;

public interface IPersonRepository : IRepositoryBase<Person>
{
    IQueryable<Person> GetPersonsByFilter(GetPersonQueryDto personQueryDto);
}
