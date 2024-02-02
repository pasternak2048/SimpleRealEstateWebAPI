using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyWallTypeFeatures.CreateRealtyWallType
{
    public class CreateRealtyWallTypeHandler : IRequestHandler<CreateRealtyWallTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateRealtyWallTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CreateRealtyWallTypeRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties.FirstOrDefaultAsync(x => x.Id == request.RealtyId && !x.IsDeleted, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.RealtyId} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var wallType = await _context.WallTypes.FirstOrDefaultAsync(x => x.Id == request.WallTypeId, cancellationToken);

            if (wallType == null)
            {
                throw new NotFoundException($"Wall Type with ID {request.WallTypeId} not found.");
            }

            var realtyWallType = await _context.RealtyWallTypes
                .FirstOrDefaultAsync(x => x.WallTypeId == request.WallTypeId
                && x.RealtyId == request.RealtyId
                && !x.IsDeleted, cancellationToken);

            if (realtyWallType != null)
            {
                throw new AlreadyExistException($"Realty Wall Type {request.WallTypeId} for Realty {request.RealtyId} already exist.");
            }

            realtyWallType = _mapper.Map<RealtyWallType>(request);

            _context.RealtyWallTypes.Add(realtyWallType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
