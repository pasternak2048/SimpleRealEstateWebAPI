using FluentValidation;

namespace Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType
{
    public class DeleteRealtyWallTypeValidator : AbstractValidator<DeleteRealtyWallTypeRequest>
    {
        public DeleteRealtyWallTypeValidator()
        {
            RuleFor(x => x.RealtyId).NotEmpty().WithMessage("RealtyID mustn`t be empty.");
            RuleFor(x => x.WallTypeId).NotEmpty().WithMessage("WallTypeID mustn`t be empty.");
        }
    }
}
