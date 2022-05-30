using FluentValidation;

namespace Application.Manufacturers.Commands.Delete;

public class DeleteManufacturerCommandValidator : AbstractValidator<DeleteManufacturerCommand>
{
    public DeleteManufacturerCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}