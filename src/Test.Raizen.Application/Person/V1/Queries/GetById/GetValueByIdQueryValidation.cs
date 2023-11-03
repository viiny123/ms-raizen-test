using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Person.V1.Queries.GetById;

public class GetValueByIdQueryValidation : AbstractValidator<GetPersonByIdQuery>
{
    public GetValueByIdQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Id)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.GetByIdNotFound);
    }
}
