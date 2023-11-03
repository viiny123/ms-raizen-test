using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Queries.GetById;

public class GetPersonByIdQueryHandler : HandlerBase<GetPersonByIdQuery>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public override async Task<Result> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _personRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity is null)
        {
            Result.AddError(ErrorCatalog.TestError.GetByIdNotFound, ErrorCode.NotFound);

            return Result;
        }

        Result.Data = (GetPersonByIdQueryResponse)entity;

        return Result;
    }
}
