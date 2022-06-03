using Domain.Entities;
using MediatR;

namespace Application.Beverages.Commands.Update;

public class UpdateBeverageCommand : IRequest<Beverage>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Manufacturer Manufacturer { get; set; } = new Manufacturer();
}
