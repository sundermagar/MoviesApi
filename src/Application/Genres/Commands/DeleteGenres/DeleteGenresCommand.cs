using SunderTest.Application.Common.Exceptions;
using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SunderTest.Application.Genres.Commands.DeleteGenres
{
    public class DeleteGenresCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteGenresCommandHandler : IRequestHandler<DeleteGenresCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGenresCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGenresCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Genres.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Genres), request.Id);
            }

            _context.Genres.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
