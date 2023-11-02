using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Value.V1.Queries.Get
{
    public class GetValueQueryValidation : AbstractValidator<GetValueQuery>
    {
        public GetValueQueryValidation()
        {
            RuleFor(r => r)
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.BaseInvalidRequest);
        }
    }
}
