using SunderTest.Application.Common.Exceptions;
using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SunderTest.Application.Movies.Commands.DeleteMovies
{
    public class DeleteMoviesCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMoviesCommandHandler : IRequestHandler<DeleteMoviesCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMoviesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMoviesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Genres), request.Id);
            }

            _context.Movies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
