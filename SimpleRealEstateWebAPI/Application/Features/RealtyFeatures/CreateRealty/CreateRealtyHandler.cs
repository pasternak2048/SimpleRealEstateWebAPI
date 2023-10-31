using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public class CreateRealtyHandler : IRequestHandler<CreateRealtyRequest, CreateRealtyResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateRealtyHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateRealtyResponse> Handle(CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var realty = _mapper.Map<Realty>(request);

            _context.Realties.Add(realty);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateRealtyResponse>(realty);
        }
    }
}
