using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Person.V1.Commands.Create;

public class CreatePersonCommandHandler : HandlerBase<CreatePersonCommand>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = (Domain.AggregatesModel.ValueAggreate.Person)request;

        await _personRepository.AddAsync(entity);
        await _unitOfWork.SaveAsync();

        Result.Data = (CreateCommandPersonResponse)entity;

        return Result;
    }
}
