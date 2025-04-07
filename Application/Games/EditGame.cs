using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Data;

namespace Application.Games;

public class EditGame
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Game Game { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper, IValidator<Command> validator) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var game = await context.Games.FindAsync([request.Game.Id], cancellationToken);
            if (game == null) return Result<Unit>.Failure(404);

            mapper.Map(request.Game, game);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure(400);

            return Result<Unit>.Success(204, Unit.Value);
        }
    }
}
