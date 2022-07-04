using MediatR;

namespace Application.Beverages.Commands.Create;

public class CreateBeverageCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
    public int ManufacturerId { get; init; }
}
