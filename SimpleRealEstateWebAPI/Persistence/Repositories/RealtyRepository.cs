using Application.Common.Models;
using Application.Features.RealtyFeatures.GetRealties;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Threading;

namespace Persistence.Repositories
{
    public class RealtyRepository : IRealtyRepository
    {
        protected readonly DataContext Context;
        private readonly IMapper _mapper;

        public RealtyRepository(DataContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public void Create(Realty entity)
        {
            Context.Add(entity);
        }

        public void Update(Realty entity)
        {
            Context.Update(entity);
        }

        public void Delete(Realty entity)
        {
            entity.RealtyStatusId = RealtyStatusEnum.Deleted;
            Context.Update(entity);
        }

        public async Task<PaginatedList<GetRealtiesResponse>> GetRealties(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var itemsQueryable = Context.Realties.AsQueryable();

            var items = await itemsQueryable.ToListAsync(cancellationToken);

            return PaginatedList<GetRealtiesResponse>.Create(_mapper.Map<List<GetRealtiesResponse>>(items), pageNumber, pageSize);
        }
    }
}
