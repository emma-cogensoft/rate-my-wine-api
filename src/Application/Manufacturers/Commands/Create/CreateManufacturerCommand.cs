using MediatR;

namespace Application.Manufacturers.Commands.Create;

public class CreateManufacturerCommand : IRequest<int>
{
    public string Name { get; init; } = string.Empty;
}