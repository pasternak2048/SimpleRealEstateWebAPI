using FluentValidation;

namespace Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType
{
    public class DeleteRealtyHeatingTypeValidator : AbstractValidator<DeleteRealtyHeatingTypeRequest>
    {
        public DeleteRealtyHeatingTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.HeatingTypeId).NotEmpty().WithMessage("HeatingTypeID mustn`t be empty.");
        }
    }
}
