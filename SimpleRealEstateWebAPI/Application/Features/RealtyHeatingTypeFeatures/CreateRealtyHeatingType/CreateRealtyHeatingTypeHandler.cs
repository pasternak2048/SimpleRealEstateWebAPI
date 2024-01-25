using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyHeatingTypeFeatures.CreateRealtyHeatingType
{
    public class CreateRealtyHeatingTypeHandler : IRequestHandler<CreateRealtyHeatingTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateRealtyHeatingTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CreateRealtyHeatingTypeRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties.FirstOrDefaultAsync(x => x.Id == request.RealtyId, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.RealtyId} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var heatingType = await _context.HeatingTypes.FirstOrDefaultAsync(x => x.Id == request.HeatingTypeId, cancellationToken);

            if (heatingType == null)
            {
                throw new NotFoundException($"Heating Type with ID {request.HeatingTypeId} not found.");
            }

            var realtyHeatingType = await _context.RealtyHeatingTypes
                .FirstOrDefaultAsync(x => x.HeatingTypeId == request.HeatingTypeId && x.RealtyId == request.RealtyId, cancellationToken);

            if (realtyHeatingType != null)
            {
                throw new AlreadyExistException($"Realty Heating Type with ID {request.RealtyId} , {request.HeatingTypeId} already exist.");
            }

            realtyHeatingType = _mapper.Map<RealtyHeatingType>(request);

            _context.RealtyHeatingTypes.Add(realtyHeatingType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
