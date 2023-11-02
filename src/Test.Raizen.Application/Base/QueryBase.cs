namespace Test.Raizen.Application.Base;

public abstract class QueryBase<TRequest> : SegregationBase<TRequest>
    where TRequest : SegregationBase<TRequest>
{
}