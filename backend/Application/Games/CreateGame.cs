using Domain;
using MediatR;
using Persistence;

namespace Application.Games;

public class CreateGame
{
    public class Command : IRequest<string>
    {
        public required Game Game { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Games.Add(request.Game);
            await context.SaveChangesAsync(cancellationToken);
            return request.Game.Id;
        }
    }
}
