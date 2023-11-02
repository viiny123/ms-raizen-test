using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Value.V1.Commands.Update
{
    public class UpdateValueCommandHandler : HandlerBase<UpdateValueCommand>
    {
        private readonly IValueRepository valueRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateValueCommandHandler(IValueRepository valueRepository,
            IUnitOfWork unitOfWork)
        {
            this.valueRepository = valueRepository;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(UpdateValueCommand request, CancellationToken cancellationToken)
        {

            var value = await valueRepository.GetById(request.Id);

            if (value is null)
            {
                Result.AddError(ErrorCatalog.Value.GetByIdNotFound, ErrorCode.NotFound);

                return Result;
            }

            SetValuesToUpdate(value, request);
            valueRepository.Update(value);
            await unitOfWork.SaveAsync();

            return Result;
        }

        private static void SetValuesToUpdate(Domain.AggregatesModel.ValueAggreate.Value value, UpdateValueCommand request)
        {
            value.Description = request.Description;
        }
    }
}
