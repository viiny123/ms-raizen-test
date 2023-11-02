using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Raizen.Application.Base;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Person.V1.Commands.Delete;

public class DeletePersonCommandHandler : HandlerBase<DeletePersonCommand>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonCommandHandler(IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _personRepository
            .GetDbSet()
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);

        return Result;
    }
}
