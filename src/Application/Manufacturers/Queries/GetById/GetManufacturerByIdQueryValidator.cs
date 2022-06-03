using FluentValidation;

namespace Application.Manufacturers.Queries.GetById;

public class GetManufacturerByIdQueryValidator : AbstractValidator<GetManufacturerByIdQuery>
{
    public GetManufacturerByIdQueryValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}