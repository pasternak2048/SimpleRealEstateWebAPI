using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyWallTypeFeatures.DeleteRealtyWallType
{
    public class DeleteRealtyWallTypeHandler : IRequestHandler<DeleteRealtyWallTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteRealtyWallTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteRealtyWallTypeRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties
                .Include(x => x.RealtyWallTypes)
                .FirstOrDefaultAsync(x => x.Id == request.RealtyId, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.RealtyId} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var realtyWallType = realty.RealtyWallTypes.FirstOrDefault(x => x.WallTypeId == request.WallTypeId && x.RealtyId == request.RealtyId);

            if (realtyWallType == null)
            {
                throw new NotFoundException($"RealtyWallType with RealtyID {request.RealtyId} and WallTypeID {request.WallTypeId} not found.");
            }

            _context.RealtyWallTypes.Remove(realtyWallType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
