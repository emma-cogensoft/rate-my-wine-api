using FluentValidation;

namespace Application.Reviews.Commands.Update;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
        
        RuleFor(v => v.BeverageId)
            .NotEmpty();
        
        RuleFor(v => v.Rating.Value)
            .InclusiveBetween(0, 5)
            .NotEmpty();
        
        RuleFor(v => v.ReviewText)
            .MaximumLength(1000)
            .NotEmpty();
    }
}