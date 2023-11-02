using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Value.V1.Queries.Get
{
    public class GetValueQueryHandler : HandlerBase<GetValueQuery>
    {

        private readonly IValueRepository valueRepository;

        public GetValueQueryHandler(IValueRepository valueRepository)
        {
            this.valueRepository = valueRepository;
        }

        public override async Task<Result> Handle(GetValueQuery request, CancellationToken cancellationToken)
        {
            var requestPaginated = new Paginate<Domain.AggregatesModel.ValueAggreate.Value>()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber
            };

            var values = await valueRepository.GetValuePaginated(EvaluateConditions(request), requestPaginated);

            Result.Data = new Paginate<GetValueQueryResponse>(values.PageSize,
                values.PageNumber,
                values.TotalCount,
                values.TotalPage)
            {
                PageData = values
                        .PageData
                        .Select(x => new GetValueQueryResponse(x.Id, x.Code, x.Description, x.Status, x.Timestamp))
            };

            return Result;
        }

        private static IEnumerable<Expression<Func<Domain.AggregatesModel.ValueAggreate.Value, bool>>> EvaluateConditions(GetValueQuery request)
        {
            var predicates = new List<Expression<Func<Domain.AggregatesModel.ValueAggreate.Value, bool>>>();

            if (!string.IsNullOrEmpty(request.Code))
            {
                predicates.Add(x => request.Code == x.Code);
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                predicates.Add(x => request.Description == x.Description);
            }

            return predicates.ToArray();
        }
    }
}
