using Application.Errors;
using AutoMapper;
using Data;
using Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Games;

public class GameService(
	AppDbContext context,
	IValidator<Game> validator,
	IMapper mapper)
{
	private async Task<Game> FindGame(string id)
	{
		return await context.Games.FindAsync(id)
			?? throw new NotFoundException($"Game with ID {id} not found");
	}

	public async Task<List<Game>> GetGames()
	{
		return await context.Games.ToListAsync();
	}

	public async Task<Game?> GetGameById(string id)
	{
		return await FindGame(id);
	}

	public async Task<string?> CreateGame(Game game)
	{
		await validator.ValidateAndThrowAsync(game);
		context.Games.Add(game);
		await context.SaveChangesAsync();
		return game.Id;
	}

	public async Task EditGame(Game editedGame)
	{
		await validator.ValidateAndThrowAsync(editedGame);
		var existingGame = await FindGame(editedGame.Id);
		mapper.Map(editedGame, existingGame);
		await context.SaveChangesAsync();
	}

	public async Task DeleteGame(string id)
	{
		var gameToDelete = await FindGame(id);
		context.Games.Remove(gameToDelete);
		await context.SaveChangesAsync();
	}
}
