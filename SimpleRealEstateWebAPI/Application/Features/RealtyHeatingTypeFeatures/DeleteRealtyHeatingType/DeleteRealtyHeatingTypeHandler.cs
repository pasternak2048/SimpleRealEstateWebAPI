using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
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

            var realtyHeatingType = await _context.RealtyHeatingTypes.Where(x => x.Id == request.RealtyHeatingTypeId && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (realtyHeatingType == null)
            {
                throw new NotFoundException($"RealtyHeatingType with RealtyHeatingTypeID {request.RealtyHeatingTypeId} not found.");
            }

            if (userRole == "Client" && userId != realtyHeatingType.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            realtyHeatingType.IsDeleted = true;

            _context.RealtyHeatingTypes.Update(realtyHeatingType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
