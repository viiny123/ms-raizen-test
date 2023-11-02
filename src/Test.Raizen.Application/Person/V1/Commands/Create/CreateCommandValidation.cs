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
            .WithErrorCatalog(ErrorCatalog.Person.BaseInvalidRequest);

        RuleFor(r => r.Name)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.Person.CreateNameIsNullOrEmpty);

        RuleFor(r => r.Email)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.Person.CreateEmailIsNullOrEmpty);

        RuleFor(r => r.BirthDay)
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.Person.CreateBirthDayIsNull);

        RuleFor(r => r.PostalCode)
            .NotEmpty()
            .NotNull()
            .WithErrorCatalog(ErrorCatalog.Person.CreateEmailIsNullOrEmpty);

    }
}
