using FluentValidation;

namespace Application.Features.RealtyPlanningTypeFeatures.CreateRealtyPlanningType
{
    public class CreateRealtyPlanningTypeValidator : AbstractValidator<CreateRealtyPlanningTypeRequest>
    {
        public CreateRealtyPlanningTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.PlanningTypeId).NotEmpty().WithMessage("PlanningTypeID mustn`t be empty.");
        }
    }
}
