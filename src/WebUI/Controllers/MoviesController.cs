using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunderTest.Application.Movies.Commands.UpdateMovies;
using SunderTest.Domain.Entities;
using System.Collections.Generic;
using SunderTest.Application.Movies.Commands.CreateMovies;
using SunderTest.Application.Movies.Commands.DeleteMovies;
using SunderTest.Application.Movies.Queries.GetMovies;

namespace SunderTest.api.Controllers
{
     
    public class MoviesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMoviesCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateMoviesCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMoviesCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return await Mediator.Send(new GetMoviesQuery());
        }
    }
}
