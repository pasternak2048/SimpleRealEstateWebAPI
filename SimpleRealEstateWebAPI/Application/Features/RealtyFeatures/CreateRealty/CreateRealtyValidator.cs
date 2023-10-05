using FluentValidation;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyValidator : AbstractValidator<CreateRealtyRequest>
    {
        public CreateRealtyValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description mustn`t be empty.");
            RuleFor(x => x.LocationId).NotEmpty().WithMessage("LocationId mustn`t be empty.");
        }
    }
}
