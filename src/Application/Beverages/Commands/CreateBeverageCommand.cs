using Domain.Entities;
using MediatR;

namespace Application.Beverages.Commands;

public class CreateBeverageCommand : IRequest<Beverage>
{
    public string Name { get; set; } = string.Empty;
}
