using Domain;
using FluentValidation;

namespace Application.Games.Validators;

public class BaseGameValidator<T, TDto> : AbstractValidator<T> where TDto
    : Game
{
    public BaseGameValidator(Func<T, TDto> selector)
    {
        RuleFor(x => selector(x).Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(10).WithMessage("Name must not exceed 100 characters");
    }
}
