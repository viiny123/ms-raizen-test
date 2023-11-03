using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;
using Test.Raizen.Application.Person.V1.Commands.Update;

namespace Test.Raizen.Application.Person.V1.Commands.Delete;

public class UpdateCommandValidation : AbstractValidator<UpdatePersonCommand>
{
    public UpdateCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Id)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.DeleteIdIsNullOrEmpty);
    }
}
