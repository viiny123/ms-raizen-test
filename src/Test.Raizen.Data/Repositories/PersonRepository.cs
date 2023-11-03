using System;
using System.Linq;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Data.Base;

namespace Test.Raizen.Data.Repositories;

public class PersonRepository : RepositoryBase<TestDbContext, Person>, IPersonRepository
{
    public PersonRepository(TestDbContext context) : base(context)
    {
    }

    public IQueryable<Person> GetPersonsByFilter(GetPersonQueryDto personQueryDto)
    {
        var query = GetDbSetQuery()
            .Where(x => x.Status == Status.Active);

        if (string.IsNullOrWhiteSpace(personQueryDto.Name) is false)
        {
            query = query.Where(x => x.Name.ToLower() == personQueryDto.Name.ToLower());
        }

        if (string.IsNullOrWhiteSpace(personQueryDto.Email) is false)
        {
            query = query.Where(x => x.Email.ToLower() == personQueryDto.Email.ToLower());
        }

        query = query.OrderBy(x => x.Name);

        return query;
    }
}
