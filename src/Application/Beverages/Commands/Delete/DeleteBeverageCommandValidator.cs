using FluentValidation;

namespace Application.Beverages.Commands.Delete;

public class DeleteBeverageCommandValidator : AbstractValidator<DeleteBeverageCommand>
{
    public DeleteBeverageCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}