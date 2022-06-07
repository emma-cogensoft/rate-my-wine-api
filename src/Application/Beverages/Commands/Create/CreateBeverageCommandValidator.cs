using FluentValidation;

namespace Application.Beverages.Commands.Create;

public class CreateBeverageCommandValidator : AbstractValidator<CreateBeverageCommand>
{
    public CreateBeverageCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
                
        RuleFor(v => v.ManufacturerId)
            .NotEmpty();

    }
}