using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Adresses.Queries.GetByPostalCode;

public class GetByPostalCodeQueryValidation : AbstractValidator<GetByPostalCodeQuery>
{
    public GetByPostalCodeQueryValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.PostalCode)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.GetByPostalCodeIsNullOrEmpty);
    }
}
