using Application.Core;
using Domain;
using MediatR;
using Data;

namespace Application.Games;

public static class GetGame
{
	public class Query : IRequest<Result<Game>>
	{
		public required string Id { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, Result<Game>>
	{
		public async Task<Result<Game>> Handle(Query request, CancellationToken cancellationToken)
		{
			var game = await context.Games.FindAsync([request.Id], cancellationToken);
			if (game == null) return Result<Game>.Failure(404);
			return Result<Game>.Success(200, game);
		}
	}
}
