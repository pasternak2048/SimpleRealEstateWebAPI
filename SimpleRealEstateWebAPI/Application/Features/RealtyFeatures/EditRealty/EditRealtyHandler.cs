﻿using Application.Common.Exceptions;
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
            var userId = _currentUserService.UserId;
            var userRole = _currentUserService.UserRole;

            var realty = await _context.Realties
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

            if (realty == null)
            {
                throw new NotFoundException($"Realty with ID {request.Id} not found.");
            }

            if (userRole == "Client" && userId != realty.CreatedById)
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }

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

            if (userRole == "Administrator" || userRole == "Superuser")
            {
                realty.RealtyStatusId = request.RealtyStatusId;
            }

            //_context.Realties.Update(realty);

            await _context.SaveChangesAsync(cancellationToken);
                
            return Unit.Value;
        }

        
    }

}
