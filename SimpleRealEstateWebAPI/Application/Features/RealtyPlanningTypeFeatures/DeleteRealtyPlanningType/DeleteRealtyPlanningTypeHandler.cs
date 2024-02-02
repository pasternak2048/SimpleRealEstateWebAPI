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

            var realtyPlanningType = await _context.RealtyPlanningTypes.Where(x => x.Id == request.RealtyPlanningTypeId && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (realtyPlanningType == null)
            {
                throw new NotFoundException($"RealtyPlanningType with RealtyPlanningTypeID {request.RealtyPlanningTypeId} not found.");
            }

            if (userRole == "Client" && userId != realtyPlanningType.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            realtyPlanningType.IsDeleted = true;

            _context.RealtyPlanningTypes.Update(realtyPlanningType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
