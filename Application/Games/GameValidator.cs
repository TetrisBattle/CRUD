using Domain;
using FluentValidation;

namespace Application.Games;

public class GameValidator : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");
    }
}
