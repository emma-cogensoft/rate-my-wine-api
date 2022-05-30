using FluentValidation;

namespace Application.Manufacturers.Queries.GetById;

public class GetManufacturerByIdCommandValidator : AbstractValidator<GetManufacturerByIdQuery>
{
    public GetManufacturerByIdCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty();
    }
}