using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyHeatingTypeFeatures.DeleteRealtyHeatingType
{
    public class DeleteRealtyHeatingTypeHandler : IRequestHandler<DeleteRealtyHeatingTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteRealtyHeatingTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteRealtyHeatingTypeRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties
                .Include(x => x.RealtyHeatingTypes)
                .FirstOrDefaultAsync(x => x.Id == request.RealtyId && !x.IsDeleted, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.RealtyId} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var realtyHeatingType = realty.RealtyHeatingTypes.FirstOrDefault(x => x.HeatingTypeId == request.HeatingTypeId
            && x.RealtyId == request.RealtyId
            && !x.IsDeleted);

            if (realtyHeatingType == null)
            {
                throw new NotFoundException($"RealtyHeatingType with RealtyID {request.RealtyId} and HeatingTypeID {request.HeatingTypeId} not found.");
            }

            _context.RealtyHeatingTypes.Remove(realtyHeatingType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
