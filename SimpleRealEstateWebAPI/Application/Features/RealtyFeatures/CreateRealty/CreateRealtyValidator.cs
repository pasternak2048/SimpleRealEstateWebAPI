using Domain.Entities;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyValidator : AbstractValidator<CreateRealtyRequest>
    {
        public CreateRealtyValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description mustn`t be empty.");

            RuleFor(x => x.LocationId).NotEmpty().WithMessage("LocationId mustn`t be empty.");;
           
            RuleFor(x => x.RealtyTypeId)
                .NotNull().WithMessage("Realty Type Id mustn't be null");
            RuleFor(x => x.RealtyTypeId).IsInEnum().WithMessage("Realty Type Id: out of range.");

            RuleForEach(x => x.RealtyPlanningTypes).SetValidator(new RealtyPlanningTypeValidator());

            RuleForEach(x => x.RealtyHeatingTypes).SetValidator(new RealtyHeatingTypeValidator());

            RuleForEach(x => x.RealtyWallTypes).SetValidator(new RealtyWallTypeValidator());
        }


        private sealed class RealtyPlanningTypeValidator : AbstractValidator<int>
        {
            public RealtyPlanningTypeValidator()
            {
                RuleFor(x => (PlanningTypeEnum)x).IsInEnum().WithMessage("Planning type: out of range.");
            }
        }

        private sealed class RealtyHeatingTypeValidator : AbstractValidator<int>
        {
            public RealtyHeatingTypeValidator()
            {
                RuleFor(x => (HeatingTypeEnum)x).IsInEnum().WithMessage("Heating type: out of range.");
            }
        }

        private sealed class RealtyWallTypeValidator : AbstractValidator<int>
        {
            public RealtyWallTypeValidator()
            {
                RuleFor(x => (WallTypeEnum)x).IsInEnum().WithMessage("Wall type: out of range.");
            }
        }
    }
}
