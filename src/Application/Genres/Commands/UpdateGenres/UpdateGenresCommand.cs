using SunderTest.Application.Common.Exceptions;
using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SunderTest.Application.Genres.Commands.UpdateGenres
{
    public partial class UpdateGenresCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateGenresCommandHandler : IRequestHandler<UpdateGenresCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGenresCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGenresCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Genres.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Genres), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
