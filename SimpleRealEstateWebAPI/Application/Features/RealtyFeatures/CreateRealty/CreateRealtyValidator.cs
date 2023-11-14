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
        }
    }
}
