using FluentValidation;

namespace Application.Reviews.Commands.Create;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(v => v.Rating.Value)
            .InclusiveBetween(0, 5)
            .NotEmpty();
        
        RuleFor(v => v.ReviewText)
            .MaximumLength(1000)
            .NotEmpty();
    }
}