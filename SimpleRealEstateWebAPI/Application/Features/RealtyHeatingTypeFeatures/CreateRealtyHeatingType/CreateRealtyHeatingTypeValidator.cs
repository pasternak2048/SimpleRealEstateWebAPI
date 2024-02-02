using FluentValidation;

namespace Application.Features.RealtyHeatingTypeFeatures.CreateRealtyHeatingType
{
    public class CreateRealtyHeatingTypeValidator : AbstractValidator<CreateRealtyHeatingTypeRequest>
    {
        public CreateRealtyHeatingTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.HeatingTypeId).NotEmpty().WithMessage("HeatingTypeID mustn`t be empty.");
        }
    }
}
