using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RealtyFeatures.CreateRealty
{
    public class CreateRealtyHandler : IRequestHandler<CreateRealtyRequest, CreateRealtyResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRealtyRepository _realtyRepository;
        private readonly IMapper _mapper;

        public CreateRealtyHandler(IUnitOfWork unitOfWork, IRealtyRepository realtyRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _realtyRepository = realtyRepository;
            _mapper = mapper;
        }

        public async Task<CreateRealtyResponse> Handle(CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var realty = _mapper.Map<Realty>(request);
            _realtyRepository.Create(realty);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<CreateRealtyResponse>(realty);
        }
    }
}
