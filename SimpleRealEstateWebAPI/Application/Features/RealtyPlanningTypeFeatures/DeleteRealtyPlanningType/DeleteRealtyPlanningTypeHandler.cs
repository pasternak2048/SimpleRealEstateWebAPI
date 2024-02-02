using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyPlanningTypeFeatures.DeleteRealtyPlanningType
{
    public class DeleteRealtyPlanningTypeHandler : IRequestHandler<DeleteRealtyPlanningTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteRealtyPlanningTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteRealtyPlanningTypeRequest request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties
                .Include(x=>x.RealtyPlanningTypes)
                .FirstOrDefaultAsync(x => x.Id == request.RealtyId && !x.IsDeleted, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.RealtyId} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            var realtyPlanningType = realty.RealtyPlanningTypes.FirstOrDefault(x => x.PlanningTypeId == request.PlanningTypeId
            && x.RealtyId == request.RealtyId
            && !x.IsDeleted);

            if(realtyPlanningType == null)
            {
                throw new NotFoundException($"RealtyPlanningType with RealtyID {request.RealtyId} and PlanningTypeID {request.PlanningTypeId} not found.");
            }

            _context.RealtyPlanningTypes.Remove(realtyPlanningType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
