using API.Controllers;
using Application.Games;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class GamesController(GameService gameService) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Game>>> GetGames()
    {
        var games = await gameService.GetGames();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(string id)
    {
        var game = await gameService.GetGameById(id);
        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateGame(Game game)
    {
        var gameId = await gameService.CreateGame(game);
        return CreatedAtAction(nameof(GetGame), new { id = gameId }, gameId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditGame(string id, Game game)
    {
        if (id != game.Id) return BadRequest("ID mismatch");
        await gameService.EditGame(game);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGame(string id)
    {
        await gameService.DeleteGame(id);
        return NoContent();
    }
}
