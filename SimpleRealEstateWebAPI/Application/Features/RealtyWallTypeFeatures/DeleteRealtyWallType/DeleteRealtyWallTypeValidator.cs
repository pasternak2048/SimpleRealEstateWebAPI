using FluentValidation;

namespace Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType
{
    public class DeleteRealtyWallTypeValidator : AbstractValidator<DeleteRealtyWallTypeRequest>
    {
        public DeleteRealtyWallTypeValidator()
        {
            RuleFor(x => x.RealtyWallTypeId).NotEmpty().WithMessage("RealtyWallTypeID mustn`t be empty.");
        }
    }
}
