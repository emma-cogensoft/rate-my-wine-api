using Domain.Entities;
using MediatR;

namespace Application.Beverages.Commands.Create;

public class CreateBeverageCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int ManufacturerId { get; set; }
}
