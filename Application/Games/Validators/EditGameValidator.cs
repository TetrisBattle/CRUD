using Domain;
using FluentValidation;

namespace Application.Games.Validators;

public class EditGameValidator : BaseGameValidator<EditGame.Command, Game>
{
    public EditGameValidator() : base(x => x.Game)
    {
        RuleFor(x => x.Game.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}
