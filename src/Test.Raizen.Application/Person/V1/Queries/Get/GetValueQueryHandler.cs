using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Data.Extensions;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Queries.Get;

public class GetValueQueryHandler : HandlerBase<GetPersonQuery>
{
    private readonly IPersonRepository _personRepository;

    public GetValueQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public override async Task<Result> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var persons = await _personRepository.GetPersonsByFilter(new GetPersonQueryDto
                                             {
                                                 Name = request.Name, Email = request.Email
                                             })
                                             .Select<Domain.AggregatesModel.ValueAggreate.Person, GetPersonQueryResponse>(x => x)
                                             .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);

        Result.Data = persons;

        return Result;
    }
}
