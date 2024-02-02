using FluentValidation;

namespace Application.Features.RealtyFeatures.EditRealty
{
    public class EditRealtyValidator : AbstractValidator<EditRealtyRequest>
    {
        public EditRealtyValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description mustn`t be empty.");

            RuleFor(x => x.LocationId).NotEmpty().WithMessage("LocationId mustn`t be empty."); ;

            RuleFor(x => x.RealtyTypeId)
                .NotNull().WithMessage("Realty Type Id mustn't be null");

            RuleFor(x => x.RealtyTypeId).IsInEnum().WithMessage("Realty Type Id: out of range.");
        }
    }
}
