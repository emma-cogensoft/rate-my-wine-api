using FluentValidation;

namespace Application.Reviews.Commands.Delete;

public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}