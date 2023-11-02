using MediatR;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Application.Base
{
    public abstract class SegregationBase<TRequest> : Paginate<Result>, IRequest<Result>
        where TRequest : SegregationBase<TRequest>
    {
    }
}
