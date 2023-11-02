using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Value.V1.Commands.Update
{
    public class UpdateCommandValidation : AbstractValidator<UpdateValueCommand>
    {
        public UpdateCommandValidation()
        {
            RuleFor(r => r)
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.BaseInvalidRequest);
        }
    }
}
