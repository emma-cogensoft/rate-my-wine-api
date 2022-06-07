using FluentValidation;

namespace Application.Beverages.Queries.GetById;

public class GetBeverageByIdQueryValidator : AbstractValidator<GetBeverageByIdQuery>
{
    public GetBeverageByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}