using FluentValidation;

namespace Application.Beverages.Commands.Update;

public class UpdateBeverageCommandValidator : AbstractValidator<UpdateBeverageCommand>
{
    public UpdateBeverageCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
        
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}