using SunderTest.Application.Common.Interfaces;
using SunderTest.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SunderTest.Application.Genres.Commands.CreateGenres
{
    public class CreateGenresCommand : IRequest<int>
    { 
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateGenresCommandHandler : IRequestHandler<CreateGenresCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateGenresCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGenresCommand request, CancellationToken cancellationToken)
        {
            var entity = new Genre
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Genres.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
