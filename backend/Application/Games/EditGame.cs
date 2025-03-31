using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Games;

public class EditGame
{
    public class Command : IRequest
    {
        public required Game Game { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var game = await context.Games
                .FindAsync([request.Game.Id], cancellationToken)
                    ?? throw new Exception("Cannot find game");

            mapper.Map(request.Game, game);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
