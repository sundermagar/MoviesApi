using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace SunderTest.Application.Movies.Commands.CreateMovies
{
    public class CreateMoviesCommand : IRequest<int>
    { 
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? Releasedate { get; set; }
        public int? GenreId { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }
    }

    public class CreateMoviesCommandHandler : IRequestHandler<CreateMoviesCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMoviesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMoviesCommand request, CancellationToken cancellationToken)
        {
            var entity = new Movie
            {
                Name = request.Name,
                Description = request.Description,
                Releasedate= request.Releasedate,
                GenreId = request.GenreId>0? request.GenreId:null,
                Duration = request.Duration,
                Rating = request.Rating
            };

            _context.Movies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
