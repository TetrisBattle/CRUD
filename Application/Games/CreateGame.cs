using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Data;

namespace Application.Games;

public class CreateGame
{
    public class Command : IRequest<Result<string>>
    {
        public required Game Game { get; set; }
    }

    public class Handler(AppDbContext context, IValidator<Command> validator) : IRequestHandler<Command, Result<string>>
    {
        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            context.Games.Add(request.Game);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<string>.Failure(400);

            return Result<string>.Success(201, request.Game.Id);
        }
    }
}
