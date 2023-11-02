using FluentValidation;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Base.Extension;

namespace Test.Raizen.Application.Value.V1.Queries.GetById
{
    public class GetValueByIdQueryValidation : AbstractValidator<GetValueByIdQuery>
    {
        public GetValueByIdQueryValidation()
        {
            RuleFor(r => r)
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.BaseInvalidRequest);

            RuleFor(r => r.Id)
                .NotEmpty()
                .NotNull()
                .WithErrorCatalog(ErrorCatalog.Value.GetByIdNotFound);
        }
    }
}
