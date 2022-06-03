using FluentValidation;

namespace Application.Reviews.Queries.GetById;

public class GetReviewByIdQueryValidator : AbstractValidator<GetReviewByIdQuery>
{
    public GetReviewByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}