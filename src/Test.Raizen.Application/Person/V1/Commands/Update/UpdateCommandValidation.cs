using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Person.V1.Commands.Update;

public class UpdateCommandValidation : AbstractValidator<UpdatePersonCommand>
{
    public UpdateCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);
    }
}