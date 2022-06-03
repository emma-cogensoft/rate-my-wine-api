using Domain.Entities;
using MediatR;

namespace Application.Beverages.Commands.Create;

public class CreateBeverageCommand : IRequest<Beverage>
{
    public string Name { get; set; } = string.Empty;
}
