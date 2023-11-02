using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Value.V1.Commands.Create
{
    public class CreateCommandValidation : AbstractValidator<CreateValueCommand>
    {
        public CreateCommandValidation()
        {
            RuleFor(r => r)
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.BaseInvalidRequest);

            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.CraeteCodeIsNullOrEmpty);

            RuleFor(r => r.Description)
                .NotEmpty()
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.CraeteDescriptionIsNullOrEmpty);

        }
    }
}
