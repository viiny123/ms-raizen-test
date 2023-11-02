using System;
using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Value.V1.Commands.Create
{
    public class CreateValueCommandHandler : HandlerBase<CreateValueCommand>
    {

        private readonly IValueRepository valueRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateValueCommandHandler(IValueRepository valueRepository,
            IUnitOfWork unitOfWork)
        {
            this.valueRepository = valueRepository;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<Result> Handle(CreateValueCommand request, CancellationToken cancellationToken)
        {

            //Simulate bussiness error
            if (request.Code == "-1")
            {
                Result.AddError(ErrorCatalog.Value.CodeCanBeNegativeNumber, ErrorCode.UnprocessableEntity);
                return Result;
            }

            var value = CreateValue(request);
            await valueRepository.Add(value);
            await unitOfWork.SaveAsync();

            Result.Data = new CreateCommandValueResponse(value.Id);

            return Result;
        }

        private static Domain.AggregatesModel.ValueAggreate.Value CreateValue(CreateValueCommand request)
        {
            return new Domain.AggregatesModel.ValueAggreate.Value()
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Description = request.Description,
                Status = Status.Active,
                Timestamp = DateTime.Now
            };
        }
    }
}
