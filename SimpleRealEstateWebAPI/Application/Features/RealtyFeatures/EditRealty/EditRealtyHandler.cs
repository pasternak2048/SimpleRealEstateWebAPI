using MediatR;

namespace Application.Features.RealtyFeatures.EditRealty
{
    public class EditRealtyHandler : IRequestHandler<EditRealtyRequest, EditRealtyResponse>
    {


        public async Task<EditRealtyResponse> Handle(EditRealtyRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
