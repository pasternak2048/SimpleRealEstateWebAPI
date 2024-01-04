using FluentValidation;

namespace Application.Features.RealtyPlanningTypeFeatures.DeleteRealtyPlanningType
{
    public class DeleteRealtyPlanningTypeValidator : AbstractValidator<DeleteRealtyPlanningTypeRequest>
    {
        public DeleteRealtyPlanningTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.PlanningTypeId).NotEmpty().WithMessage("PlanningTypeID mustn`t be empty.");
        }
    }
}
