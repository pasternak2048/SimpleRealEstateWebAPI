using FluentValidation;

namespace Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType
{
    public class DeleteRealtyHeatingTypeValidator : AbstractValidator<DeleteRealtyHeatingTypeRequest>
    {
        public DeleteRealtyHeatingTypeValidator()
        {
            RuleFor(x => x.RealtyHeatingTypeId).NotEmpty().WithMessage("RealtyHeatingTypeID mustn`t be empty.");
        }
    }
}
