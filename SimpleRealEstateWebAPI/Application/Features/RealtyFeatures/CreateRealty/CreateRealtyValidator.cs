using FluentValidation;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyValidator : AbstractValidator<CreateRealtyRequest>
    {
        public CreateRealtyValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.LocationId).NotEmpty();
        }
    }
}
