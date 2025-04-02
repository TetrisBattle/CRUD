using API.Controllers;
using Application.Games;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GamesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            // return await context.Games.ToListAsync();
            return await Mediator.Send(new GetGames.Query());
            // return HandleResult(await Mediator.Send(new GetGames.Query()));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(string id)
        {
            return await Mediator.Send(new GetGame.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateGame(Game game)
        {
            return await Mediator.Send(new CreateGame.Command { Game = game });
        }

        [HttpPut]
        public async Task<ActionResult> EditGame(Game game)
        {
            await Mediator.Send(new EditGame.Command { Game = game });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(string id)
        {
            await Mediator.Send(new DeleteGame.Command { Id = id });
            return Ok();
        }
    }
}
