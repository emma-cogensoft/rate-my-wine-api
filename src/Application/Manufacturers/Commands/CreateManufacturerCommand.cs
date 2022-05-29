using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Commands;

public class CreateManufacturerCommand : IRequest<Manufacturer>
{
    public string Name { get; set; } = string.Empty;
}
