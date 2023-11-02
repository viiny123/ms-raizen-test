using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Value.V1.Queries.GetById
{
    public class GetValueByIdQueryHandler : HandlerBase<GetValueByIdQuery>
    {
        private readonly IValueRepository valueRepository;

        public GetValueByIdQueryHandler(IValueRepository valueRepository)
        {
            this.valueRepository = valueRepository;
        }

        public override async Task<Result> Handle(GetValueByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await valueRepository.GetById(request.Id);

            if (value is null)
            {
                Result.AddError(ErrorCatalog.Value.GetByIdNotFound, ErrorCode.NotFound);

                return Result;
            }

            Result.Data = value;

            return Result;
        }
    }
}
