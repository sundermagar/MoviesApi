using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SunderTest.Application.Genres.Commands.UpdateGenres;
using SunderTest.Domain.Entities;
using System.Collections.Generic;
using SunderTest.Application.Genres.Commands.CreateGenres;
using SunderTest.Application.Genres.Commands.DeleteGenres;
using SunderTest.Application.Genres.Queries.GetGenres;

namespace SunderTest.api.Controllers
{
    
    public class GenresController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateGenresCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateGenresCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGenresCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            try {
                return await Mediator.Send(new GetGenresQuery());
            }
            catch (System.Exception ex) {
                return null;
            }
           
        }
    }
}
