using Domain.Entities;
using MediatR;

namespace Application.Beverages.Commands.Update;

public class UpdateBeverageCommand : IRequest<Beverage>
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int ManufacturerId { get; init; }
}
