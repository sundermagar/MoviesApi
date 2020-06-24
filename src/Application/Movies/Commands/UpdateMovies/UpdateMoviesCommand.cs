using SunderTest.Application.Common.Exceptions;
using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace SunderTest.Application.Movies.Commands.UpdateMovies
{
    public partial class UpdateMoviesCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? Releasedate { get; set; }
        public int? GenreId { get; set; }
        public string Duration { get; set; }
        public string Rating { get; set; }
    }

    public class UpdateMoviesCommandHandler : IRequestHandler<UpdateMoviesCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMoviesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMoviesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movies), request.Id);
            }
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Releasedate = request.Releasedate;
            entity.GenreId = request.GenreId > 0 ? request.GenreId : null;
            entity.Duration = request.Duration;
            entity.Rating = request.Rating;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
