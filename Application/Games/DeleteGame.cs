using MediatR;
using Persistence;

namespace Application.Games;

public class DeleteGame
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, Unit>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var game = await context.Games.FindAsync([request.Id], cancellationToken)
                ?? throw new Exception("Cannot find game");

            context.Remove(game);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
