using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Games;

public static class GetGames
{
	public class Query : IRequest<List<Game>> {}

	public class Handler(AppDbContext context) : IRequestHandler<Query, List<Game>>
	{
		public async Task<List<Game>> Handle(Query request, CancellationToken cancellationToken)
		{
			return await context.Games.ToListAsync(cancellationToken);
		}
	}
}
