using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RealtyPlanningTypeFeatures.CreateRealtyPlanningType
{
    public class CreateRealtyPlanningTypeHandler : IRequestHandler<CreateRealtyPlanningTypeRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateRealtyPlanningTypeHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<Unit> Handle(CreateRealtyPlanningTypeRequest request, CancellationToken cancellationToken)
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

            var planningType = await _context.PlanningTypes.FirstOrDefaultAsync(x => x.Id == request.PlanningTypeId, cancellationToken);

            if (planningType == null)
            {
                throw new NotFoundException($"Planning Type with ID {request.PlanningTypeId} not found.");
            }

            var realtyPlanningType = await _context.RealtyPlanningTypes
                .FirstOrDefaultAsync(x => x.PlanningTypeId == request.PlanningTypeId && x.RealtyId == request.RealtyId, cancellationToken);

            if (realtyPlanningType != null)
            {
                throw new AlreadyExistException($"Realty Planning Type with ID {request.RealtyId} , {request.PlanningTypeId} already exist.");
            }

            realtyPlanningType = _mapper.Map<RealtyPlanningType>(request);

            _context.RealtyPlanningTypes.Add(realtyPlanningType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
