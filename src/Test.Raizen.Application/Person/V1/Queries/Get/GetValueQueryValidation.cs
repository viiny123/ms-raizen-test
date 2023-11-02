using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Person.V1.Queries.Get;

public class GetValueQueryValidation : AbstractValidator<GetPersonQuery>
{
    public GetValueQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.Person.BaseInvalidRequest);
    }
}