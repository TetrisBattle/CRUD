using API.Controllers;
using Application.Core;
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
            var games = await Mediator.Send(new GetGames.Query());
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(string id)
        {
            var result = await Mediator.Send(new GetGame.Query { Id = id });
            if (result.Value == null) return NotFound();
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateGame(Game game)
        {
            var gameId = await Mediator.Send(new CreateGame.Command { Game = game });
            return CreatedAtAction(nameof(GetGame), new { id = gameId }, gameId);
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
            // await Mediator.Send(new DeleteGame.Command { Id = id });
            var result = await Mediator.Send(new DeleteGame.Command { Id = id });
            if (result == null) return NotFound();
            return NoContent();
        }
    }
}
