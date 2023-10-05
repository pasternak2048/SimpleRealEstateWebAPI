using FluentValidation;

namespace Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesValidator : AbstractValidator<GetRealtiesRequest>
    {
        public GetRealtiesValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}
