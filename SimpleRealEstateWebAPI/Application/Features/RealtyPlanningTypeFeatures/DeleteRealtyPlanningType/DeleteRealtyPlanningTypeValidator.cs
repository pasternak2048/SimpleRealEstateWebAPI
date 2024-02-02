using FluentValidation;

namespace Application.Features.RealtyPlanningTypeFeatures.DeleteRealtyPlanningType
{
    public class DeleteRealtyPlanningTypeValidator : AbstractValidator<DeleteRealtyPlanningTypeRequest>
    {
        public DeleteRealtyPlanningTypeValidator()
        {
            RuleFor(x => x.RealtyPlanningTypeId).NotEmpty().WithMessage("RealtyPlanningTypeID mustn`t be empty.");
        }
    }
}
