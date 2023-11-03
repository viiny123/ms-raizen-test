using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Person.V1.Commands.Create;

public class CreateCommandValidation : AbstractValidator<CreatePersonCommand>
{
    public CreateCommandValidation()
    {
        RuleFor(r => r)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.BaseInvalidRequest);

        RuleFor(r => r.Name)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.CreateNameIsNullOrEmpty);

        RuleFor(r => r.Email)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.CreateEmailIsNullOrEmpty);

        RuleFor(r => r.BirthDay)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.CreateBirthDayIsNull);

        RuleFor(r => r.PostalCode)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.TestError.CreateEmailIsNullOrEmpty);

    }
}
