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

namespace SunderTest.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<List<Movie>>
    {
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<Movie>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Movie> List = await _context.Movies.ToListAsync(cancellationToken);

            return List;
        }
    }
}
