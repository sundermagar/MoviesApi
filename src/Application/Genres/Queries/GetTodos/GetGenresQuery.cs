using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SunderTest.Domain.Entities;
using SunderTest.Application.Common.Interfaces;
using System.Collections.Generic;

namespace SunderTest.Application.Genres.Queries.GetGenres
{
    public class GetGenresQuery : IRequest<List<Genre>>
    {
    }

    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<Genre>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Genre>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            List<Genre> List = await _context.Genres.ToListAsync(cancellationToken);

            return List;
        }
    }
}
