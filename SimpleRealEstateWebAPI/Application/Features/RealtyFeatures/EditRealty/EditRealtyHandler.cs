using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Application.Features.RealtyFeatures.EditRealty
{
    public class EditRealtyHandler : IRequestHandler<EditRealtyRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public EditRealtyHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(EditRealtyRequest request, CancellationToken cancellationToken)
        {
            var realty = await _context.Realties
                .Include(x=>x.RealtyPlanningTypes).ThenInclude(y=>y.PlanningType)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.Id} not found.");
            }


           // if(realty.CreatedById )

            //signalr
            //transactions
            //generic dropdown
            //redis / memory cache
            //composite index
            //dapper
            //system test / integration test


            realty.Description = request.Description;
            realty.RealtyTypeId = request.RealtyTypeId;
            realty.LocationId = request.LocationId;
            realty.Floor = request.Floor;
            realty.IsFirstFloor = request.IsFirstFloor;
            realty.IsLastFloor = request.IsLastFloor;
            realty.FloorCount = request.FloorCount;
            realty.Area = request.Area;
            realty.RoomCount = request.RoomCount;
            realty.BathCount = request.BathCount;
            realty.BuildDate = request.BuildDate;

            realty.RealtyPlanningTypes = _mapper.Map<List<RealtyPlanningType>>(request.RealtyPlanningTypes.Distinct());
            realty.RealtyHeatingTypes = _mapper.Map<List<RealtyHeatingType>>(request.RealtyHeatingTypes.Distinct());
            realty.RealtyWallTypes = _mapper.Map<List<RealtyWallType>>(request.RealtyWallTypes.Distinct());

            //_context.Realties.Update(realty);

            await _context.SaveChangesAsync(cancellationToken);
                
            return Unit.Value;
        }

        
    }

}
