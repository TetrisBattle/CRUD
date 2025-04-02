using Domain;
using MediatR;
using Persistence;

namespace Application.Games;

public static class GetGame
{
	public class Query : IRequest<Game>
	{
		public required string Id { get; set; }
	}

	public class Handler(AppDbContext context) : IRequestHandler<Query, Game>
	{
		public async Task<Game> Handle(Query request, CancellationToken cancellationToken)
		{
            return await context.Games.FindAsync([request.Id], cancellationToken)
				?? throw new Exception("Activity not found");
		}
	}
}
