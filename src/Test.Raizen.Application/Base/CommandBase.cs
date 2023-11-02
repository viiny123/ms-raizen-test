namespace Test.Raizen.Application.Base;

public abstract class CommandBase<TRequest> : SegregationBase<TRequest>
    where TRequest : SegregationBase<TRequest>
{
}