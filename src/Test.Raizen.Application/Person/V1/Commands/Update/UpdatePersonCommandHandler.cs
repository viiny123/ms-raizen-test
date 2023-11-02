using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Person.V1.Commands.Update;

public class UpdatePersonCommandHandler : HandlerBase<UpdatePersonCommand>
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonCommandHandler(IPersonRepository personRepository,
        IUnitOfWork unitOfWork)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
    }

    public override async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _personRepository
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity is null)
        {
            Result.AddError(ErrorCatalog.Person.GetByIdNotFound, ErrorCode.NotFound);

            return Result;
        }

        entity = request;

        await _personRepository.UpdateAsync(entity);
        await _unitOfWork.SaveAsync();

        return Result;
    }
}
