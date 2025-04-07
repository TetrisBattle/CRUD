using Domain;

namespace Application.Games.Validators;

public class CreateGameValidator : BaseGameValidator<CreateGame.Command, Game>
{
    public CreateGameValidator() : base(x => x.Game)
    {
    }
}
