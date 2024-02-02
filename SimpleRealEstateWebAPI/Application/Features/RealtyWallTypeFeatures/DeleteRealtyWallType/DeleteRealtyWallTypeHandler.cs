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

            var realtyWallType = await _context.RealtyWallTypes.Where(x => x.Id == request.RealtyWallTypeId && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            if (realtyWallType == null)
            {
                throw new NotFoundException($"RealtyWallType with RealtyWallTypeID {request.RealtyWallTypeId} not found.");
            }

            if (userRole == "Client" && userId != realtyWallType.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

            realtyWallType.IsDeleted = true;

            _context.RealtyWallTypes.Update(realtyWallType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
