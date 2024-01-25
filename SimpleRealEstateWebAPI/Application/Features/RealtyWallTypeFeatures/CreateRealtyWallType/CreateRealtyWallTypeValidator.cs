using FluentValidation;

namespace Application.Features.RealtyWallTypeFeatures.CreateRealtyWallType
{
    public class CreateRealtyWallTypeValidator : AbstractValidator<CreateRealtyWallTypeRequest>
    {
        public CreateRealtyWallTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.WallTypeId).NotEmpty().WithMessage("WallTypeID mustn`t be empty.");
        }
    }
}
